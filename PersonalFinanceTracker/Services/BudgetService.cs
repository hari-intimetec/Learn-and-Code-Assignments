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
            _budgetRepo = budgetRepo ?? throw new ArgumentNullException(nameof(budgetRepo), "Budget repository cannot be null.");
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

                try
                {
                    _budgetRepo.Add(budget);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Failed to add budget to repository: {ex.Message}", ex);
                }
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
                return budgets ?? new List<Budget>();
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Failed to retrieve budgets from repository: {ex.Message}", ex);
            }
        }
    }
}
