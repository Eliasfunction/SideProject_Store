using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddProductUseCases : IAddProductUseCases
    {
        private readonly IProductRepository productRepository;

        public AddProductUseCases(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Excute(Product product)
        {
            productRepository.AddProduct(product);

        }
    }
}
