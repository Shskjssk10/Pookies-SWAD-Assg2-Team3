using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace SWAD_iCar
{
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
        public Renter(int id, string name, string username, Card card, DateTime dateOfBirth, int contact, bool isVerified, string password, string email, List<Booking> bookingHistory, Admin isVerifiedBy, DigitalWallet wallet, License driversLicense)
            : base(id, name, username, card)
        {
            this.dateOfBirth = dateOfBirth;
            this.contact = contact;
            this.bookingHistory = bookingHistory;
            this.isVerified = isVerified;
            this.password = password;
            this.email = email;
            this.isVerifiedBy = isVerifiedBy;
            this.wallet = wallet;
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

        public Booking GetBooking(int bookingId)
        {
            Booking booking1 = bookingHistory.FirstOrDefault(b => b.Id == bookingId);
            return booking1;
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
                   $"Is Verified: {IsVerified}, Email: {Email}, " +
                   $"Number of Bookings: {bookingHistory.Count}, Verified By: {IsVerifiedBy}, Digital Wallet: {Wallet}, " +
                   $"Driver's License: {DriversLicense}";
        }
    }
}