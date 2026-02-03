using HPFCBank.Entities;
using HPFCBank.Repositories.Interfaces;
using System.Collections.Generic;
namespace HPFCBank.Repositories
{
    public class InMemoryLoanRepository : ILoanRepository
    {
        private readonly Dictionary<int, Loan> _loans = new Dictionary<int, Loan>();

        public void Save(Loan loan) => _loans[loan.Id] = loan;
        public Loan Get(int id) => _loans[id];
    }
}
