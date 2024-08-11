using System;
using System.Transactions;

namespace SWAD_iCar
{
    internal class Program
    {
        public static List<Renter> listOfRenters = new List<Renter>();
        public static List<Booking> bookings = new List<Booking>();
        public static Renter dummyRenter;
        public static Admin dummyAdmin;
        public static Car dummyCar;
        public static ICarStation dummyiCarStation;
        public static List<Booking> pendingBookings = new List<Booking>();
        public static List<ICarStation> ListOfiCarStations = new List<ICarStation>();

        static void Main(string[] args)
        {
            // Adding dummy data
            AddDummyData();

            // Main menu
            UI_Main uiMain = new UI_Main(bookings, listOfRenters, dummyRenter, dummyAdmin);
            uiMain.mainMenu();
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

            Booking currentBooking = new Booking(
                id: 3,
                startDateTime: DateTime.Now.AddDays(-1),
                endDateTime: DateTime.Now.AddDays(2),
                returnTime: DateTime.Now,
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
                bookingHistory: new List<Booking> { booking1 },
                isVerifiedBy: null,
                wallet: null,
                driversLicense: null,
                currentBooking: currentBooking
            );

            // Dummy data for creating a Car object
            Car car1 = new Car(
                make: "Toyota",
                model: "Camry",
                year: 2020,
                mileage: 15000.5f,
                photos: new List<string> { "photo1.jpg", "photo2.jpg" },
                isWithdrawn: false,
                reviews: new Dictionary<int, string> { { 1, "Great car!" }, { 2, "Very comfortable." } },
                licensePlate: "ABC123",
                rentalRate: 50.0f
            );

            //// Instantiate the Car object with dummy data
            //Car dummyCar = new Car(
            //    make: "Toyota",
            //    model: "Camry",
            //    year: 2020,
            //    mileage: 15000,
            //    photos: photos,
            //    isWithdrawn: false,
            //    reviews: reviews,
            //    licensePlate: "XYZ-1234",
            //    rentalRate: 50.0f
            //);

            List<Timeslot> GenerateDummyTimeslots(Car car, DateTime startDate, DateTime endDate)
            {
                List<Timeslot> timeslots = new List<Timeslot>();

                DateTime current = startDate;
                while (current <= endDate)
                {
                    for (int hour = 0; hour < 24; hour++)
                    {
                        timeslots.Add(new Timeslot(current.AddHours(hour), true, car));
                    }
                    current = current.AddDays(1);
                }
                return timeslots;
            }

            DateTime currentDate = DateTime.Now;
            
            List<Timeslot> timeslots = GenerateDummyTimeslots(car1, currentDate.AddDays(1), currentDate.AddDays(11);

            foreach (Timeslot timeslot in timeslots)
            {
                car1.AddNewTimeSlot(timeslot);
            }

            // Dummy data for creating an ICarStation object
            ICarStation station1 = new ICarStation(
                id: 1,
                name: "Downtown Station",
                address: "123 Main St, Springfield, USA"
            );

            ICarStation station2 = new ICarStation(
                id: 2,
                name: "Diontae Station",
                address: "888 Diontae Road, Singapore"
            );

            ///define the dummy data
            bookings.Add(booking1);
            bookings.Add(booking2);
            dummyRenter = renter1;
            dummyCar = car1;
            dummyiCarStation = station1;
            ListOfiCarStations.Add(dummyiCarStation);
            ListOfiCarStations.Add(station2);

            List<Renter> listOfRenters = new List<Renter>() { renter1 };
            List<Car> listOfCars = new List<Car> { car1 };
            CTL_RentVehicle ctlRentVehicle = new CTL_RentVehicle();
            UI_RentVehicle uiRentVehicle = ctlRentVehicle.uiRentVehicle;

            uiRentVehicle.RentVehicle(car1.Id, renter1.Id);

            Admin admin = new Admin(1, "Admin", "admin", null, null, null, null);


            // Cards
            var card1 = new Card("Visa", 123456789, 123, new DateTime(2025, 12, 31));
            var card2 = new Card("MasterCard", 987654321, 321, new DateTime(2024, 6, 30));

            // Digital Wallets
            var wallet1 = new DigitalWallet(150.75f);
            var wallet2 = new DigitalWallet(300.50f);

            // Licenses
            var license1 = new License(new DateTime(2020, 1, 1), 1001, "Authority A", new DateTime(2025, 1, 1), 0, new List<string> { "photo1.jpg" }, null);
            var license2 = new License(new DateTime(2019, 5, 1), 1002, "Authority B", new DateTime(2024, 5, 1), 1, new List<string> { "photo2.jpg" }, null);

            // Renter
            var renter3 = new Renter(3, "John Doe", "jdoe", card1, new DateTime(1990, 5, 20), 1234567890, true, "password123", "jdoe@example.com", new List<Booking>(), null, wallet1, license1, null);
            var renter4 = new Renter(4, "Jane Smith", "jsmith", card2, new DateTime(1985, 8, 15), 987654210, false, "password456", "jsmith@example.com", new List<Booking>(), null, wallet2, license2, null);

            // Admin
            var admin1 = new Admin(1, "Admin User", "admin", card1, new List<Booking>(), new List<Renter> { renter3, renter4 }, new List<Report>());

            renter3.IsVerifiedBy = admin1;
            renter4.IsVerifiedBy = admin1;


            // Create a dummy list of photos
            List<string> photos = new List<string> { "photo1.jpg", "photo2.jpg" };

            // Create a dummy dictionary of reviews
            Dictionary<int, string> reviews = new Dictionary<int, string>
            {
                { 1, "Great car, smooth ride." },
                { 2, "Clean and well maintained." }
            };

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


            ///define the dummy data
            bookings.Add(booking1);
            bookings.Add(booking2);
            bookings.Add(currentBooking);
            bookings.Add(booking4);
            bookings.Add(booking5);

            dummyRenter = renter3;
            dummyAdmin = admin;

            listOfRenters.Add(renter1);
            listOfRenters.Add(renter3);
            listOfRenters.Add(renter4);

            //UI_ReturnVehicle uiReturnVehicle = new UI_ReturnVehicle();
            //uiReturnVehicle.ReturnCar(renter1.Id);


            //alt way
            //CTL_ReturnVehicle ctlReturnVehicle = new CTL_ReturnVehicle();
            //UI_ReturnVehicle uiReturnVehicle = ctlReturnVehicle.uiReturnVehicle;

            //uiReturnVehicle.ReturnCar(renter1.Id);
        }
    }
}
