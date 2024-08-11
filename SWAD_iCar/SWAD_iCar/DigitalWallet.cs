using System;
namespace SWAD_iCar
{
    public class DigitalWallet : PaymentMethod
    {
        private static int nextId = 1; // Static field to track the next ID
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private float balance;

        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public DigitalWallet() : base()
        {

        }
        public DigitalWallet(float b) : base() 
        {
            Id = nextId++;
            Balance = b;
        }

        public void AddFunds(float amount)
        {
            balance += amount;
        }

        public void RemoveFunds(float amount)
        {
            balance -= amount;
        }
    }
}