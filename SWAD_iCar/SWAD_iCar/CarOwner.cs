using System;
namespace SWAD_iCar
{
    public class CarOwner : User
    {
        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private int contact;

        public int Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public CarOwner(int id, string name, string username, Card card, DateTime dob, int contact) : base(id, name, username, card)
        {
            dateOfBirth = dob;
            this.contact = contact;
        }
    }
}