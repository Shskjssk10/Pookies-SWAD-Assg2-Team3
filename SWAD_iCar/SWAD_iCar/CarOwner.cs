using System;
using System.Collections.Generic;
using System.Dynamic;

public class CarOwner : User
{
    private DateTime dateOfBirth;
    private int contact;
    private List<Car> cars; // List to store cars

    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    public int Contact
    {
        get { return contact; }
        set { contact = value; }
    }

    public CarOwner(int id, string name, string username, Card card, DateTime dob, int contact)
        : base(id, name, username, card)
    {
        dateOfBirth = dob;
        this.contact = contact;
        cars = new List<Car>(); // Initialize the list
    }
    public void AddNewCar(Car car)
    {
        if (car == null)
        {
            throw new ArgumentNullException(nameof(car), "Car cannot be null");
        }
        cars.Add(car);
    }

    //method to get all cars owned by this CarOwner
    public List<Car> GetCars()
    {
        return cars;
    }

    public override string ToString()
    {
        return $"ID: {Id}, " +
           $"Name: {Name}, " +
           $"Username: {Username}, " +
           $"Date of Birth: {DateOfBirth.ToShortDateString()}, " +
           $"Contact: {Contact}";
    }
}
