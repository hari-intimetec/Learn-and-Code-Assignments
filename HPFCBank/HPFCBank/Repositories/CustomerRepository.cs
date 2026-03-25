using HPFCBank.Exceptions;
using HPFCBank.Models;
using HPFCBank.Repositories.Interfaces;
using System.Collections.Generic;

namespace HPFCBank.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<int, Customer> _customers = new Dictionary<int, Customer>();

        public void Save(Customer customer) => _customers[customer.Id] = customer;

        public Customer Get(int id)
        {
            if (!_customers.ContainsKey(id))
            {
                throw new CustomerNotFoundException(id);
            }

            return _customers[id];
        }
    }
}
