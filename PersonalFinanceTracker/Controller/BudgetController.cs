using PersonalFinanceTracker.Controller.Interfaces;
using PersonalFinanceTracker.Exceptions;
using PersonalFinanceTracker.Services.Interfaces;
namespace PersonalFinanceTracker.Controller
{
    public class BudgetController : IBudgetController
    {
        private readonly IBudgetService _service;

        public BudgetController(IBudgetService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service), "Budget service cannot be null.");
        }

        public void Set()
        {
            try
            {
                Console.Write("Category: ");
                var category = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(category))
                {
                    throw new InvalidInputException("Category cannot be empty.");
                }

                Console.Write("Limit: ");
                var limitInput = Console.ReadLine();

                if (!decimal.TryParse(limitInput, out var limit))
                {
                    throw new InvalidInputException("Invalid limit format. Please enter a valid decimal number.");
                }

                _service.SetBudget(category, limit);
                Console.WriteLine("✓ Budget set successfully.");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (InvalidBudgetException ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
            catch (RepositoryException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Unexpected Error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Exception Details: {ex}");
            }
        }

        public void View()
        {
            try
            {
                var budgets = _service.GetBudgets();

                if (budgets == null || budgets.Count == 0)
                {
                    Console.WriteLine("No budgets set.");
                    return;
                }

                Console.WriteLine("\n--- Budgets ---");
                foreach (var budget in budgets)
                {
                    Console.WriteLine($"{budget.Category} | Limit: {budget.Limit:C} | Month: {budget.Month}/{budget.Year}");
                }
            }
            catch (RepositoryException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving budgets: {ex.Message}");
            }
        }
    }
}
