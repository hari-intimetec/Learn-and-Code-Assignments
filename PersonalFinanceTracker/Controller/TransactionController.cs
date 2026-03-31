using PersonalFinanceTracker.Controller.Interfaces;
using PersonalFinanceTracker.Enum;
using PersonalFinanceTracker.Exceptions;
using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Services.Interfaces;
namespace PersonalFinanceTracker.Controller
{
    public class TransactionController : ITransactionController
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service), "Transaction service cannot be null.");
        }

        public void Add()
        {
            try
            {
                Console.Write("Type (1=Income, 2=Expense): ");
                var typeInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(typeInput) || (typeInput != "1" && typeInput != "2"))
                {
                    throw new InvalidInputException("Invalid transaction type. Please enter 1 for Income or 2 for Expense.");
                }

                Console.Write("Amount: ");
                var amountInput = Console.ReadLine();

                if (!decimal.TryParse(amountInput, out var amount))
                {
                    throw new InvalidInputException("Invalid amount format. Please enter a valid decimal number.");
                }

                Console.Write("Category: ");
                var category = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(category))
                {
                    throw new InvalidInputException("Category cannot be empty.");
                }

                var type = typeInput == "1" ? TransactionType.Income : TransactionType.Expense;

                _service.AddTransaction(type, amount, category);
                Console.WriteLine("Transaction added successfully.");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (InvalidTransactionException ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
            catch (RepositoryException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Exception Details: {ex}");
            }
        }

        public void View()
        {
            try
            {
                var list = _service.GetTransactions();

                if (list == null || list.Count == 0)
                {
                    Console.WriteLine("No transactions found.");
                    return;
                }

                Console.WriteLine("\n--- Transactions ---");
                foreach (var tx in list)
                {
                    Console.WriteLine($"{tx.Id} | {tx.Type} | {tx.Amount:C} | {tx.Category} | {tx.Date:yyyy-MM-dd}");
                }
            }
            catch (RepositoryException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving transactions: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Exception Details: {ex}");
            }
        }

        public void Delete()
        {
            try
            {
                Console.Write("Enter Transaction ID: ");
                var idInput = Console.ReadLine();

                if (!Guid.TryParse(idInput, out var id))
                {
                    throw new InvalidInputException("Invalid transaction ID format. Please enter a valid GUID.");
                }

                _service.DeleteTransaction(id);
                Console.WriteLine("✓ Transaction deleted successfully.");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (TransactionNotFoundException ex)
            {
                Console.WriteLine($"Not Found: {ex.Message}");
            }
            catch (RepositoryException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting transaction: {ex.Message}");
            }
        }
    }
}
