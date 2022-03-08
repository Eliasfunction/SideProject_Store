namespace UseCases
{
    public interface ITransactionRecordUseCases
    {
        void Execute(string cashierName, int productId, int qt);
    }
}