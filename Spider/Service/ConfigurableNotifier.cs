using System;

namespace Spider
{
    public class ConfigurableNotifier: INotifier
    {
        private readonly Action<string> _notifySimpleMessageAction;
        private readonly Action<string> _notifyCompletedMessageAction;
        private readonly Action<int> _reportProgressAction;
        public ConfigurableNotifier(Action<string> notifySimpleMessageAction, 
            Action<string> notifyCompletedMessageAction,
            Action<int> repostProgressAction)
        {
            _notifySimpleMessageAction = notifySimpleMessageAction;
            _notifyCompletedMessageAction = notifyCompletedMessageAction;
            _reportProgressAction = repostProgressAction;
        }

        public void PushNotification(string notification)
        {
            _notifySimpleMessageAction(notification);
        }

        public void NotifyCompleted(string message)
        {
            _notifyCompletedMessageAction(message);
        }

        public void ReporProgress(int percentage)
        {
            _reportProgressAction(percentage);
        }
    }
}
