using HPFCBank.Entities;
using HPFCBank.Repositories.Interfaces;
using System.Collections.Generic;
namespace HPFCBank.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<int, Customer> _customers = new Dictionary<int, Customer>();

        public void Save(Customer customer) => _customers[customer.Id] = customer;
        public Customer Get(int id) => _customers[id];
    }
}
