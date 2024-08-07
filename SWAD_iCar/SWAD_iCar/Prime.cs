using System;

public class Prime : Renter
{
    public Prime(int id, DateTime dateOfBirth, int contact, string bookingHistory, bool isVerified, string password, string email, Booking[] makes, Admin isVerifiedBy, DigitalWallet has)
        : base(id, dateOfBirth, contact, bookingHistory, isVerified, password, email, makes, isVerifiedBy, has)
    {
        // Additional initialization for Prime renters can be added here.
    }
}
