namespace UseCases
{
    public interface ISellUseCases
    {
        void Execute(string cashierName, int productId, int qtToSell);
    }
}