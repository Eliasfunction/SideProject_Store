using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;


namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions;
        public TransactionInMemoryRepository()
        {
            transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return transactions.Where(x => 
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
                x.TimeStamp.Date == date.Date
                );
        }
        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions;
            else
                return transactions.Where(x => string.Equals(x.CashierName, cashierName ,StringComparison.OrdinalIgnoreCase));
        }

        public void Save(string cashierName, int productId,string productName, double price, int deforeqt,int soldqt)
        {
            int transactionId = 0;
            if (transactions !=null && transactions.Count > 0){
                int MaxId = transactions.Max(x => x.TransactionId);
                transactionId = MaxId + 1;
            }
            else
            {
                transactionId = 1;
            }
            transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                ProductName =productName,
                TimeStamp = DateTime.Now,
                Price = price,
                Beforeqt =deforeqt,
                Soldqt = soldqt,
                CashierName = cashierName
            });
        }
    }
}
