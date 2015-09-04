using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spider.Abstract;
using Spider.Service;

namespace Spider.Concrete
{
    public class SearchEngine
    {
//        private ManualResetEvent _pause = new ManualResetEvent(false);
        private CancellationTokenSource _cancellationTokenSource;

        private readonly ConcurrentQueue<string> taskQ = new ConcurrentQueue<string>();
        
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

        private TaskFactory factory;

        private int runningTasks = 0;
        private int processedTasks = 0;


        private readonly INotifier _notifier;

        public SearchEngine(INotifier notifier)
        {
            _notifier = notifier;
        }

        private void TaskCompletedHandler(Task<bool> t, int nUrls)
        {
            string message;
            if (t.IsFaulted)
            {
                message = string.Format(ErrorMessage, (string) t.AsyncState);
                t.Exception.Handle(inner => true);
                foreach (var ex in t.Exception.InnerExceptions)
                {
                    message += ex.Message + "\n";
                }
            }
            else if (t.IsCanceled)
            {
                message = string.Format(CancelledMessage, (string) t.AsyncState);
            }
            else
            {
                message = string.Format(CompletedMessage, (string)t.AsyncState, t.Result);
            }
            Interlocked.Decrement(ref runningTasks);
            Interlocked.Increment(ref processedTasks);
            _notifier.ReporProgress(processedTasks * 100 / nUrls);
            _notifier.NotifyCompleted(processedTasks + ". " + message);
        }

        public void BrowseNet(string startUrl, string textToFind, int nThreads, int nUrls)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            Interlocked.Exchange(ref processedTasks, 0);

            LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(nThreads);

            factory = new TaskFactory(lcts);

            int browsedUrls = 0;
            
            taskQ.Enqueue(startUrl);
            var tasksList = new List<Task>();

            do
            {
                string nextUrl;
                if (taskQ.TryDequeue(out nextUrl))
                {
                    var task = factory.StartNew((stateObject) => BrowsePage((string)stateObject, textToFind), 
                        nextUrl, 
                        _cancellationTokenSource.Token);
                    Interlocked.Increment(ref runningTasks);
                    ++browsedUrls;
                    task.ContinueWith((t)=>TaskCompletedHandler(t, nUrls));
                    tasksList.Add(task);
                }
            } while (browsedUrls < nUrls && runningTasks != 0);

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
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        private bool BrowsePage(string url, string textToFind)
        {
//            Interlocked.Increment(ref runningTasks);

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

            result.Links.ForEach(link=>taskQ.Enqueue(link));

            return result.Found;
        }
    }
}
