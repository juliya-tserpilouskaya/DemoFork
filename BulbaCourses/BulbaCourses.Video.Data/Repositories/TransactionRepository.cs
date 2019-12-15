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
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {

        public TransactionRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        public void Add(TransactionDb transaction)
        {
            _videoDbContext.Transactions.Add(transaction);
            _videoDbContext.SaveChanges();

        }

        public IEnumerable<TransactionDb> GetAll()
        {
            var transactionList = _videoDbContext.Transactions.ToList().AsReadOnly();
            return transactionList;

        }

        public TransactionDb GetById(string transactionlId)
        {
            var transaction = _videoDbContext.Transactions.FirstOrDefault(b => b.TransactionId.Equals(transactionlId));
            return transaction;

        }

        public void Remove(TransactionDb transaction)
        {
            _videoDbContext.Transactions.Remove(transaction);
            _videoDbContext.SaveChanges();

        }

        public void Update(TransactionDb transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            _videoDbContext.Entry(transaction).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }
    }
}
