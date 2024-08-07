using System;

public class Regular : Renter
{
    public Regular(int id, string name, string username, Card card, DateTime dateOfBirth, int contact, string bookingHistory, bool isVerified, string password, string email)
        : base(id, name, username, card, dateOfBirth, contact, bookingHistory, isVerified, password, email)
    {
        // Additional initialization for Regular renters can be added here.
    }

}
