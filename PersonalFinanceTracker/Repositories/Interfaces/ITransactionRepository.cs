using PersonalFinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Repositories.Interfaces
{
     public interface ITransactionRepository
    {
        public void Add(Transaction transaction);
        public List<Transaction> GetAll();
        public void Delete(Guid id);
    }
}
