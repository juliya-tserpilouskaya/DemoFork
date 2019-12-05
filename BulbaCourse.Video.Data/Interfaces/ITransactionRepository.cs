using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Interfaces
{
    public interface ITransactionRepository
    {
        TransactionDb GetById(string transactionlId);
        IEnumerable<TransactionDb> GetAll();
        void Add(TransactionDb transaction);
        void Update(TransactionDb transaction);
        void RemoveById(string transactionId);
        void Remove(TransactionDb transaction);
    }
}
