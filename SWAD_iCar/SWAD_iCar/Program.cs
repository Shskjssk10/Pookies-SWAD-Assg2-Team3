using System;
using System.Collections.Generic;

namespace SWAD_iCar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create some dummy data

            // Cards
            var card1 = new Card("Visa", 123456789, 123, new DateTime(2025, 12, 31));
            var card2 = new Card("MasterCard", 987654321, 321, new DateTime(2024, 6, 30));

            // Digital Wallets
            var wallet1 = new DigitalWallet(1, 150.75f);
            var wallet2 = new DigitalWallet(2, 300.50f);

            // Licenses
            var license1 = new License(1, new DateTime(2020, 1, 1), 1001, "Authority A", new DateTime(2025, 1, 1), 0, new List<string> { "photo1.jpg" }, null);
            var license2 = new License(2, new DateTime(2019, 5, 1), 1002, "Authority B", new DateTime(2024, 5, 1), 1, new List<string> { "photo2.jpg" }, null);

            // Renter
            var renter1 = new Renter(1, "John Doe", "jdoe", card1, new DateTime(1990, 5, 20), 1234567890, true, "password123", "jdoe@example.com", new List<Booking>(), null, wallet1, license1);
            var renter2 = new Renter(2, "Jane Smith", "jsmith", card2, new DateTime(1985, 8, 15), 987654210, false, "password456", "jsmith@example.com", new List<Booking>(), null, wallet2, license2);

            // Admin
            var admin = new Admin(1, "Admin User", "admin", card1, new List<Booking>(), new List<Renter> { renter1, renter2 }, new List<Report>());

            renter1.IsVerifiedBy = admin;
            renter2.IsVerifiedBy = admin;

            // Booking
            var booking1 = new Booking(1, new DateTime(2024, 10, 1, 10, 0, 0), new DateTime(2024, 10, 10, 10, 0, 0), new Location("Location A"), new Location("Location B"), true, 50.0f, 10.0f, 60.0f, "Confirmed", null, new Location("Drop Off Location"), new Location("Pick Up Location"), new List<Report>(), admin, new List<Transaction>());
            var booking2 = new Booking(2, new DateTime(2024, 9, 1, 10, 0, 0), new DateTime(2024, 9, 10, 10, 0, 0), new Location("Location C"), new Location("Location D"), false, 30.0f, 5.0f, 35.0f, "Pending", null, new Location("Drop Off Location"), new Location("Pick Up Location"), new List<Report>(), admin, new List<Transaction>());

            // Add bookings to renter's history
            renter1.BookingHistory.Add(booking1);
            renter2.BookingHistory.Add(booking2);

            // Create Controller and UI
            var renters = new List<Renter> { renter1, renter2 };
            var modifyBookingController = new CTL_modifyBooking(1, renters);
            var modifyBookingUI = new UI_modifyBooking(modifyBookingController, 1);

            // Modify booking
            modifyBookingUI.ModifyBooking(renter1.Id, booking1.Id);
        }
    }
}
