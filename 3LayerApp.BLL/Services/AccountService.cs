using _3LayerApp.BLL.Dto;
using _3LayerApp.BLL.Interfaces;
using _3LayerApp.DAL.Entities;
using _3LayerApp.DAL.Interfaces;
using System.Collections.Generic;

namespace _3LayerApp.BLL.Services
{
    public class AccountService : IAccountService
    {
        IUnitOfWork Database { get; set; }

        public AccountService(IUnitOfWork database)
        {
            Database = database;
        }

        public AccountDto GetAccount(int id)
        {
            var account = Database.Accounts.Get(id);
            return Mapper(account);
        }

        public IEnumerable<AccountDto> GetAccounts()
        {
            var accounts = Database.Accounts.GetAll();
            return Mapper(accounts);
        }

        public static IEnumerable<AccountDto> Mapper(IEnumerable<Account> accounts)
        {
            var accountDtos = new List<AccountDto>();

            foreach (var item in accounts)
            {
                var accountDto = Mapper(item);
                accountDtos.Add(accountDto);
            }

            return accountDtos;
        }
        public static AccountDto Mapper(Account account)
        {
            return new AccountDto
            {
                AccountId = account.AccountId,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
