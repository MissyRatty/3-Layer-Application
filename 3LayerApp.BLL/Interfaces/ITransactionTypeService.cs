using _3LayerApp.BLL.Dto;
using System.Collections.Generic;

namespace _3LayerApp.BLL.Interfaces
{
    public interface ITransactionTypeService
    {
        IEnumerable<TransactionTypeDto> GetTransactionTypes();
        TransactionTypeDto GetTransactionType(int id);
        void Dispose();
    }
}
