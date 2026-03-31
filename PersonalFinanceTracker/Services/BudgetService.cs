using PersonalFinanceTracker.Exceptions;
using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Repositories.Interfaces;
using PersonalFinanceTracker.Services.Interfaces;
namespace PersonalFinanceTracker.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepo;

        public BudgetService(IBudgetRepository budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

        public void SetBudget(string category, decimal limit)
        {
            try
            {
                ValidateBudgetInput(category, limit);

                var budget = new Budget
                {
                    Id = Guid.NewGuid(),
                    Category = category,
                    Limit = limit,
                    Month = DateTime.Now.Month,
                    Year = DateTime.Now.Year
                };

                _budgetRepo.Add(budget);
            }
            catch (InvalidBudgetException)
            {
                throw;
            }
            catch (RepositoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Unexpected error while setting budget: {ex.Message}", ex);
            }
        }

        private void ValidateBudgetInput(string category, decimal limit)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new InvalidBudgetException("Budget category cannot be null or empty.");
            }

            if (category.Length > 100)
            {
                throw new InvalidBudgetException("Budget category cannot exceed 100 characters.");
            }

            if (limit <= 0)
            {
                throw new InvalidBudgetException("Budget limit must be greater than zero.");
            }
        }

        public List<Budget> GetBudgets()
        {
            try
            {
                var budgets = _budgetRepo.GetAll();
                return budgets;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Failed to retrieve budgets from repository: {ex.Message}", ex);
            }
        }
    }
}
