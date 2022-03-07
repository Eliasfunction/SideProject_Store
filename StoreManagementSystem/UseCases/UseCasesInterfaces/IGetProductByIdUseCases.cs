using CoreBusiness;

namespace UseCases
{
    public interface IGetProductByIdUseCases
    {
        Product Excute(int ProductId);
    }
}