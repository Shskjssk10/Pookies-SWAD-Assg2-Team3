using System;
namespace SWAD_iCar
{
    public class Transaction
    {
        private static int nextId = 1; // Static field to track the next ID
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private float cost;

        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public Transaction() { }

        public Transaction(float c, DateTime t)
        {
            Id = nextId++; // Assign the current ID and increment the counter
            Cost = c;
            Time = t;
        }
    }
}
