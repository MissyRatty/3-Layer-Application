using _3LayerApp.DAL.Entities;
using _3LayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace _3LayerApp.DAL.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly BankDBEntities _dbContext;

        public TransactionRepository(BankDBEntities dbContext)
        {
            _dbContext = dbContext;
        }

        #region CRUD Helpers
        public void Add(Transaction item)
        {
            _dbContext.Transactions.Add(item);
        }

        public void Delete(int id)
        {
            Transaction transaction = Get(id);
            if (transaction != null)
                _dbContext.Transactions.Remove(transaction);
        }

        public void Edit(Transaction item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Transaction> Find(Func<Transaction, bool> predicate)
        {
            return _dbContext.Transactions.Where(predicate).ToList();
        }

        public Transaction Get(int id)
        {
            return _dbContext.Transactions.Find(id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _dbContext.Transactions;
        }

        #endregion


    }
}
