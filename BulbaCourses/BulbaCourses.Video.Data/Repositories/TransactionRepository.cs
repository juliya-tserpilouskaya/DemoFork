using BulbaCourses.Video.Data.DatabaseContext;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Repositories
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

        public void Update(TransactionDb transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            videoDbContext.Entry(transaction).State = EntityState.Modified;
            videoDbContext.SaveChanges();

        }
    }
}
