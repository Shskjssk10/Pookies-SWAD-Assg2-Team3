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


            ///define the dummy data
            bookings.Add(booking1);
            bookings.Add(booking2);
            dummyRenter = renter1;
            dummyAdmin = admin;

            List<Renter> listOfRenters = new List<Renter>() { renter1 };
            //UI_ReturnVehicle uiReturnVehicle = new UI_ReturnVehicle();
            //uiReturnVehicle.ReturnCar(renter1.Id);

            //alt way
            CTL_ReturnVehicle ctlReturnVehicle = new CTL_ReturnVehicle();
            UI_ReturnVehicle uiReturnVehicle = ctlReturnVehicle.uiReturnVehicle;

            uiReturnVehicle.ReturnCar(renter1.Id);
        }
    }
}