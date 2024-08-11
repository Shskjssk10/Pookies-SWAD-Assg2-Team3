using System;
using System.Collections.Generic;

namespace SWAD_iCar
{
    public class UI_Main
    {
        private List<Booking> bookings;
        private List<Renter> listOfRenters;
        private Car dummyCar;
        private Renter dummyRenter;
        private Admin dummyAdmin;
        private List<CarOwner> listOfCarOwners;

        public UI_Main(List<Booking> bookings, List<Renter> listOfRenters, Renter dummyRenter, Admin dummyAdmin, List<CarOwner> listOfCarOwners,Car dummyCar)
        { 
            this.bookings = bookings;
            this.listOfRenters = listOfRenters;
            this.dummyRenter = dummyRenter;
            this.dummyAdmin = dummyAdmin;
            this.listOfCarOwners = listOfCarOwners;
            this.dummyCar = dummyCar;
        }
        public void login()
        {
            Console.WriteLine(" __   ______                     \r\n/  | /      \\                    \r\n$$/ /$$$$$$  | ______    ______  \r\n/  |$$ |  $$/ /      \\  /      \\ \r\n$$ |$$ |      $$$$$$  |/$$$$$$  |\r\n$$ |$$ |   __ /    $$ |$$ |  $$/ \r\n$$ |$$ \\__/  /$$$$$$$ |$$ |      \r\n$$ |$$    $$/$$    $$ |$$ |      \r\n$$/  $$$$$$/  $$$$$$$/ $$/       \r\n                                 \r\n                                 \r\n                                 ");

            Console.WriteLine("Enter your user ID:");
            int userId = Convert.ToInt32(Console.ReadLine());

            mainMenu(userId);
        }
        public void mainMenu(int userId)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("------------------------------------");

                Console.WriteLine("Welcome back!\nWhat would you Like to do?:");
                Console.WriteLine("1. Manage Car (Caden)");
                Console.WriteLine("2. Register Car (Hendrik)");
                Console.WriteLine("3. Return Car (Vincent)");
                Console.WriteLine("4. Modify Booking (Neil)");
                Console.WriteLine("5. Rent Vehicles (Diontae)");
                Console.WriteLine("0. Quit");

                Console.WriteLine("------------------------------------");
                Console.WriteLine("------------------------------------");




                string choice = Console.ReadLine();
                Console.WriteLine("******");


                switch (choice)
                {
                    case "1":
                        {
                            CTL_ManageCar manageCarController = new CTL_ManageCar(listOfCarOwners);
                            UI_ManageCar manageCarUI = new UI_ManageCar(manageCarController, new UI_Main(bookings, listOfRenters, dummyRenter, dummyAdmin, listOfCarOwners, dummyCar));
                            manageCarUI.getRegisteredCars(userId);
                            break;
                        }
                    case "2":
                        {
                            var registerCarController = new CTL_RegisterCar();
                            var registerCarUI = new UI_RegisterCar();

                            registerCarUI.addNewCar();

                            break;
                        }
                    case "3":
                        {
                            UI_ReturnCar uiReturnCar = new UI_ReturnCar();
                            uiReturnCar.InitiateCarReturn(userId);
                            break;
                        }
                    case "4":
                        {
                            var modifyBookingController = new CTL_modifyBooking(listOfRenters);
                            var modifyBookingUI = new UI_modifyBooking(modifyBookingController, userId);

                            modifyBookingUI.DisplayBookingHistory(userId);

                            Console.WriteLine("Enter the booking ID of the booking you want to modify:");
                            int inputBookingId = Convert.ToInt32(Console.ReadLine());

                            modifyBookingUI.ModifyBooking(userId, inputBookingId);

                            break;
                        }
                    case "5":
                        {

                            //List<Renter> listOfRenters = new List<Renter>() { renter1 };
                            //List<Car> listOfCars = new List<Car> { car1 };
                            //CTL_RentVehicle ctlRentVehicle = new CTL_RentVehicle();
                            UI_RentVehicle uiRentVehicle = new UI_RentVehicle(); // To be continued

                            uiRentVehicle.RentVehicle(dummyCar.Id, dummyRenter.Id);
                            break;
                        }
                    case "0":
                        {
                            exit = true;
                            break;
                        }
                }
            }
        }
    }
}
