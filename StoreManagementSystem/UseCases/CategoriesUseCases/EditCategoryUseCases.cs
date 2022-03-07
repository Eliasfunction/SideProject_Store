using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class EditCategoryUseCases : IEditCategoryUseCases
    {
        private readonly ICategoryRepository categoryRepository;

        public EditCategoryUseCases(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void Execute(Category category)
        {
            categoryRepository.UpdateCategory(category);
        }
    }
}
