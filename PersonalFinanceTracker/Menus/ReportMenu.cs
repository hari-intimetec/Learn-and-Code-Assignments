using PersonalFinanceTracker.Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Menus
{
    public class ReportMenu
    {
        private readonly IReportController _controller;

        public ReportMenu(IReportController controller)
        {
            _controller = controller;
        }

        public void Show()
        {
            Console.WriteLine("\nReport Menu");
            _controller.ShowSummary();
        }
    }
}
