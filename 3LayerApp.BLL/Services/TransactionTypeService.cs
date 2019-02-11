using _3LayerApp.BLL.Dto;
using _3LayerApp.BLL.Interfaces;
using _3LayerApp.DAL.Entities;
using _3LayerApp.DAL.Interfaces;
using System.Collections.Generic;

namespace _3LayerApp.BLL.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        IUnitOfWork Database { get; set; }
        public TransactionTypeService(IUnitOfWork database)
        {
            Database = database;
        }
        public TransactionTypeDto GetTransactionType(int id)
        {
            var transactionType = Database.TransactionTypes.Get(id);
            return Mapper(transactionType);
        }
        public IEnumerable<TransactionTypeDto> GetTransactionTypes()
        {
            var transactionTypes = Database.TransactionTypes.GetAll();
            return Mapper(transactionTypes);
        }
        public static IEnumerable<TransactionTypeDto> Mapper(IEnumerable<TransactionType> transactionTypes)
        {
            var transactionTypeDtos = new List<TransactionTypeDto>();

            foreach (var item in transactionTypes)
            {
                var transactionTypeDto = Mapper(item);
                transactionTypeDtos.Add(transactionTypeDto);
            }

            return transactionTypeDtos;
        }
        public static TransactionTypeDto Mapper(TransactionType transactionType)
        {
            return new TransactionTypeDto
            {
                TransactionTypeId = transactionType.TransactionTypeId,
                TransactionTypeName = transactionType.TransactionType1
            };
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
