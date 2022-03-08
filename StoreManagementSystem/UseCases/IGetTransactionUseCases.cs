using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases
{
    public interface IGetTransactionUseCases
    {
        IEnumerable<Transaction> Execute(string cashieName, DateTime startDate, DateTime endDate);
    }
}