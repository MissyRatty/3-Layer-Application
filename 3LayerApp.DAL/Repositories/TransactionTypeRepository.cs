using _3LayerApp.DAL.Entities;
using _3LayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace _3LayerApp.DAL.Repositories
{
    public class TransactionTypeRepository : IRepository<TransactionType>
    {
        private readonly BankDBEntities _dbContext;

        #region CRUD Helpers
        public TransactionTypeRepository(BankDBEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TransactionType item)
        {
            _dbContext.TransactionTypes.Add(item);
        }

        public void Delete(int id)
        {
            TransactionType transactionType = Get(id);
            if (transactionType != null)
                _dbContext.TransactionTypes.Remove(transactionType);
        }

        public void Edit(TransactionType item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<TransactionType> Find(Func<TransactionType, bool> predicate)
        {
            return _dbContext.TransactionTypes.Where(predicate).ToList();
        }

        public TransactionType Get(int id)
        {
            return _dbContext.TransactionTypes.Find(id);
        }

        public IEnumerable<TransactionType> GetAll()
        {
            return _dbContext.TransactionTypes;   
        }
        
        #endregion
    }
}
