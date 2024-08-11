using System;

namespace SWAD_iCar
{
    public class Card : PaymentMethod
    {
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private int cardNo;

        public int CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        private int cvv;

        public int CVV
        {
            get { return cvv; }
            set { cvv = value; }
        }

        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        public Card() : base() { }

        public Card(string t, int cn, int cv, DateTime ed) : base()
        {
            Type = t;
            CardNo = cn;
            CVV = cv;
            ExpiryDate = ed;
        }
    }
}