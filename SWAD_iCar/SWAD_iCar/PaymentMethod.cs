using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    public class PaymentMethod
    {
        public PaymentMethod()
        {
            Transactions = new List<Transaction>();
        }

        private List<Transaction> transactions;
        public List<Transaction> Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }

        public void AddNewTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

    }
}
