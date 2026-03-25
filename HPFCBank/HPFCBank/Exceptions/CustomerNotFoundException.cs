using System;

namespace HPFCBank.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public int CustomerId { get; }

        public CustomerNotFoundException(int customerId): base($"Customer with ID {customerId} not found.")
        {
            CustomerId = customerId;
        }

        public CustomerNotFoundException(int customerId, string message): base(message)
        {
            CustomerId = customerId;
        }

        public CustomerNotFoundException(int customerId, string message, Exception innerException): base(message, innerException)
        {
            CustomerId = customerId;
        }
    }
}
