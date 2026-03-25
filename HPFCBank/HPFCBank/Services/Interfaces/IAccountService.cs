namespace HPFCBank.Services.Interfaces
{
    public interface IAccountService
    {
        int CreateAccount(int customerId);
        void Deposit(int accountId, decimal amount);
        void Transfer(int fromAccountId, int toAccountId, decimal amount);
        void ShowBalance(int accountId);
        void Withdraw(int accountId, decimal amount);
    }
}
