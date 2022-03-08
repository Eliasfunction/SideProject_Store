using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository: IProductRepository
    {
        private List<Product> products;

        public ProductInMemoryRepository()
        {
            //添加測試用 商品Product
            products = new List<Product>()
            {
                new Product{ ProductId=1,CategoryId = 1 , Name="黑松茶花綠茶",Quantity=100,Price= 20},
                new Product{ ProductId=2,CategoryId = 2 , Name="雪碧500ml",Quantity=200,Price= 25},
                new Product{ ProductId=3,CategoryId = 3 , Name="可口可樂800ml",Quantity=50,Price= 32},
                new Product{ ProductId=4,CategoryId = 3 , Name="泰山礦泉水650ml",Quantity=80,Price= 9}
            };
        }
        #region CRUD 商品
        public void AddProduct(Product product)
        {
            //略同Category
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
                return;

            if (products != null && products.Count > 0)//新ID
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else//如果未列出任何List 從1開始
            {
                product.ProductId = 1;
            }
            products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            var productToUpdate = products?.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (productToUpdate != null)
            {//new Product{ ProductId=1,CategoryId = 1 , Name="黑松茶花綠茶",Quantity=100,Price= 20},
                productToUpdate.CategoryId= product.CategoryId;
                productToUpdate.Name = product.Name;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;

            }
        }
        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(x => x.ProductId == productId);
            
        }
        public void DeleteProduct(int ProductId)
        {
            products?.Remove(GetProductById(ProductId));
        }
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        #endregion

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return products.Where(x => x.CategoryId == categoryId);
        }

    }
}
