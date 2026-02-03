using HPFCBank.Entities;
using HPFCBank.Repositories.Interfaces;
using HPFCBank.Services.Interfaces;
using System;
namespace HPFCBank.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ICustomerRepository _customerRepository;
        private static int _nextLoanId = 1;

        public LoanService(
            ILoanRepository loanRepository,
            ICustomerRepository customerRepository)
        {
            _loanRepository = loanRepository;
            _customerRepository = customerRepository;
        }

        public void CreateLoan(int customerId, decimal principal, double rate, int years)
        {
            try
            {
                var customer = _customerRepository.Get(customerId);
                var loan = new Loan(
                    _nextLoanId,
                    customerId,
                    principal,
                    rate,
                    years
                );
                _nextLoanId += 1;
                _loanRepository.Save(loan);
                Console.WriteLine("Loan created successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Customer not found");
            }
        }

        public void GetLoan(int loanId)
        {
            try
            {
                Loan loan=_loanRepository.Get(loanId);
                Console.WriteLine($"Loan ID: {loan.Id}, Customer ID: {loan.CustomerId}, Principal: {loan.Principal}, interest rate: {loan.InterestRate}, Time Period: {loan.DurationInYears}");
            }
            catch (Exception)
            {
                Console.WriteLine("Loan Id doesnot exist.");
            }
            return;

        }
        public void CalculateLoan(decimal principal, double rate, int years)
        {
            var totalAmount= principal + (principal * (decimal)rate * years);
            Console.WriteLine($"Total amount to be paid: {totalAmount}");
        }
    }

}
