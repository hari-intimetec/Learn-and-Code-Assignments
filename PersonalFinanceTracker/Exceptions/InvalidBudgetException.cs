namespace PersonalFinanceTracker.Exceptions
{
  public class InvalidBudgetException : Exception
   {
       public InvalidBudgetException(string message) : base(message) { }

       public InvalidBudgetException(string message, Exception innerException): base(message, innerException) { }
   }
}
