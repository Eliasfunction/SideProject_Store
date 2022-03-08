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

        public SellUseCases(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Execute(int productId, int qtToSell)
        {
            var product = productRepository.GetProductById(productId);
            if (product == null) return;
            product.Quantity -= qtToSell;
            productRepository.UpdateProduct(product);
        }
    }
}
