using System;
using System.Transactions;

namespace SWAD_iCar
{
    internal class Program
    {   
        public static List<Booking> bookings = new List<Booking>();
        public static Renter dummyRenter;
        public static Admin dummyAdmin;
        public static List<Booking> pendingBookings = new List<Booking>();
        
        static void Main(string[] args)
        {

            //var card = new Card(1, "1234-5678-9101-1121", new DateTime(2025, 12, 31));
            //var booking1 = new Booking(DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(-1).AddDays(7), DateTime.Now.AddMonths(-1).AddDays(7).AddHours(1));
            //var booking2 = new Booking(DateTime.Now.AddMonths(-3), DateTime.Now.AddMonths(-3).AddDays(5), DateTime.Now.AddMonths(-3).AddDays(5).AddHours(-1));
            ////var bookingHistory = new List<Booking> { booking1, booking2 };
            ////var admin = new Admin(1, "Admin Name");
            ////var wallet = new DigitalWallet("wallet123");
            ////var license = new License("AB1234567", new DateTime(2028, 6, 30));
            //var currentBooking = new Booking(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(2), DateTime.Now);

            Booking booking1 = new Booking(
                id: 1,
                startDateTime: DateTime.Now.AddMonths(-1),
                endDateTime: DateTime.Now.AddMonths(-1).AddDays(7),
                returnTime: DateTime.Now.AddMonths(-1).AddDays(7).AddHours(1),
                returnMethod: null,
                pickUpMethod: null,
                vehicleInspectionStatus: true,
                penaltyFee: 20.0f,
                damagesFee: 50.0f,
                totalBookingFee: 170.0f,
                bookingStatus: "Completed",
                car: null,
                dropOffTo: null,
                pickUpFrom: null,
                about: new List<Report> { null },
                updates: null,
                bookingTransactions: new List<Transaction> { null }
            );

            Booking booking2 = new Booking(
                id: 2,
                startDateTime: DateTime.Now.AddMonths(-3),
                endDateTime: DateTime.Now.AddMonths(-3).AddDays(5),
                returnTime: DateTime.Now.AddMonths(-3).AddDays(5).AddHours(-1),
                returnMethod: null,
                pickUpMethod: null,
                vehicleInspectionStatus: false,
                penaltyFee: 0.0f,
                damagesFee: 0.0f,
                totalBookingFee: 100.0f,
                bookingStatus: "Completed",
                car: null,
                dropOffTo: null,
                pickUpFrom: null,
                about: new List<Report> { null },
                updates: null,
                bookingTransactions: new List<Transaction> { null }
            );

            Booking currentBooking = new Booking(
                id: 3,
                startDateTime: new DateTime(2024, 8, 1, 9, 0, 0), //1st August 2023, 9:00 AM
                endDateTime: new DateTime(2024, 8, 8, 1, 0, 0),
                returnTime: new DateTime(2024, 8, 1, 12, 0, 0), //not affected anyways
                returnMethod: new Location("iCar Station"),
                pickUpMethod: new Location("iCar Station 2"),
                vehicleInspectionStatus: true,
                penaltyFee: 0.0f,
                damagesFee: 0.0f,
                totalBookingFee: 120.0f,
                bookingStatus: "Ongoing",
                car: null,
                dropOffTo: null,
                pickUpFrom: null,
                about: new List<Report>(),
                updates: null,
                bookingTransactions: new List<Transaction>()
            );

            Renter renter1 = new Renter(
                id: 1,
                name: "John Doe",
                username: "johndoe",
                card: null,
                dateOfBirth: new DateTime(1990, 1, 1),
                contact: 1234567890,
                isVerified: true,
                password: "password123",
                email: "johndoe@example.com",
                bookingHistory: new List<Booking>() { booking1 },
                isVerifiedBy: null,
                wallet: null,
                driversLicense: null,
                currentBooking: currentBooking
            );

            Admin admin = new Admin(1, "Admin", "admin", null, null, null, null);

            
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
            var renter3 = new Renter(1, "John Doe", "jdoe", card1, new DateTime(1990, 5, 20), 1234567890, true, "password123", "jdoe@example.com", new List<Booking>(), null, wallet1, license1);
            var renter4 = new Renter(2, "Jane Smith", "jsmith", card2, new DateTime(1985, 8, 15), 987654210, false, "password456", "jsmith@example.com", new List<Booking>(), null, wallet2, license2);

            // Admin
            var admin1 = new Admin(1, "Admin User", "admin", card1, new List<Booking>(), new List<Renter> { renter1, renter2 }, new List<Report>());

            renter1.IsVerifiedBy = admin1;
            renter2.IsVerifiedBy = admin1;

            // Booking
            var booking3 = new Booking(1, new DateTime(2024, 10, 1, 10, 0, 0), new DateTime(2024, 10, 10, 10, 0, 0), new Location("Location A"), new Location("Location B"), true, 50.0f, 10.0f, 60.0f, "Confirmed", null, new Location("Drop Off Location"), new Location("Pick Up Location"), new List<Report>(), admin, new List<Transaction>());
            var booking4 = new Booking(2, new DateTime(2024, 9, 1, 10, 0, 0), new DateTime(2024, 9, 10, 10, 0, 0), new Location("Location C"), new Location("Location D"), false, 30.0f, 5.0f, 35.0f, "Pending", null, new Location("Drop Off Location"), new Location("Pick Up Location"), new List<Report>(), admin, new List<Transaction>());

            // Add bookings to renter's history
            renter1.BookingHistory.Add(booking3);
            renter2.BookingHistory.Add(booking4);


            ///define the dummy data
            bookings.Add(booking1);
            bookings.Add(booking2);
            bookings.Add(booking3);
            bookings.Add(booking4);

            dummyRenter = renter1;
            dummyAdmin = admin;

            List<Renter> listOfRenters = new List<Renter>() { renter1, renter3, renter4};
            //UI_ReturnVehicle uiReturnVehicle = new UI_ReturnVehicle();
            //uiReturnVehicle.ReturnCar(renter1.Id);

            // Create Controller and UI
            var modifyBookingController = new CTL_modifyBooking(3, listOfRenters);
            var modifyBookingUI = new UI_modifyBooking(modifyBookingController, 1);

            // Modify booking
            modifyBookingUI.ModifyBooking(renter1.Id, booking1.Id);

            //alt way
            CTL_ReturnVehicle ctlReturnVehicle = new CTL_ReturnVehicle();
            UI_ReturnVehicle uiReturnVehicle = ctlReturnVehicle.uiReturnVehicle;

            uiReturnVehicle.ReturnCar(renter1.Id);
        }
    }
}
