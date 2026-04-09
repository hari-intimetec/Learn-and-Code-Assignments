namespace PersonalFinanceTracker.Adapters
{
    public class ConsoleNotificationService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine($"[ALERT]: {message}");
        }
    }
}
