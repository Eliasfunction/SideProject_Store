using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetCategoryByIdUseCases : IGetCategoryByIdUseCases
    {
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryByIdUseCases(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Category Excute(int CategoryId)
        {
            return categoryRepository.GetCategoryById(CategoryId);
        }
    }
}
