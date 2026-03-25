using HPFCBank.Exceptions;
using HPFCBank.Models;
using HPFCBank.Repositories.Interfaces;
using HPFCBank.Services.Interfaces;
using System;
using System.Linq;

namespace HPFCBank.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private static int _nextCustomerId = 1;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public int CreateCustomer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidCustomerNameException(name, "Customer name cannot be null or empty.");
            }

            if (name.Any(char.IsDigit))
            {
                throw new InvalidCustomerNameException(name);
            }

            Customer customer = new Customer(_nextCustomerId, name);
            _nextCustomerId++;
            _customerRepository.Save(customer);
            return customer.Id;
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                return _customerRepository.Get(id);
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new Customer(0, string.Empty);
            }
        }
    }
}
