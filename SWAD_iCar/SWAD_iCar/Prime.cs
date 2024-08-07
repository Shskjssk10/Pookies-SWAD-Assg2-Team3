using System;
using System.Collections.Generic;

public class Prime : Renter
{
    // Constructor
    public Prime(int id, string name, string username, Card card, DateTime dateOfBirth, int contact, bool isVerified, string password, string email, List<Booking> bookingHistory, Admin isVerifiedBy, DigitalWallet wallet, License driversLicense)
        : base(id, name, username, card, dateOfBirth, contact, isVerified, password, email, bookingHistory, isVerifiedBy, wallet, driversLicense)
    {
        // Additional initialization for Prime renters can be added here.
    }
}
