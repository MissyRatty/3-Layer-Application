using _3LayerApp.BLL.Dto;
using _3LayerApp.BLL.Interfaces;
using _3LayerApp.DAL.Entities;
using _3LayerApp.DAL.Interfaces;
using System.Collections.Generic;

namespace _3LayerApp.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        IUnitOfWork Database { get; set; }
        

        public TransactionService(IUnitOfWork database)
        {
            Database = database;
        }

        public TransactionDto GetTransaction(int id)
        {
            var transaction = Database.Transactions.Get(id);
            return Mapper(transaction);
        }

        public IEnumerable<TransactionDto> GetTransactions()
        {
            var transactions = Database.Transactions.GetAll();
            return Mapper(transactions);
        }

        public int MakeTransaction(TransactionDto transaction)
        {
            var accBalance = GetAccountBalance(transaction.TransactionTypeName, transaction.Amount, transaction.Balance);
            transaction.Balance = accBalance;

            var addTransaction = Mapper(transaction);

            Database.Transactions.Add(addTransaction);
            Database.Save();

            return addTransaction.TransactionId;
        }


        #region Helper Methods
        public static IEnumerable<TransactionDto> Mapper(IEnumerable<Transaction> transactions)
        {
            var transactionDtos = new List<TransactionDto>();

            foreach (var item in transactions)
            {
                var transactionDto = Mapper(item);
                transactionDtos.Add(transactionDto);
            }

            return transactionDtos;
        }
        public static TransactionDto Mapper(Transaction transaction)
        {
            return new TransactionDto
            {
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                TransactionTypeId = transaction.TransactionTypeId,
                TransactionTypeName = transaction.TransactionType.TransactionType1,
                AccountId = transaction.AccountId,
                AccountNumber = transaction.Account.AccountNumber,
                Balance = transaction.Account.Balance
            };
        }

        public static Transaction Mapper(TransactionDto transactionDto)
        {
            return new Transaction
            {
                Amount = transactionDto.Amount,
                TransactionTypeId = transactionDto.TransactionTypeId,
                TransactionType = new TransactionType
                {
                    TransactionTypeId = transactionDto.TransactionTypeId,
                    TransactionType1 = transactionDto.TransactionTypeName
                },
                AccountId = transactionDto.AccountId,
                Account = new Account
                {
                    AccountId = transactionDto.AccountId,
                    AccountNumber = transactionDto.AccountNumber,
                    Balance = transactionDto.Balance
                }
            };
        }

        public decimal Deposit(decimal depositAmount, decimal accountBalance)
        {
            return (accountBalance + depositAmount);
        }

        public decimal Withdraw(decimal withdrawAmount, decimal accoutBalance)
        {
            if (withdrawAmount < accoutBalance)
            {
                return (accoutBalance - withdrawAmount);
            }

            return accoutBalance;
        }

        public decimal GetAccountBalance(string transactionType, decimal amount, decimal balance)
        {
            decimal newBalance = 0;

            switch (transactionType)
            {
                case "Deposit":
                    {
                        newBalance = Deposit(amount, balance);
                    }
                    break;

                case "Withdraw":
                    {
                        newBalance = Withdraw(amount, balance);
                    }
                    break;

                default: break;

            }

            return newBalance;
        }

        #endregion


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
