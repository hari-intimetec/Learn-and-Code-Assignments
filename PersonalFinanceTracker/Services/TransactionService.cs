using PersonalFinanceTracker.Adapters;
using PersonalFinanceTracker.Enum;
using PersonalFinanceTracker.Exceptions;
using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Repositories;
using PersonalFinanceTracker.Repositories.Interfaces;
using PersonalFinanceTracker.Services.Interfaces;
namespace PersonalFinanceTracker.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly IBudgetRepository _budgetRepo;
        private readonly INotificationService _notification;

        public TransactionService(
            ITransactionRepository transactionRepo,
            IBudgetRepository budgetRepo,
            INotificationService notification)
        {
            _transactionRepo = transactionRepo ?? throw new ArgumentNullException(nameof(transactionRepo), "Transaction repository cannot be null.");
            _budgetRepo = budgetRepo ?? throw new ArgumentNullException(nameof(budgetRepo), "Budget repository cannot be null.");
            _notification = notification ?? throw new ArgumentNullException(nameof(notification), "Notification service cannot be null.");
        }

        public void AddTransaction(TransactionType type, decimal amount, string category)
        {
            try
            {
                ValidateTransactionInput(amount, category);

                var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Type = type,
                    Amount = amount,
                    Category = category,
                    Date = DateTime.Now
                };

                try
                {
                    _transactionRepo.Add(transaction);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Failed to add transaction to repository: {ex.Message}", ex);
                }

                if (type == TransactionType.Expense)
                {
                    try
                    {
                        CheckBudget(transaction);
                    }
                    catch (BudgetException budgetEx)
                    {
                        Console.WriteLine($"Budget check failed: {budgetEx.Message}");
                    }
                }
            }
            catch (InvalidTransactionException)
            {
                throw;
            }
            catch (RepositoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Unexpected error while adding transaction: {ex.Message}", ex);
            }
        }

        private void ValidateTransactionInput(decimal amount, string category)
        {
            if (amount <= 0)
            {
                throw new InvalidTransactionException("Transaction amount must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new InvalidTransactionException("Transaction category cannot be null or empty.");
            }

            if (category.Length > 100)
            {
                throw new InvalidTransactionException("Transaction category cannot exceed 100 characters.");
            }
        }

        private void CheckBudget(Transaction transaction)
        {
            try
            {
                var budgets = _budgetRepo.GetAll() ?? throw new BudgetException("Failed to retrieve budgets from repository.");

                var budget = budgets.FirstOrDefault(b =>
                    b.Category == transaction.Category &&
                    b.Month == transaction.Date.Month &&
                    b.Year == transaction.Date.Year);

                if (budget == null)
                {
                    return;
                }

                if (budget.Limit <= 0)
                {
                    throw new BudgetException($"Invalid budget limit for category '{transaction.Category}': limit must be greater than zero.");
                }

                var totalExpense = _transactionRepo.GetAll()
                    .Where(tx => tx.Category == transaction.Category && tx.Type == TransactionType.Expense)
                    .Sum(tx => tx.Amount);

                if (totalExpense > budget.Limit)
                {
                    var message = $"Budget exceeded for {transaction.Category}. Total: {totalExpense:C}, Limit: {budget.Limit:C}";
                    try
                    {
                        _notification.Send(message);
                    }
                    catch (Exception notificationEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Notification failed: {notificationEx.Message}");
                    }
                }
            }
            catch (BudgetException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BudgetException($"Error occurred while checking budget for category '{transaction.Category}': {ex.Message}", ex);
            }
        }

        public List<Transaction> GetTransactions()
        {
            try
            {
                var transactions = _transactionRepo.GetAll();
                return transactions ?? new List<Transaction>();
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Failed to retrieve transactions from repository: {ex.Message}", ex);
            }
        }

        public void DeleteTransaction(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new InvalidTransactionException("Transaction ID cannot be empty.");
                }

                var transactions = _transactionRepo.GetAll();
                if (transactions == null || transactions.Count == 0)
                {
                    throw new TransactionNotFoundException(id);
                }

                var transaction = transactions.FirstOrDefault(tx => tx.Id == id);
                if (transaction == null)
                {
                    throw new TransactionNotFoundException(id);
                }

                try
                {
                    _transactionRepo.Delete(id);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Failed to delete transaction with ID '{id}' from repository: {ex.Message}", ex);
                }
            }
            catch (TransactionNotFoundException)
            {
                throw;
            }
            catch (InvalidTransactionException)
            {
                throw;
            }
            catch (RepositoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Unexpected error while deleting transaction: {ex.Message}", ex);
            }
        }
    }
}
