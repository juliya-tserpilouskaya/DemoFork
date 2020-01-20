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

        public async Task<TransactionDb> AddAsync(TransactionDb transaction)
        {
            _videoDbContext.Transactions.Add(transaction);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(transaction);
        }

        public IEnumerable<TransactionDb> GetAll()
        {
            var transactionList = _videoDbContext.Transactions.ToList().AsReadOnly();
            return transactionList;

        }

        public async Task<IEnumerable<TransactionDb>> GetAllAsync()
        {
            var transactionList = await _videoDbContext.Transactions.ToListAsync().ConfigureAwait(false);
            return transactionList.AsReadOnly();
        }

        public TransactionDb GetById(string transactionlId)
        {
            var transaction = _videoDbContext.Transactions.FirstOrDefault(b => b.TransactionId.Equals(transactionlId));
            return transaction;

        }

        public async Task<TransactionDb> GetByIdAsync(string transactionlId)
        {
            var transaction = await _videoDbContext.Transactions.SingleOrDefaultAsync(b => b.TransactionId.Equals(transactionlId)).ConfigureAwait(false);
            return transaction;
        }

        public void Remove(TransactionDb transaction)
        {
            _videoDbContext.Transactions.Remove(transaction);
            _videoDbContext.SaveChanges();

        }

        public async Task RemoveAsync(TransactionDb transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            _videoDbContext.Transactions.Remove(transaction);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task RemoveAsyncById(string transactionlId)
        {
            var transaction = _videoDbContext.Transactions.SingleOrDefault(b => b.TransactionId.Equals(transactionlId));
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            _videoDbContext.Transactions.Remove(transaction);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
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

        public async Task<TransactionDb> UpdateAsync(TransactionDb transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            _videoDbContext.Entry(transaction).State = EntityState.Modified;
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(transaction);
        }
    }
}
