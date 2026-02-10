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
            if(name.Any(char.IsDigit))
            {
                Console.WriteLine("Customer name cannot contain numbers.");
                return 0;
            };
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
            catch (Exception)
            {
                return null;
            }
        }
    }

}
