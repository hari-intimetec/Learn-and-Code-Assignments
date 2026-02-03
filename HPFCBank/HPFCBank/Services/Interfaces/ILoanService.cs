namespace HPFCBank.Services.Interfaces
{ 
    public interface ILoanService
    {
        void CreateLoan(int customerId, decimal principal, double rate, int years);
        void GetLoan(int loanId);
        void CalculateLoan(decimal principal, double rate, int years);


    }

}
