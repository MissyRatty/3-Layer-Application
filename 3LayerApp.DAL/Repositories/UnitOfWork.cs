using _3LayerApp.DAL.Entities;
using _3LayerApp.DAL.Interfaces;
using System;

namespace _3LayerApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private BankDBEntities _dbContext;
        private AccountRepository _accountRepository;
        private TransactionTypeRepository _transactionTypeRepository;
        private TransactionRepository _transactionRepository;

        public UnitOfWork(string connectionString)
        {
            _dbContext = new BankDBEntities(connectionString);
        }


        #region Helper Methods
        public IRepository<Account> Accounts
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_dbContext);
                return _accountRepository;
            }
        }

        public IRepository<TransactionType> TransactionTypes
        {
            get
            {
                if (_transactionTypeRepository == null)
                    _transactionTypeRepository = new TransactionTypeRepository(_dbContext);
                return _transactionTypeRepository;
            }
        }

        public IRepository<Transaction> Transactions
        {
            get
            {
                if (_transactionRepository == null)
                    _transactionRepository = new TransactionRepository(_dbContext);
                return _transactionRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #endregion

        #region Dispose

        //check class state to see if its disposed or not
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);

            //reclaiming unused memory
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
