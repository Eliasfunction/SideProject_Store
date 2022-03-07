using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewProductsUseCases
    {
        IEnumerable<Product> Excute();
    }
}