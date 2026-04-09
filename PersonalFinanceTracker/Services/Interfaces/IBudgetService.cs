using PersonalFinanceTracker.Models;
namespace PersonalFinanceTracker.Services.Interfaces
{
    public interface IBudgetService
    {
        public void SetBudget(string category, decimal limit);
        public List<Budget> GetBudgets();
    }
}
