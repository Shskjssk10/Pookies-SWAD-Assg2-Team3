using System;

public class Regular : Renter
{
    public Regular(int id, DateTime dateOfBirth, int contact, string bookingHistory, bool isVerified, string password, string email, Booking[] makes, Admin isVerifiedBy, DigitalWallet has)
        : base(id, dateOfBirth, contact, bookingHistory, isVerified, password, email, makes, isVerifiedBy, has)
    {
        // Additional initialization for Regular renters can be added here.
    }

}
