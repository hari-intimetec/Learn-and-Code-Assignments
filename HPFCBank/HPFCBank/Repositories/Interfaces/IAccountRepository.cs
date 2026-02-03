using HPFCBank.Entities;
namespace HPFCBank.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Account Get(int id);
        void Save(Account account);
    }
}
