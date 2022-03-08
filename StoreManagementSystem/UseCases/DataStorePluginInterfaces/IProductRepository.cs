using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
     public interface IProductRepository
    {

        //CRUD 商品
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProductById(int ProductId);
        void DeleteProduct(int ProductId);
        //收銀台部份
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);

    }
}
