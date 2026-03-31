using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Menus
{
    public class MainMenu
    {
        private readonly TransactionMenu _transactionMenu;
        private readonly BudgetMenu _budgetMenu;
        private readonly ReportMenu _reportMenu;

        public MainMenu(
            TransactionMenu transactionMenu,
            BudgetMenu budgetMenu,
            ReportMenu reportMenu)
        {
            _transactionMenu = transactionMenu;
            _budgetMenu = budgetMenu;
            _reportMenu = reportMenu;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("1. Transactions");
                Console.WriteLine("2. Budget");
                Console.WriteLine("3. Reports");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _transactionMenu.Show();
                        break;
                    case "2":
                        _budgetMenu.Show();
                        break;
                    case "3":
                        _reportMenu.Show();
                        break;
                    case "4":
                        return;
                }
            }
        }
    }
}
