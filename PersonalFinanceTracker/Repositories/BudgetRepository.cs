using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Repositories.Interfaces;
namespace PersonalFinanceTracker.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly List<Budget> _budgets = new List<Budget>();

        public void Add(Budget budget)
        {
            _budgets.Add(budget);
        }

        public List<Budget> GetAll()
        {
            return _budgets;
        }
    }
}
