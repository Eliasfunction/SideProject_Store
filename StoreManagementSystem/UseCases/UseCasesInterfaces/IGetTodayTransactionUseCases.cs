using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IGetTodayTransactionUseCases
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}