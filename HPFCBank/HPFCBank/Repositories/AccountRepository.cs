using HPFCBank.Exceptions;
using HPFCBank.Models;
using System.Collections.Generic;

namespace HPFCBank.Repositories.Interfaces
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Dictionary<int, Account> _accounts = new Dictionary<int, Account>();

        public Account Get(int id)
        {
            if (!_accounts.ContainsKey(id))
            {
                throw new AccountNotFoundException(id);
            }

            return _accounts[id];
        }

        public void Save(Account account) => _accounts[account.Id] = account;
    }
}
