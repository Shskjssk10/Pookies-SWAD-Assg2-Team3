using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

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

        private Booking? currentBooking;
        public Booking? CurrentBooking
        {
            get { return currentBooking; }
            set { currentBooking = value; }
        }

        // Constructor
        public Renter(int id, string name, string username, Card card, DateTime dateOfBirth, int contact, string password, string email)
            : base(id, name, username, card)
        {
            this.dateOfBirth = dateOfBirth;
            this.contact = contact;
            this.password = password;
            this.email = email;
            BookingHistory = new List<Booking>();
        }

        public Renter(int id, string name, string username, Card card, DateTime dateOfBirth, int contact, bool isVerified, string password, string email, List<Booking> bookingHistory, Admin isVerifiedBy, DigitalWallet wallet, License driversLicense, Booking? currentBooking)
            : base(id, name, username, card)
        {
            DateOfBirth = dateOfBirth;
            Contact = contact;
            BookingHistory = bookingHistory;
            IsVerified = isVerified;
            Password = password;
            Email = email;
            IsVerifiedBy = isVerifiedBy;
            Wallet = wallet;
            DriversLicense = driversLicense;
            CurrentBooking = currentBooking;
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
            //random transaction id 
            Random rnd = new Random();
            int num = rnd.Next();

            //assume transaction will always be completed
            return new Transaction(bookingFee, DateTime.Now);
        }

        public Booking GetBooking(int bookingId)
        {
            Booking originalBookingData = bookingHistory.FirstOrDefault(b => b.Id == bookingId);
            return originalBookingData;
        }

        public Booking GetCurrentBooking()
        {
            return this.currentBooking;
            //throw new System.NotImplementedException("Not implemented");
            // return Booking
        }
        public void AddDriverLicense(License license)
        {
            DriversLicense = license;
        }


        public bool UpdateBooking()
        {
            Booking tempBooking = currentBooking;
            BookingHistory.Add(tempBooking);
            currentBooking = null;

            return true;
            //if (bookingHistory == tempBooking)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}


            //return true;
            //    throw new System.NotImplementedException("Not implemented");
            //    // return bool
        }

        // ToString method
        public override string ToString()
        {
            return $"Renter ID: {Id}, Name: {Name}, Username: {Username}, Date of Birth: {DateOfBirth.ToShortDateString()}, " +
                   $"Contact: {Contact}, Is Verified: {IsVerified}, Email: {Email}, " +
                   $"Number of Bookings: {BookingHistory.Count}, Verified By: {IsVerifiedBy?.Name ?? "N/A"}, " +
                   $"Digital Wallet Balance: {Wallet?.Balance ?? 0}, Driver's License: {DriversLicense.SerialNo}";
        }

    }
}