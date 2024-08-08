using System;
using System.Collections.Generic;

public class Regular : Renter
{
    // Constructor
    public Regular(int id, string name, string username, Card card, DateTime dateOfBirth, int contact, bool isVerified, string password, string email, List<Booking> bookingHistory, Admin isVerifiedBy, DigitalWallet wallet, License driversLicense, Booking currentBooking)
        : base(id, name, username, card, dateOfBirth, contact, isVerified, password, email, bookingHistory, isVerifiedBy, wallet, driversLicense, currentBooking)
    {
        // Additional initialization for Regular renters can be added here.
    }
}

