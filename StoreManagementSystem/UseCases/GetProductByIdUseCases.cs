using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetProductByIdUseCases : IGetProductByIdUseCases
    {
        private readonly IProductRepository productRepository;

        public GetProductByIdUseCases(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Excute(int ProductId)
        {
            return productRepository.GetProductById(ProductId);
        }


    }
}
