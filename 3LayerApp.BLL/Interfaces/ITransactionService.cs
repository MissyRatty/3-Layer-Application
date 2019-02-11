using _3LayerApp.BLL.Dto;
using System.Collections.Generic;

namespace _3LayerApp.BLL.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<TransactionDto> GetTransactions();
        TransactionDto GetTransaction(int id);
        int MakeTransaction(TransactionDto transaction);
        void Dispose();
    }
}
