using System;

namespace HPFCBank.Exceptions
{
    public class LoanNotFoundException : Exception
    {
        public int LoanId { get; }

        public LoanNotFoundException(int loanId): base($"Loan with ID {loanId} not found.")
        {
            LoanId = loanId;
        }

        public LoanNotFoundException(int loanId, string message): base(message)
        {
            LoanId = loanId;
        }

        public LoanNotFoundException(int loanId, string message, Exception innerException): base(message, innerException)
        {
            LoanId = loanId;
        }
    }
}
