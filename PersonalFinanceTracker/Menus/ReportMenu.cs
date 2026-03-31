using PersonalFinanceTracker.Controller.Interfaces;
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
