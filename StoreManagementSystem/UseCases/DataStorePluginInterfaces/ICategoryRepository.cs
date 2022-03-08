using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        //CRUD 種類
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        Category GetCategoryById(int CategoryId);
        void DeleteCategory(int CategoryId);
    }
}
