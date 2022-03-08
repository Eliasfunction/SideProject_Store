using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetTransactionUseCases : IGetTransactionUseCases
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTransactionUseCases(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(
            string cashieName, DateTime startDate, DateTime endDate)
        {
            return transactionRepository.Search(cashieName, startDate, endDate);
        }
    }
}
