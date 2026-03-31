using PersonalFinanceTracker.Adapters;
using PersonalFinanceTracker.Controller;
using PersonalFinanceTracker.Menus;
using PersonalFinanceTracker.Repositories;
using PersonalFinanceTracker.Repositories.Interfaces;
using PersonalFinanceTracker.Services;
using PersonalFinanceTracker.Services.Interfaces;

class Program
{
    static void Main()
    {
        ITransactionRepository transactionRepo = new TransactionRepository();
        IBudgetRepository budgetRepo = new BudgetRepository();

        var notification = new ConsoleNotificationService();

        ITransactionService transactionService = new TransactionService(transactionRepo, budgetRepo, notification);
        IBudgetService budgetService = new BudgetService(budgetRepo);
        IReportService reportService = new ReportService(transactionRepo);

        // Controllers
        var transactionController = new TransactionController(transactionService);
        var budgetController = new BudgetController(budgetService);
        var reportController = new ReportController(reportService);

        // Menus
        var transactionMenu = new TransactionMenu(transactionController);
        var budgetMenu = new BudgetMenu(budgetController);
        var reportMenu = new ReportMenu(reportController);

        var mainMenu = new MainMenu(transactionMenu, budgetMenu, reportMenu);

        mainMenu.Show();
    }
}
