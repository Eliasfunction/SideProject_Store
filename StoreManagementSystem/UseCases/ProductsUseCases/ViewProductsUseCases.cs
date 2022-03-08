using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewProductsUseCases : IViewProductsUseCases
    {
        private readonly IProductRepository productResponsitory;

        public ViewProductsUseCases(IProductRepository productResponsitory)
        {
            this.productResponsitory = productResponsitory;
        }

        public IEnumerable<Product> Excute()
        {
            return productResponsitory.GetProducts();
        }
    }
}
