using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteProductUseCases : IDeleteProductUseCases
    {
        private readonly IProductRepository productRepository;

        public DeleteProductUseCases(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Delete(int productId)
        {
            productRepository.DeleteProduct(productId);
        }
    }
}
