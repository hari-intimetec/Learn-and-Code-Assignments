using HPFCBank.Exceptions;
using HPFCBank.Models;
using HPFCBank.Repositories.Interfaces;
using HPFCBank.Services.Interfaces;
using System;

namespace HPFCBank.Services
{
    public class AccountService : IAccountService
    {
        private int accountId = 1;
        private readonly IAccountRepository _accountRepo;

        public AccountService(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public int CreateAccount(int customerId)
        {
            var account = new Account(accountId, customerId);
            accountId += 1;
            _accountRepo.Save(account);
            return account.Id;
        }

        public void Deposit(int accountId, decimal amount)
        {
            try
            {
                var account = _accountRepo.Get(accountId);
                account.Deposit(amount);
                _accountRepo.Save(account);
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            try
            {
                var fromAccount = _accountRepo.Get(fromAccountId);
                var toAccount = _accountRepo.Get(toAccountId);
                bool isWithdrawn = fromAccount.Withdraw(amount);
                if (!isWithdrawn)
                {
                    Console.WriteLine("Transfer failed due to insufficient balance.");
                    return;
                }
                toAccount.Deposit(amount);
                _accountRepo.Save(fromAccount);
                _accountRepo.Save(toAccount);
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ShowBalance(int accountId)
        {
            try
            {
                var account = _accountRepo.Get(accountId);
                Console.WriteLine($"Current Balance: {account.Balance}");
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void Withdraw(int accountId, decimal amount)
        {
            try
            {
                var account = _accountRepo.Get(accountId);
                bool isWithdrawn = account.Withdraw(amount);
                if (!isWithdrawn)
                {
                    Console.WriteLine("Withdrawal failed due to insufficient balance.");
                    return;
                }
                _accountRepo.Save(account);
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
