using System;
using System.Reflection.Metadata.Ecma335;

public class Renter : User
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

    private string bookingHistory;
    public string BookingHistory
    {
        get { return bookingHistory; }
        set { bookingHistory = value; }
    }

    private bool isVerified;
    public bool IsVerified
    {
        get { return isVerified; }
        set { isVerified = value; }
    }

    private string password;
    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    private string email;
    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    private List<Booking> makes = new List<Booking>();
    public List<Booking> Makes
    {
        get { return makes; }
        set { makes = value; }
    }

    private Admin isVerifiedBy;
    public Admin IsVerifiedBy
    {
        get { return isVerifiedBy; }
        set { isVerifiedBy = value; }
    }

    private DigitalWallet has;
    public DigitalWallet Has
    {
        get { return has; }
        set { has = value; }
    }

    private License driversLicense;
    public License DriversLicense
    {
        get { return driversLicense; }
        set { driversLicense = value; }
    }


    // Constructor
    public Renter(int id, DateTime dateOfBirth, int contact, string bookingHistory, bool isVerified, string password, string email, List<Booking> makes, Admin isVerifiedBy, DigitalWallet has, License driversLicense)
    {
        this.id = id;
        this.dateOfBirth = dateOfBirth;
        this.contact = contact;
        this.bookingHistory = bookingHistory;
        this.isVerified = isVerified;
        this.password = password;
        this.email = email;
        this.makes = makes;
        this.isVerifiedBy = isVerifiedBy;
        this.has = has;
        this.driversLicense = driversLicense;
    }

    public void CheckAnyOngoingBooking(DateTime start, DateTime end)
    {
        throw new System.NotImplementedException("Not implemented");
    }

    public void CreateBooking(DateTime start, DateTime end, float bookingFee, Location pickUpMethod, Location returnMethod, Car car1)
    {
        throw new System.NotImplementedException("Not implemented");
    }

    public Transaction MakePayment(float bookingFee)
    {
        throw new System.NotImplementedException("Not implemented");
        // return Transaction
    }

    public Booking GetBooking()
    {
        throw new System.NotImplementedException("Not implemented");
        // return Booking
    }

    public Booking GetCurrentBooking()
    {
        throw new System.NotImplementedException("Not implemented");
        // return Booking
    }

    // ToString method
    public override string ToString()
    {
        return $"Renter ID: {Id}, Date of Birth: {DateOfBirth.ToShortDateString()}, Contact: {Contact}, " +
               $"Booking History: {BookingHistory}, Is Verified: {IsVerified}, Email: {Email}, " +
               $"Number of Bookings: {Makes.Count}, Verified By: {IsVerifiedBy}, Digital Wallet: {Has}, " +
               $"Driver's License: {DriversLicense}";
    }
}
