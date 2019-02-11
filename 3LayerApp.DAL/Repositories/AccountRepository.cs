using _3LayerApp.DAL.Entities;
using _3LayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace _3LayerApp.DAL.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private BankDBEntities _dbContext;

        public AccountRepository(BankDBEntities dbContext)
        {
            _dbContext = dbContext;
        }

        #region CRUD Helpers
        public IEnumerable<Account> GetAll()
        {
            return _dbContext.Accounts;
        }

        public Account Get(int id)
        {
            return _dbContext.Accounts.Find(id);
        }

        public IEnumerable<Account> Find(Func<Account, bool> predicate)
        {
            return _dbContext.Accounts.Where(predicate).ToList();
        }

        public void Add(Account item)
        {
            _dbContext.Accounts.Add(item);
        }

        public void Edit(Account item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Account account = Get(id);
            if (account != null)
                _dbContext.Accounts.Remove(account);
        }

        #endregion
    }
}
