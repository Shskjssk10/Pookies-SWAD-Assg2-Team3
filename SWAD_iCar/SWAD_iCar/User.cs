using System;
namespace SWAD_iCar
{
    public class User
    {
        private static int nextId = 1; // Static field to track the next ID
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private Card card;
        public Card Card
        {
            get { return card; }
            set { card = value; }
        }
        public User(string name, string username, Card card)
        {
            this.id = nextId++;
            this.name = name;
            this.username = username;
            this.card = card;
        }
        public User(int id, string name, string username, Card card)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.card = card;
        }
    }
}
