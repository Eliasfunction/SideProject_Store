using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    //此處資料只用來做前期測試 尚未入資料庫
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;
        public CategoryInMemoryRepository()
        {
            //添加測試用 類別Category
            categories = new List<Category>()
            {
                new Category{ CategoryId = 1 , Name="飲料",Description="飲料"},
                new Category{ CategoryId = 2 , Name="食品",Description="食品"},
                new Category{ CategoryId = 3 , Name="乳製品",Description="乳製品"},
                new Category{ CategoryId = 4 , Name="衛生紙",Description="衛生紙"}
            };
        }
        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
                return;
            var maxId = categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            categories.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = categories?.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description=category.Description;

            }
        }
        public Category GetCategoryById(int CategoryId)
        {
            var categoryid = categories?.FirstOrDefault(x => x.CategoryId == CategoryId);
            return categoryid;

        }
        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        
    }
}
