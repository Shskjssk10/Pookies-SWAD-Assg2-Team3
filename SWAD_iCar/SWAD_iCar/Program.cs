using System;
using System.Runtime.ConstrainedExecution;
using System.Transactions;

namespace SWAD_iCar
{
    internal class Program
    {
        public static List<Booking> bookings = new List<Booking>();
        public static Renter dummyRenter;
        public static Admin dummyAdmin;
        public static Car dummyCar;
        public static ICarStation dummyiCarStation;
        public static List<Booking> pendingBookings = new List<Booking>();
        public static List<ICarStation> ListOfiCarStations = new List<ICarStation>();

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
                startDateTime: DateTime.Now.AddDays(-1),
                endDateTime: DateTime.Now.AddDays(2),
                returnTime: DateTime.Now,
                returnMethod: null,
                pickUpMethod: null,
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
                bookingHistory: new List<Booking> { booking1},
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

            List<Timeslot> timeslots = GenerateDummyTimeslots(car1, new DateTime(2024, 8, 11), new DateTime(2024, 8, 13));

            foreach (Timeslot timeslot in timeslots)
            {
                car1.AddNewTimeSlot(timeslot);
            }

            foreach (Timeslot timeslot in car1.RegisteredTimeSlots)
            {
                Console.WriteLine(timeslot);
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
        }
    }
}

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");