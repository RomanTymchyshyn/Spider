using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Spider
{
    public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
    {
        #region Private Fields

        [ThreadStatic]
        private static bool _currentThreadIsProcessingItems;

        private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // lock(_tasks)

        private readonly int _maxDegreeOfParallelism;

        // Indicates whether the scheduler is currently processing work items. 
        private int _delegatesQueuedOrRunning = 0;

        #endregion

        #region CTORS

        public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism < 1) throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
            _maxDegreeOfParallelism = maxDegreeOfParallelism;
        }

        #endregion

        #region Private Methods

        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                _currentThreadIsProcessingItems = true;
                try
                {
                    while (true)
                    {
                        Task item;
                        lock (_tasks)
                        {
                            if (_tasks.Count == 0)
                            {
                                --_delegatesQueuedOrRunning;
                                break;
                            }

                            item = _tasks.First.Value;
                            _tasks.RemoveFirst();
                        }

                        TryExecuteTask(item);
                    }
                }
                finally
                {
                    _currentThreadIsProcessingItems = false;
                }
            }, null);
        }

        #endregion

        #region Public Properties

        public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }

        #endregion

        #region Protected Methods

        protected sealed override void QueueTask(Task task)
        {
            lock (_tasks)
            {
                _tasks.AddLast(task);
                if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
                {
                    ++_delegatesQueuedOrRunning;
                    NotifyThreadPoolOfPendingWork();
                }
            }
        }

        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (!_currentThreadIsProcessingItems) return false;

            if (taskWasPreviouslyQueued)
                if (TryDequeue(task))
                    return TryExecuteTask(task);
                else
                    return false;

            return TryExecuteTask(task);
        }

        protected sealed override bool TryDequeue(Task task)
        {
            lock (_tasks) return _tasks.Remove(task);
        }
 
        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_tasks, ref lockTaken);
                if (lockTaken) return _tasks;
                else throw new NotSupportedException();
            }
            finally
            {
                if (lockTaken) Monitor.Exit(_tasks);
            }
        }

        #endregion
    }
}
