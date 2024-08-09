using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using SWAD_iCar;
using static System.Net.Mime.MediaTypeNames;

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

            //Booking booking1 = new Booking(
            //    id: 1,
            //    startDateTime: DateTime.Now.AddMonths(-1),
            //    endDateTime: DateTime.Now.AddMonths(-1).AddDays(7),
            //    returnTime: DateTime.Now.AddMonths(-1).AddDays(7).AddHours(1),
            //    returnMethod: null,
            //    pickUpMethod: null,
            //    vehicleInspectionStatus: true,
            //    penaltyFee: 20.0f,
            //    damagesFee: 50.0f,
            //    totalBookingFee: 170.0f,
            //    bookingStatus: "Completed",
            //    car: null,
            //    dropOffTo: null,
            //    pickUpFrom: null,
            //    about: new List<Report> { null },
            //    updates: null,
            //    bookingTransactions: new List<Transaction> { null }
            //);

            //Booking booking2 = new Booking(
            //    id: 2,
            //    startDateTime: DateTime.Now.AddMonths(-3),
            //    endDateTime: DateTime.Now.AddMonths(-3).AddDays(5),
            //    returnTime: DateTime.Now.AddMonths(-3).AddDays(5).AddHours(-1),
            //    returnMethod: null,
            //    pickUpMethod: null,
            //    vehicleInspectionStatus: false,
            //    penaltyFee: 0.0f,
            //    damagesFee: 0.0f,
            //    totalBookingFee: 100.0f,
            //    bookingStatus: "Completed",
            //    car: null,
            //    dropOffTo: null,
            //    pickUpFrom: null,
            //    about: new List<Report> { null },
            //    updates: null,
            //    bookingTransactions: new List<Transaction> { null }
            //);

            //Booking currentBooking = new Booking(
            //    id: 3,
            //    startDateTime: new DateTime(2024, 8, 1, 9, 0, 0), //1st August 2023, 9:00 AM
            //    endDateTime: new DateTime(2024, 8, 8, 1, 0, 0),
            //    returnTime: new DateTime(2024, 8, 1, 12, 0, 0), //not affected anyways
            //    returnMethod: new Location("iCar Station"),
            //    pickUpMethod: new Location("iCar Station 2"),
            //    vehicleInspectionStatus: true,
            //    penaltyFee: 0.0f,
            //    damagesFee: 0.0f,
            //    totalBookingFee: 120.0f,
            //    bookingStatus: "Ongoing",
            //    car: null,
            //    dropOffTo: null,
            //    pickUpFrom: null,
            //    about: new List<Report>(),
            //    updates: null,
            //    bookingTransactions: new List<Transaction>()
            //);

            //Renter renter1 = new Renter(
            //    id: 1,
            //    name: "John Doe",
            //    username: "johndoe",
            //    card: null,
            //    dateOfBirth: new DateTime(1990, 1, 1),
            //    contact: 1234567890,
            //    isVerified: true,
            //    password: "password123",
            //    email: "johndoe@example.com",
            //    bookingHistory: new List<Booking>() { booking1 },
            //    isVerifiedBy: null,
            //    wallet: null,
            //    driversLicense: null,
            //    currentBooking: currentBooking
            //);

            //Admin admin = new Admin(1, "Admin", "admin", null, null, null, null);


            /////define the dummy data
            //bookings.Add(booking1);
            //bookings.Add(booking2);
            //dummyRenter = renter1;
            //dummyAdmin = admin;

            //List<Renter> listOfRenters = new List<Renter>() { renter1 };
            ////UI_ReturnVehicle uiReturnVehicle = new UI_ReturnVehicle();
            ////uiReturnVehicle.ReturnCar(renter1.Id);

            ////alt way
            //CTL_ReturnVehicle ctlReturnVehicle = new CTL_ReturnVehicle();
            //UI_ReturnVehicle uiReturnVehicle = ctlReturnVehicle.uiReturnVehicle;

            //uiReturnVehicle.ReturnCar(renter1.Id);


            //Hendrik
            //Console.WriteLine("Hello, World!");

            ////have test car owner 
            ////have test car 
            ////add to car owner
            //DateTime dob = new DateTime(2005, 5, 12);
            //DateTime cardExpDate = new DateTime(2024, 8, 19);
            //DateTime insuranceExpDate = new DateTime(2025, 3, 08);
            //DateTime insuranceIssueDate = new DateTime(2021, 05, 06);
            //Card card = new Card("credit", 123, 667, cardExpDate);
            //var photosForCamry = new List<string> { "image1.jpg", "image2.jpg" };
            //Insurance insuranceDetails = new Insurance(1, insuranceExpDate, insuranceIssueDate, "AIA");
            //CarOwner owner = new CarOwner(1, "Hendrik", "hendrikywr", card, dob, 91234567);

            //CTL_registerCar registerCTL = new CTL_registerCar();
            //UI_registerCar registerUI = new UI_registerCar();

            //registerUI.AddNewCar();


            //registerCTL.AddNewCar(1, "Toyota", "Camry", 2020, 15000, "SJF1234A", 1, photosForCamry, insuranceDetails);
            //// Print the owner details
            //Console.WriteLine(owner.ToString());

            //foreach (var car in owner.GetCars())
            //{
            //    Console.WriteLine(car);
            //}

            Console.WriteLine("ENTER OPTION (1-5): ");
            string option = Console.ReadLine().Trim();

            if(option == "1")
            {
                ReturnVehicle();
            }
            else if(option == "2")
            {
                RegisterCar();
            }
 
        }
        public static void ReturnVehicle()
        {
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

        public static void RegisterCar()
        {
            Console.WriteLine("Hello, World!");

            //have test car owner 
            //have test car 
            //add to car owner
            DateTime dob = new DateTime(2005, 5, 12);
            DateTime cardExpDate = new DateTime(2024, 8, 19);
            DateTime insuranceExpDate = new DateTime(2025, 3, 08);
            DateTime insuranceIssueDate = new DateTime(2021, 05, 06);
            Card card = new Card("credit", 123, 667, cardExpDate);
            var photosForCamry = new List<string> { "image1.jpg", "image2.jpg" };
            Insurance insuranceDetails = new Insurance(1, insuranceExpDate, insuranceIssueDate, "AIA");
            CarOwner owner = new CarOwner(1, "Hendrik", "hendrikywr", card, dob, 91234567);

            CTL_registerCar registerCTL = new CTL_registerCar();
            UI_registerCar registerUI = new UI_registerCar();

            registerUI.AddNewCar();


            registerCTL.AddNewCar(1, "Toyota", "Camry", 2020, 15000, "SJF1234A", 1, photosForCamry, insuranceDetails);
            // Print the owner details
            Console.WriteLine(owner.ToString());

            foreach (var car in owner.GetCars())
            {
                Console.WriteLine(car);
            }
        }
    }
}49