using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddCategoryUseCases : IAddCategoryUseCases
    {
        private readonly ICategoryRepository categoryRepository;
        public AddCategoryUseCases(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void Excute(Category category)
        {
            categoryRepository.AddCategory(category);
        }
    }
}
