using BulbaCourse.Video.Data.DatabaseContex;
using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly VideoDbContext videoDbContext;

        public TransactionRepository(VideoDbContext videoDbContext)
        {
            this.videoDbContext = videoDbContext;
        }
        public void Add(TransactionDb transaction)
        {
            videoDbContext.Transactions.Add(transaction);
            videoDbContext.SaveChanges();
        }

        public IEnumerable<TransactionDb> GetAll()
        {
            var transactionList = videoDbContext.Transactions.ToList().AsReadOnly();
            return transactionList;
        }

        public TransactionDb GetById(string transactionlId)
        {
            var transaction = videoDbContext.Transactions.FirstOrDefault(b => b.TransactionId.Equals(transactionlId));
            return transaction;
        }

        public void Remove(TransactionDb transaction)
        {
            videoDbContext.Transactions.Remove(transaction);
            videoDbContext.SaveChanges();
        }

        public void RemoveById(string transactionId)
        {
            var delTransaction = videoDbContext.Transactions.FirstOrDefault(b => b.TransactionId.Equals(transactionId));
            Remove(delTransaction);
        }

        public void Update(TransactionDb transaction)
        {
            videoDbContext.Entry(transaction).State = EntityState.Modified;
            videoDbContext.SaveChanges();
        }
    }
}
