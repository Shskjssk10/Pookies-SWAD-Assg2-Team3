using System;
namespace SWAD_iCar
{
    public class Admin : User
    {


    public Admin(int id, string name, string username, Card card, List<Booking> booking, List<Renter> renter, List<Report> report)
        : base(id, name, username, card)
    {
        this.Booking = booking;
        this.Renter = renter;
        this.Report = report;
    }


    public float UpdateInspectionStatus()
    {
        //DUMMY DATA FOR DAMAGES FEE

        // Create a random number generator
        Random random = new Random();

        // Generate a random boolean (50% chance true or false)
        bool isNoDamage = random.Next(2) == 0; // random.Next(2) generates either 0 or 1

        if (isNoDamage)
        {
            //Console.WriteLine("Calls the update inspection status use case: No damages.");
            return 0;
        }
        else
        {
            // Generate a random number between 100 and 500
            float damageCost = random.Next(100, 501); // random.Next(minValue, maxValue) returns a number >= minValue and < maxValue
            //Console.WriteLine($"Calls the update inspection status use case: Damage cost is {damageCost}.");
            return damageCost;
        }
    }
}
