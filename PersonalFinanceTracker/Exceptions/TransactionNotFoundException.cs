namespace PersonalFinanceTracker.Exceptions
{
    public class TransactionNotFoundException : Exception
    {
        public Guid TransactionId { get; }

        public TransactionNotFoundException(Guid transactionId) : base($"Transaction with ID '{transactionId}' was not found.")
        {
            TransactionId = transactionId;
        }

        public TransactionNotFoundException(Guid transactionId, Exception innerException) : base($"Transaction with ID '{transactionId}' was not found.", innerException)
        {
            TransactionId = transactionId;
        }

        public TransactionNotFoundException(string message) : base(message) { }

        public TransactionNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
