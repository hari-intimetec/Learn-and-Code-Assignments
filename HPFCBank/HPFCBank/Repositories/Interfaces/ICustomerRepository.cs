using HPFCBank.Models;
namespace HPFCBank.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        Customer Get(int id);
    }
}
