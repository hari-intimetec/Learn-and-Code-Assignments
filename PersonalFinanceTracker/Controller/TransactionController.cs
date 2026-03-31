using PersonalFinanceTracker.Controller.Interfaces;
using PersonalFinanceTracker.Exceptions;
using PersonalFinanceTracker.Services.Interfaces;
namespace PersonalFinanceTracker.Controller
{
    public class TransactionController : ITransactionController
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        public void Add()
        {
            try
            { 
                _service.AddTransaction();
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
                Console.WriteLine("Transaction deleted successfully.");
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
