using PersonalFinanceTracker.Models;
namespace PersonalFinanceTracker.Repositories.Interfaces
{
     public interface ITransactionRepository
    {
        public void Add(Transaction transaction);
        public List<Transaction> GetAll();
        public void Delete(Guid id);
    }
}
