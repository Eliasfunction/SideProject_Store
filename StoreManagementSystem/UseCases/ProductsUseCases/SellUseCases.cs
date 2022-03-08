using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class SellUseCases : ISellUseCases
    {
        private readonly IProductRepository productRepository;
        private readonly ITransactionRecordUseCases transactionRecordUseCases;

        public SellUseCases(IProductRepository productRepository, ITransactionRecordUseCases transactionRecordUseCases)
        {
            this.productRepository = productRepository;
            this.transactionRecordUseCases = transactionRecordUseCases;
        }

        public ITransactionRecordUseCases TransactionRecordUseCases { get; }

        public void Execute(string cashierName, int productId, int qtToSell)
        {
            var product = productRepository.GetProductById(productId);
            if (product == null) return;

            transactionRecordUseCases.Execute(cashierName, productId, qtToSell);
            product.Quantity -= qtToSell;
            productRepository.UpdateProduct(product);
        }
    }
}
