using HPFCBank.Entities;
using HPFCBank.Repositories.Interfaces;
using HPFCBank.Services.Interfaces;
using System;
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
