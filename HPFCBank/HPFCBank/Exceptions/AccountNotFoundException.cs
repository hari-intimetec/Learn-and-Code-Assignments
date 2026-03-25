using System;

namespace HPFCBank.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public int AccountId { get; }

        public AccountNotFoundException(int accountId): base($"Account with ID {accountId} not found.")
        {
            AccountId = accountId;
        }

        public AccountNotFoundException(int accountId, string message): base(message)
        {
            AccountId = accountId;
        }

        public AccountNotFoundException(int accountId, string message, Exception innerException): base(message, innerException)
        {
            AccountId = accountId;
        }
    }
}
