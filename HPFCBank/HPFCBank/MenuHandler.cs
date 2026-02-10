using HPFCBank.Services.Interfaces;
using System;

namespace HPFCBank
{
    public class MenuHandler
    {
        private readonly IAccountService _accountService;
        private readonly ILoanService _loanService;
        private readonly ICustomerService _customerService;

        public MenuHandler(
            IAccountService accountService,
            ILoanService loanService,
            ICustomerService customerService
            )
        {
            _accountService = accountService;
            _loanService = loanService;
            _customerService = customerService;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n1.Create Customer\n2.Create Account" +
                    "\n3.Deposit\n4.Withdraw\n5.Transfer\n6.ShowBalance" +
                    "\n7.Loan\n8.CalculateLoan\n9.GetLoanDetails\n10.Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: CreateCustomer(); break;
                    case 2: CreateAccount(); break;
                    case 3: Deposit(); break;
                    case 4: Withdraw(); break;
                    case 5: Transfer(); break;
                    case 6: ShowBalance(); break;
                    case 7: Loan(); break;
                    case 8: CalculateLoan(); break;
                    case 9: GetLoanDetails(); break;
                    case 10: return;
                    default: Console.WriteLine("Invalid"); break;
                }
            }
        }

        private void CreateCustomer()
        {
            Console.Write("Name: ");
            var customerName = Console.ReadLine();
            var customerId = _customerService.CreateCustomer(customerName);
            if(customerId != 0)
            {
              Console.WriteLine($"Customer ID: {customerId}");
            }
        }

        private void CreateAccount()
        {
            Console.Write("Customer ID: ");
            int customerId = Int16.Parse(Console.ReadLine());
            var customer = _customerService.GetCustomer(customerId);
            if(customer == null)
            {
                Console.WriteLine("Customer doesnot exist.");
                return;
            }
            var accountId = _accountService.CreateAccount(customerId);
            Console.WriteLine($"Account ID: {accountId}");
        }

        private void Deposit()
        {
            Console.Write("Account ID: ");
            int id = Int16.Parse(Console.ReadLine());
            Console.Write("Amount: ");
            _accountService.Deposit(id, decimal.Parse(Console.ReadLine()));
        }

        private void ShowBalance()
        {
            Console.Write("Account ID: ");
            int id = Int16.Parse(Console.ReadLine());
            _accountService.ShowBalance(id);
        }

        private void Withdraw()
        {
            Console.Write("Account ID: ");
            int id = Int16.Parse(Console.ReadLine());
            Console.Write("Amount: ");
            _accountService.Withdraw(id, decimal.Parse(Console.ReadLine()));
        }

        private void Transfer()
        {
            Console.Write("From Account ID: ");
            int fromId = Int16.Parse(Console.ReadLine());
            Console.Write("To Account ID: ");
            int toId = Int16.Parse(Console.ReadLine());
            Console.Write("Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            _accountService.Transfer(fromId, toId, amount);
        }

        private void Loan()
        {
            Console.Write("Customer ID: ");
            var customerId = Int16.Parse(Console.ReadLine());
            Console.Write("Principal: ");
            var principle = decimal.Parse(Console.ReadLine());
            Console.Write("Rate: ");
            var rateOfInterest = double.Parse(Console.ReadLine());
            Console.Write("Years: ");
            var totalYear = int.Parse(Console.ReadLine());
            _loanService.CreateLoan(customerId, principle, rateOfInterest, totalYear);
        }

        private void CalculateLoan()
        {
            Console.Write("Principal: ");
            var principle = decimal.Parse(Console.ReadLine());
            Console.Write("Rate: ");
            var rateOfInterest = double.Parse(Console.ReadLine());
            Console.Write("Years: ");
            var totalYear = int.Parse(Console.ReadLine());
            _loanService.CalculateLoan(principle, rateOfInterest, totalYear);
        }

        private void GetLoanDetails()
        {
            Console.Write("Loan ID: ");
            var loanId = int.Parse(Console.ReadLine());
             _loanService.GetLoan(loanId);
        }
    }

}
