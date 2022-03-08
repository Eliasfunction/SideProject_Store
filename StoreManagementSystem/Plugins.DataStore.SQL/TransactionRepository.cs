using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionRepository(MarketContext db)
        {
            this.db = db;
        }
        public IEnumerable<Transaction> Get(string cashierName)
        {
                return db.Transactions;
            
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return db.Transactions.Where(x =>
                x.CashierName.ToLower()==cashierName.ToLower() &&
                x.TimeStamp.Date == date.Date
                );
        }

        public void Save(string cashierName, int productId, string proudctName, double price, int deforeqt, int soldqt)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = proudctName,
                TimeStamp = DateTime.Now,
                Price = price,
                Beforeqt = deforeqt,
                Soldqt = soldqt,
                CashierName = cashierName
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return db.Transactions.Where(x => x.TimeStamp.Date >= startDate && x.TimeStamp <= endDate.AddDays(1).Date);
            else
                return db.Transactions.Where(x =>
                x.CashierName.ToLower() == cashierName.ToLower() &&
                x.TimeStamp.Date >= startDate && x.TimeStamp <= endDate.AddDays(1).Date
                );
        }
    }
}
