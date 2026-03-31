using PersonalFinanceTracker.Enum;
using PersonalFinanceTracker.Models;
namespace PersonalFinanceTracker.Services.Interfaces
{
    public interface ITransactionService
    {
        void AddTransaction(TransactionType type, decimal amount, string category);
        List<Transaction> GetTransactions();
        void DeleteTransaction(Guid id);
    }
}
