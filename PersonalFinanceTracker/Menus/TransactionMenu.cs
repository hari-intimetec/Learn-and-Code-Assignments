using PersonalFinanceTracker.Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Menus
{
    public class TransactionMenu
    {
        private readonly ITransactionController _controller;

        public TransactionMenu(ITransactionController controller)
        {
            _controller = controller;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\nTransaction Menu");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. View");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        _controller.Add(); 
                        break;
                    case "2": 
                        _controller.View(); 
                        break;
                    case "3": 
                        _controller.Delete(); 
                        break;
                    case "4": 
                        return;
                }
            }
        }
    }
}
