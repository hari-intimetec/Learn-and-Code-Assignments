using PersonalFinanceTracker.Models;
namespace PersonalFinanceTracker.Services.Interfaces
{
    public interface ITransactionService
    {
        void AddTransaction();
        List<Transaction> GetTransactions();
        void DeleteTransaction(Guid id);
    }
}
