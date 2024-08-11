using System;
using System.Transactions;

namespace SWAD_iCar
{
    internal class Program
    {
        public static List<CarOwner> listOfCarOwners = new List<CarOwner>();
        public static List<Renter> listOfRenters = new List<Renter>();
        public static List<Booking> bookings = new List<Booking>();
        public static Renter dummyRenter;
        public static Admin dummyAdmin;
        public static List<Booking> pendingBookings = new List<Booking>();
        
        static void Main(string[] args)
        {
            // Adding dummy data
            AddDummyData();

            // Main menu
            UI_Main uiMain = new UI_Main(bookings, listOfRenters, dummyRenter, dummyAdmin, listOfCarOwners);
            uiMain.login();
        }

        public static void AddDummyData()
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

            Car car1 = new Car(
                make: "Toyota",
                model: "Camry",
                year: 2020,
                mileage: 15000,
                photos: null,
                isWithdrawn: false,
                reviews: null,
                licensePlate: "XYZ-1234",
                rentalRate: 50.0f
            );

            Booking currentBooking = new Booking(
                id: 3,
                startDateTime: new DateTime(2024, 8, 1, 9, 0, 0), //1st August 2023, 9:00 AM
                endDateTime: new DateTime(2024, 8, 8, 1, 0, 0),
                returnTime: null,
                returnMethod: new Location("iCar Station"),
                pickUpMethod: new Location("iCar Station 2"),
                vehicleInspectionStatus: true,
                penaltyFee: 0.0f,
                damagesFee: 0.0f,
                totalBookingFee: 120.0f,
                bookingStatus: "Ongoing",
                car: car1,
                dropOffTo: null,
                pickUpFrom: null,
                about: new List<Report>(),
                updates: null,
                bookingTransactions: new List<Transaction>()
            );

            Booking currentBooking2 = new Booking(
                id: 4,
                startDateTime: new DateTime(2024, 8, 1, 9, 0, 0), //1st August 2023, 9:00 AM
                endDateTime: new DateTime(2024, 8, 30, 1, 0, 0),
                returnTime: null,
                returnMethod: new Location("iCar Station"),
                pickUpMethod: new Location("iCar Station 2"),
                vehicleInspectionStatus: true,
                penaltyFee: 0.0f,
                damagesFee: 500.0f,
                totalBookingFee: 120.0f,
                bookingStatus: "Ongoing",
                car: car1,
                dropOffTo: null,
                pickUpFrom: null,
                about: new List<Report>(),
                updates: null,
                bookingTransactions: new List<Transaction>()
            );

            Booking currentBooking3 = new Booking(
                id: 5,
                startDateTime: new DateTime(2024, 8, 1, 9, 0, 0), //1st August 2023, 9:00 AM
                endDateTime: new DateTime(2024, 8, 8, 1, 0, 0),
                returnTime: null,
                returnMethod: new Location("iCar Station"),
                pickUpMethod: new Location("iCar Station 2"),
                vehicleInspectionStatus: true,
                penaltyFee: 0.0f,
                damagesFee: 500.0f,
                totalBookingFee: 120.0f,
                bookingStatus: "Ongoing",
                car: car1,
                dropOffTo: null,
                pickUpFrom: null,
                about: new List<Report>(),
                updates: null,
                bookingTransactions: new List<Transaction>()
            );

