namespace Spider
{
    public interface INotifier
    {
        void PushNotification(string notification);

        void NotifyCompleted(string message);

        void ReporProgress(int percentage);
    }
}
