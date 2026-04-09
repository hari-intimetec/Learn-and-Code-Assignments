using PersonalFinanceTracker.Models;
namespace PersonalFinanceTracker.Repositories.Interfaces
{
    public interface IBudgetRepository
    {
        public void Add(Budget budget);
        public List<Budget> GetAll();
    }
}