            Booking currentBooking4 = new Booking(
                id: 7,
                startDateTime: new DateTime(2024, 8, 1, 9, 0, 0), //1st August 2023, 9:00 AM
                endDateTime: DateTime.Now.AddDays(1),
                returnTime: null,
                returnMethod: new Location("iCar Station"),
                pickUpMethod: new Location("iCar Station 2"),
                vehicleInspectionStatus: true,
                penaltyFee: 0.0f,
                damagesFee: 0.0f,
                totalBookingFee: 120.0f,
                bookingStatus: "Ongoing",
                car: car1,
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

            Renter renter2 = new Renter(
                id: 2,
                name: "John Doe2",
                username: "johndoe2",
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
                currentBooking: currentBooking2
            );


            Renter renter6 = new Renter(
                id: 6,
                name: "John Doe6",
                username: "johndoe6",
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
                currentBooking: currentBooking3
            );

            Renter renter7 = new Renter(
                id: 7,
                name: "John Doe7",
                username: "johndoe7",
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
                currentBooking: currentBooking4
            );

            Admin admin = new Admin(1, "Admin", "admin", null, null, null, null);


            // Cards
            var card1 = new Card("Visa", 123456789, 123, new DateTime(2025, 12, 31));
            var card2 = new Card("MasterCard", 987654321, 321, new DateTime(2024, 6, 30));
            var card3 = new Card("Visa", 121212121, 123, new DateTime(2026, 12, 31));
            
            // Digital Wallets
            var wallet1 = new DigitalWallet(150.75f);
            var wallet2 = new DigitalWallet(300.50f);

            // Licenses
            var license1 = new License(new DateTime(2020, 1, 1), 1001, "Authority A", new DateTime(2025, 1, 1), 0, new List<string> { "photo1.jpg" }, null);
            var license2 = new License(new DateTime(2019, 5, 1), 1002, "Authority B", new DateTime(2024, 5, 1), 1, new List<string> { "photo2.jpg" }, null);

            // Renter
            var renter3 = new Renter(3, "John Doe", "jdoe", card1, new DateTime(1990, 5, 20), 1234567890, true, "password123", "jdoe@example.com", new List<Booking>(), null, wallet1, license1, currentBooking);
            var renter4 = new Renter(4, "Jane Smith", "jsmith", card2, new DateTime(1985, 8, 15), 987654210, false, "password456", "jsmith@example.com", new List<Booking>(), null, wallet2, license2, null);
            var renter5 = new Renter(5, "Caden Toh", "Shskjssk10", card3, new DateTime(2000, 8, 10), 12121212, true, "password123", "cadentohjunyi@gmail.com", new List<Booking>(), null, wallet2, license2, null);

            // Car Owners
            CarOwner carOwner1 = new CarOwner(6, "Caden", "Shskjssk10", card1, new DateTime(2000, 8, 10), 84469588);

            // Admin
            var admin1 = new Admin(1, "Admin User", "admin", card1, new List<Booking>(), new List<Renter> { renter3, renter4 }, new List<Report>());

            renter3.IsVerifiedBy = admin1;
            renter4.IsVerifiedBy = admin1;
            renter5.IsVerifiedBy = admin1;


            // Create a dummy list of photos
            List<string> photos = new List<string> { "photo1.jpg", "photo2.jpg" };

            // Create a dummy dictionary of reviews
            Dictionary<int, string> reviews = new Dictionary<int, string>
            {
                { 1, "Great car, smooth ride." },
                { 2, "Clean and well maintained." }
            };


            // Instantiate the Car object with dummy data
            Car dummyCar = new Car(
                make: "Toyota",
                model: "Camry",
                year: 2020,
                mileage: 15000,
                photos: photos,
                isWithdrawn: false,
                reviews: reviews,
                licensePlate: "XYZ-1234",
                rentalRate: 50.0f
            );

            Car dummyCar2 = new Car(
                make: "Mercedes",
                model: "Whatever",
                year: 2020,
                mileage: 15000,
                photos: photos,
                isWithdrawn: false,
                reviews: reviews,
                licensePlate: "XYZ-1234",
                rentalRate: 50.0f
            );


            var booking4 = new Booking(
                4,
                new DateTime(2024, 11, 1, 10, 0, 0),
                new DateTime(2024, 11, 10, 10, 0, 0),
                DateTime.Now.AddDays(5), // Assuming a return time 5 days after booking start
                new Location("Delivery"),
                new Location("iCar Station"),
                true, // Vehicle inspection status
                50.0f, // Penalty fee
                10.0f, // Damages fee
                60.0f, // Total booking fee
                "Confirmed",
                dummyCar,
                new Location("Block 190, Pasir Ris Street 12"),
                new Location("28 Aliwal Street"),
                new List<Report>(),
                admin,
                new List<Transaction>()
            );

            var booking5 = new Booking(
                5,
                new DateTime(2024, 9, 1, 10, 0, 0),
                new DateTime(2024, 9, 10, 10, 0, 0),
                DateTime.Now.AddDays(3), // Assuming a return time 3 days after booking start
                new Location("Location C"),
                new Location("Location D"),
                false, // Vehicle inspection status
                30.0f, // Penalty fee
                5.0f,  // Damages fee
                35.0f, // Total booking fee
                "Pending",
                null,
                new Location("Drop Off Location"),
                new Location("Pick Up Location"),
                new List<Report>(),
                admin,
                new List<Transaction>()
            );
            // Add bookings to renter's history
            renter3.BookingHistory.Add(booking4);
            renter4.BookingHistory.Add(booking5);

            // Add Cars to CarOwners
            carOwner1.linkCarToCarOwner(dummyCar);
            carOwner1.linkCarToCarOwner(dummyCar2);

            ///define the dummy data
            bookings.Add(booking1);
            bookings.Add(booking2);
            bookings.Add(currentBooking);
            bookings.Add(booking4);
            bookings.Add(booking5);

            dummyRenter = renter3;
            dummyAdmin = admin;

            listOfRenters.Add(renter1);
            listOfRenters.Add(renter2);
            listOfRenters.Add(renter3);
            listOfRenters.Add(renter4);
            listOfRenters.Add(renter5);
            listOfRenters.Add(renter6);
            listOfRenters.Add(renter7);

            listOfCarOwners.Add(carOwner1);

            //UI_ReturnVehicle uiReturnVehicle = new UI_ReturnVehicle();
            //uiReturnVehicle.ReturnCar(renter1.Id);


            //alt way
            //CTL_ReturnVehicle ctlReturnVehicle = new CTL_ReturnVehicle();
            //UI_ReturnVehicle uiReturnVehicle = ctlReturnVehicle.uiReturnVehicle;

            //uiReturnVehicle.ReturnCar(renter1.Id);
        }
    }
}
