using HPFCBank.Entities;
namespace HPFCBank.Services.Interfaces
{
    public interface ICustomerService
    {
        int CreateCustomer(string name);
        Customer GetCustomer(int id);
    }
}
