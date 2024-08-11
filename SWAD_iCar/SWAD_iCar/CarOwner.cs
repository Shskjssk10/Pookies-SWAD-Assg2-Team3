using SWAD_iCar;
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

        private List<Car> registeredCars = new List<Car>();

        public CarOwner(int id, string name, string username, Card card, DateTime dob, int contact) : base(id, name, username, card)
        {
            dateOfBirth = dob;
            this.contact = contact;
        }

        public bool LinkCarToCarOwner(Car car)
        {
            registeredCars.Add(car);
            return true;
        }

        public bool RemoveCarFromCarOwner(Car car)
        {
            registeredCars.Remove(car);
            return true;
        }

        public List<Car> getAllRegisteredCars()
        {
            return registeredCars;
        }
    }
}