using HPFCBank.Entities;
namespace HPFCBank.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        void Save(Loan loan);
        Loan Get(int id);
    }

}
