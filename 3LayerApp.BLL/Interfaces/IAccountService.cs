using _3LayerApp.BLL.Dto;
using System.Collections.Generic;

namespace _3LayerApp.BLL.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<AccountDto> GetAccounts();
        AccountDto GetAccount(int id);
        void Dispose();
    }
}
