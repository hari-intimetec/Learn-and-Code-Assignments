using PersonalFinanceTracker.Controller.Interfaces;
namespace PersonalFinanceTracker.Menus
{
    public class BudgetMenu
    {
        private readonly IBudgetController _controller;

        public BudgetMenu(IBudgetController controller)
        {
            _controller = controller;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\nBudget Menu");
                Console.WriteLine("1. Set Budget");
                Console.WriteLine("2. View Budgets");
                Console.WriteLine("3. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _controller.Set();
                        break;
                    case "2": 
                        _controller.View(); 
                        break;
                    case "3": 
                        return;
                }
            }
        }
    }
}
