using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Repositories.Interfaces;
namespace PersonalFinanceTracker.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions = new();

        public void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public List<Transaction> GetAll()
        {
            return _transactions;
        }

        public void Delete(Guid id)
        {
            var tx = _transactions.FirstOrDefault(tx => tx.Id == id);
            if (tx != null)
                _transactions.Remove(tx);
        }
    }
}
