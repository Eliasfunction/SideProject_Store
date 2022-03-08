using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class TransactionRecordUseCases : ITransactionRecordUseCases
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetProductByIdUseCases getProductByIdUseCases;

        public TransactionRecordUseCases(ITransactionRepository transactionRepository, IGetProductByIdUseCases getProductByIdUseCases)
        {
            this.transactionRepository = transactionRepository;
            this.getProductByIdUseCases = getProductByIdUseCases;
        }

        public void Execute(string cashierName, int productId, int qt)
        {
            var product = getProductByIdUseCases.Excute(productId);
            transactionRepository.Save(cashierName, productId, product.Name, product.Price.Value, product.Quantity.Value, qt);
        }
    }
}
