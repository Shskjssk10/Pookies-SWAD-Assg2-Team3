using System;
using System.Collections.Generic;

namespace SWAD_iCar
{
    public class UI_Main
    {
        private List<Booking> bookings;
        private List<Renter> listOfRenters;
        private Renter dummyRenter;
        private Admin dummyAdmin;

        public UI_Main(List<Booking> bookings, List<Renter> listOfRenters, Renter dummyRenter, Admin dummyAdmin)
        {
            this.bookings = bookings;
            this.listOfRenters = listOfRenters;
            this.dummyRenter = dummyRenter;
            this.dummyAdmin = dummyAdmin;
        }

        public void mainMenu()
        {

            Console.WriteLine(" __   ______                     \r\n/  | /      \\                    \r\n$$/ /$$$$$$  | ______    ______  \r\n/  |$$ |  $$/ /      \\  /      \\ \r\n$$ |$$ |      $$$$$$  |/$$$$$$  |\r\n$$ |$$ |   __ /    $$ |$$ |  $$/ \r\n$$ |$$ \\__/  /$$$$$$$ |$$ |      \r\n$$ |$$    $$/$$    $$ |$$ |      \r\n$$/  $$$$$$/  $$$$$$$/ $$/       \r\n                                 \r\n                                 \r\n                                 ");

            Console.WriteLine("Enter your user ID:");
            int userId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your password:");
            string Password = Console.ReadLine();

            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("------------------------------------");

                Console.WriteLine("Welcome back!\nWhat would you Like to do?:");
                Console.WriteLine("1. Manage Car (Caden)");
                Console.WriteLine("2. Register Vehicle (Hendrik)");
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
                            Console.WriteLine("Not Merged");
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
                            Console.WriteLine("Not Merged");
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
                            Console.WriteLine("Not Merged");
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
