namespace PersonalFinanceTracker.Exceptions
{
    public class BudgetException : Exception
    {
        public BudgetException(string message) : base(message) { }

        public BudgetException(string message, Exception innerException) : base(message, innerException) { }
    }
}
