using HPFCBank.Repositories;
using HPFCBank.Repositories.Interfaces;
using HPFCBank.Services;
namespace HPFCBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var accountRepo = new InMemoryAccountRepository();
            var customerRepo = new InMemoryCustomerRepository();
            var loanRepo = new InMemoryLoanRepository();

            var accountService = new AccountService(accountRepo);
            var loanService = new LoanService(loanRepo, customerRepo);
            var customerService = new CustomerService(customerRepo);

            var menu = new MenuHandler(accountService, loanService, customerService);
            menu.Start();
        }
    }
}
