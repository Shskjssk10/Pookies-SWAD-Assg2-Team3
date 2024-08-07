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

    private List<Booking> bookingHistory = new List<Booking>();
    public List<Booking> BookingHistory
    {
        get { return bookingHistory; }
        set { bookingHistory = value; }
    }

    private Admin isVerifiedBy;
    public Admin IsVerifiedBy
    {
        get { return isVerifiedBy; }
        set { isVerifiedBy = value; }
    }

    private DigitalWallet wallet;
    public DigitalWallet Wallet
    {
        get { return wallet; }
        set { wallet = value; }
    }

    private License driversLicense;
    public License DriversLicense
    {
        get { return driversLicense; }
        set { driversLicense = value; }
    }


    // Constructor
    public Renter(string name, string username, Card card, DateTime dateOfBirth, int contact, string password, string email)
        : base(name, username, card)
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


    public bool CheckAnyOngoingBooking(DateTime start, DateTime end)
    {
        foreach (Booking booking in bookingHistory)
        {
            // at least one already booked timeslot is within the start and end date
            if ((booking.StartDateTime > start && booking.StartDateTime < end) || (booking.EndDateTime > start && booking.EndDateTime < end))
            {
                return true;
            }
        }
        return false;
    }

    public Booking CreateBooking(DateTime start, DateTime end, float bookingFee, Location pickUpMethod, Location returnMethod, Car car1)
    {
        string bookingStatus = "Booked";
        Booking newBooking = new Booking(start, end, returnMethod, pickUpMethod, bookingFee, bookingStatus, car1);
        BookingHistory.Add(newBooking);
        return newBooking;
    }

    public Transaction MakePayment(float bookingFee)
    {
        // assume payment was successful, supposed to call a make payment controller
        // assume payment went through at this moment
        DateTime paymentTime = DateTime.Now;
        Transaction transaction = new Transaction(bookingFee, paymentTime);
        return transaction;
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
    public void AddDriverLicense(License license)
    {
        DriversLicense = license;
    }


    // ToString method
    public override string ToString()
               $"Booking History: {BookingHistory}, Is Verified: {IsVerified}, Email: {Email}, " +
               $"Number of Bookings: {BookingHistory}, Verified By: {IsVerifiedBy}, Digital Wallet: {Wallet}, " +
               $"Booking History: {BookingHistory}, Is Verified: {IsVerified}, Email: {Email}, " +
               $"Number of Bookings: {Makes.Count}, Verified By: {IsVerifiedBy}, Digital Wallet: {Has}, " +
               $"Driver's License: {DriversLicense}";
    }
}
