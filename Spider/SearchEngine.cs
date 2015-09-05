using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spider.Loaders;
using Spider.Parsers;
using Spider.Service;
using Spider.Utilities;

namespace Spider
{
    public class SearchEngine
    {

        #region Private Fields

        private readonly string StartedLoadingContentMessage = 
            "Loading content from URL:\n{0}...\n".Replace("\n", Environment.NewLine);

        private readonly string FinishedLoadingContentMessage = 
            "Loaded content from URL:\n{0}\n".Replace("\n", Environment.NewLine);

        private readonly string StartedParsingMessage = 
            "Parsing content of URL:\n{0}...\n".Replace("\n", Environment.NewLine);

        private readonly string CompletedMessage = 
            "Processing URL:\n{0}\n completed! \n Was text  found on this page? - {1}\n".Replace("\n", Environment.NewLine);

        private readonly string ErrorMessage =
            "Processing URL:\n{0}\n was FAULTED!!! \n ERRORS: \n".Replace("\n", Environment.NewLine);

        private readonly string CancelledMessage =
            "Processing URL:\n{0}\n was cancelled!!!\n".Replace("\n", Environment.NewLine);

        private int _currentlyRunningTasks;
        private int _processedTasks;

        private bool _paused;
        private readonly object _syncObject = new Object();

        private CancellationTokenSource _cancellationTokenSource;

        private ConcurrentQueue<string> _taskQ;

        private ConcurrentHashSet<string> _uniqueLinks;

        private TaskFactory _factory;

        private readonly INotifier _notifier;

        #endregion

        #region CTORS

        public SearchEngine(INotifier notifier)
        {
            _notifier = notifier;
        }

        #endregion

        #region Private Methods

        private void TaskCompletedHandler(Task<bool> t, int nUrls)
        {
            string message;
            if (t.IsFaulted)
            {
                message = string.Format(ErrorMessage, (string)t.AsyncState);
                t.Exception.Handle(inner => true);
                foreach (var ex in t.Exception.InnerExceptions)
                {
                    message += ex.Message + "\n";
                }
            }
            else if (t.IsCanceled)
            {
                message = string.Format(CancelledMessage, (string)t.AsyncState);
            }
            else
            {
                message = string.Format(CompletedMessage, (string)t.AsyncState, t.Result);
            }
            Interlocked.Decrement(ref _currentlyRunningTasks);
            Interlocked.Increment(ref _processedTasks);
            _notifier.ReporProgress(_processedTasks * 100 / nUrls);
            _notifier.NotifyCompleted(_processedTasks + ". " + message);
        }

        private bool BrowsePage(string url, string textToFind)
        {
            lock (_syncObject) { }
            var contentLoader = new ContentLoader();
            var parser = new RegExBasedHtmlParser();

            var message = string.Format(StartedLoadingContentMessage, url);
            _notifier.PushNotification(message);

            var content = contentLoader.LoadContent(url);

            message = string.Format(FinishedLoadingContentMessage, url);
            _notifier.PushNotification(message);

            message = string.Format(StartedParsingMessage, url);
            _notifier.PushNotification(message);

            var result = parser.Parse(content, textToFind);

            result.Links.ForEach(link =>
            {
                if (_uniqueLinks.Add(link))
                {
                    _taskQ.Enqueue(link);
                }
            });

            return result.Found;
        }

        #endregion

        #region Public Methods

        public void BrowseNet(string startUrl, string textToFind, int nThreads, int nUrls)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _taskQ = new ConcurrentQueue<string>();
            _uniqueLinks = new ConcurrentHashSet<string>();

            Interlocked.Exchange(ref _processedTasks, 0);
            Interlocked.Exchange(ref _currentlyRunningTasks, 0);

            LimitedConcurrencyLevelTaskScheduler taskScheduler = new LimitedConcurrencyLevelTaskScheduler(nThreads);

            _factory = new TaskFactory(taskScheduler);

            int browsedUrls = 0;

            _taskQ.Enqueue(startUrl);
            var tasksList = new List<Task>();

            do
            {
                string nextUrl;
                if (_taskQ.TryDequeue(out nextUrl))
                {
                    var task = _factory.StartNew((stateObject) => BrowsePage((string)stateObject, textToFind),
                        nextUrl,
                        _cancellationTokenSource.Token);
                    Interlocked.Increment(ref _currentlyRunningTasks);
                    ++browsedUrls;
                    task.ContinueWith((t) => TaskCompletedHandler(t, nUrls));
                    tasksList.Add(task);
                }
            } while (browsedUrls < nUrls && _currentlyRunningTasks != 0 && !_cancellationTokenSource.IsCancellationRequested);

            try
            {
                Task.WaitAll(tasksList.ToArray());
            }
            catch (AggregateException ex)
            {
                ex.Handle((inner) => true);
            }
        }

        public void CancelPreviousBrowsing()
        {
            Resume();
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        public void Pause()
        {
            if (_paused == false)
            {
                Monitor.Enter(_syncObject);
                _paused = true;
            }
        }

        public void Resume()
        {
            if (_paused)
            {
                Monitor.Exit(_syncObject);
                _paused = false;
            }
        }

        #endregion

    }
}
