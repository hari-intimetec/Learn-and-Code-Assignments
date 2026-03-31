using PersonalFinanceTracker.Enum;
using PersonalFinanceTracker.Exceptions;
using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Repositories;
using PersonalFinanceTracker.Repositories.Interfaces;
using PersonalFinanceTracker.Services.Interfaces;
namespace PersonalFinanceTracker.Services
{
    public class ReportService : IReportService
    {
        private readonly ITransactionRepository _transactionRepo;

        public ReportService(ITransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo ?? throw new ArgumentNullException(nameof(transactionRepo), "Transaction repository cannot be null.");
        }

        public void PrintMonthlySummary()
        {
            try
            {
                var transactions = _transactionRepo.GetAll();

                if (transactions == null || transactions.Count == 0)
                {
                    Console.WriteLine("\n--- Monthly Summary ---");
                    Console.WriteLine("No transactions found.");
                    return;
                }

                var income = transactions
                    .Where(tx => tx.Type == TransactionType.Income)
                    .Sum(tx => tx.Amount);

                var expense = transactions
                    .Where(tx => tx.Type == TransactionType.Expense)
                    .Sum(tx => tx.Amount);

                var savings = income - expense;

                Console.WriteLine("\n--- Monthly Summary ---");
                Console.WriteLine($"Income: {income:C}");
                Console.WriteLine($"Expense: {expense:C}");
                Console.WriteLine($"Savings: {savings:C}");

                if (savings < 0)
                {
                    Console.WriteLine(" Warning: Expenses exceed income!");
                }
            }
            catch (Exception ex)
            {
                throw new ReportException($"Failed to generate monthly summary report: {ex.Message}", ex);
            }
        }
    }
}
