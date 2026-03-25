using System;
namespace HPFCBank.Models
{
    public class Account
    {
        public int Id { get; }
        public int CustomerId { get; }
        public decimal Balance { get; protected set; }

        public Account(int id, int customerId)
        {
            Id = id;
            CustomerId = customerId;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) 
            Console.WriteLine("Invalid deposit amount");
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0) 
                Console.WriteLine("Invalid withdrawal amount");
            if (amount > Balance) 
                Console.WriteLine("Insufficient funds");

            Balance -= amount;
            return true;
        }
    }
}
