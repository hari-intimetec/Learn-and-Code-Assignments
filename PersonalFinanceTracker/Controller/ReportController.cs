using PersonalFinanceTracker.Controller.Interfaces;
using PersonalFinanceTracker.Exceptions;
using PersonalFinanceTracker.Services.Interfaces;
namespace PersonalFinanceTracker.Controller
{
    public class ReportController : IReportController
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        public void ShowSummary()
        {
            try
            {
                _service.PrintMonthlySummary();
            }
            catch (ReportException ex)
            {
                Console.WriteLine($" Report Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating report: {ex.Message}");
            }
        }
    }

}
