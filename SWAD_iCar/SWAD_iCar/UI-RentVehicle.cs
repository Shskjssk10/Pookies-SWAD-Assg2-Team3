using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SWAD_iCar
{
    public class UI_RentVehicle
    {
        public CTL_RentVehicle ctlRentVehicle;
        public UI_RentVehicle(CTL_RentVehicle ctlRentVehicle) 
        {
            this.ctlRentVehicle = ctlRentVehicle;
        }
        public void RentVehicle(int carId, int renterId)
        {
            ctlRentVehicle.RentVehicle(carId, renterId);
        }

        public void PromptStartAndEndDate()
        {
            DateTime start;
            DateTime end;

            while (true)
            {
                try
                {
                    Console.Write("Enter Start Date (yyyy-MM-dd HH:mm):");
                    start = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter End Date (yyyy-MM-dd HH:mm):");
                    end = DateTime.Parse(Console.ReadLine());

                    if (end <= start)
                    {
                        Console.WriteLine("End date must be after the start date. Please enter the dates again.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date format. Please enter the dates again.");
                }
            }

            EnterStartAndEndDate(start, end);
        }

        public void EnterStartAndEndDate(DateTime start, DateTime end)
        {
            ctlRentVehicle.EnterStartAndEndDate(start, end);
        }

        public void DisplayInvalidDateTimeMessage()
        {
            Console.WriteLine("Invalid date and time. Please try again.");
        }
        public void PromptPickUpMethod()
        {
            Console.WriteLine("Select Pickup Method, in full name format: \niCar Station\nPhysical Address");
            string method = Console.ReadLine().Trim();
            SelectPickUpMethod(method);
        }

        public void SelectPickUpMethod(string pickUpMethod)
        {
            ctlRentVehicle.SelectPickUpMethod(pickUpMethod);
        }

        public void DisplayAlliCarStations(List<ICarStation> iCarStations)
        {
            Console.WriteLine("All iCar Stations: ");
            foreach (ICarStation c in iCarStations)
            {
                Console.WriteLine($"iCarStation ID: {c.Id}\n" +
                    $"iCarStation Name: {c.Name}");
            }

            PromptiCarStation();
        }

        public void PromptiCarStation()
        {
            Console.Write("Enter the ID of the iCar Station of your choice: ");
            int selectediCarStation = int.Parse(Console.ReadLine());
            SelectiCarStation(selectediCarStation);
        }

        public void PromptPhysicalAddress()
        {
            Console.Write("Enter your preferred physical address: ");
            string physicalAddress = Console.ReadLine().Trim();
            EnterPhysicalAddress(physicalAddress);
        }
        public void EnterPhysicalAddress(string physicalAddress)
        {
            ctlRentVehicle.EnterPhysicalAddress(physicalAddress);
        }

        public void DisplayInvalidAddressMessage()
        {
            Console.WriteLine("Invalid address. Please try again.");
        }

        public void PromptReturnMethod()
        {
            Console.WriteLine("Select Return Method, in full name format: \niCar Station\nPhysical Address");
            string method = Console.ReadLine().Trim();
            SelectReturnMethod(method);
        }

        public void SelectReturnMethod(string returnMethod)
        {
            ctlRentVehicle.SelectReturnMethod(returnMethod);
        }

        public void SelectiCarStation(int iCarStation)
        {
            ctlRentVehicle.SelectiCarStation(iCarStation);
        }

        public void DisplayTotalCost(float bookingFee)
        {
            Console.WriteLine($"Total Cost: {bookingFee}");
            PromptMakePayment();
        }

        public void PromptMakePayment()
        {
            Console.WriteLine("Proceed to payment? (yes/no)");
            string response = Console.ReadLine().ToLower();
            if (response == "yes")
            {
                MakePayment();
            }
            else
            {
                Console.WriteLine("Booking cancelled.");
            }
        }

        public void MakePayment()
        {
            ctlRentVehicle.MakePayment();
        }

        public void DisplayAllDetails(Car car, Booking newBooking)
        {
            Console.WriteLine("Car Details:");
            Console.WriteLine($"Car ID: {car.Id}");
            Console.WriteLine($"Make: {car.Make}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Year: {car.Year}");
            Console.WriteLine($"Mileage: {car.Mileage} km");
            Console.WriteLine($"License Plate: {car.LicensePlate}");
            Console.WriteLine($"Rental Rate: ${car.RentalRate:F2} per hour");

            Console.WriteLine("\nBooking Details:");
            Console.WriteLine($"Booking ID: {newBooking.Id}");
            Console.WriteLine($"Start DateTime: {newBooking.StartDateTime}");
            Console.WriteLine($"End DateTime: {newBooking.EndDateTime}");
            Console.WriteLine($"Pick Up Method: {newBooking.PickUpMethod}");
            Console.WriteLine($"Return Method: {newBooking.ReturnMethod}");
            Console.WriteLine($"Total Booking Fee: ${newBooking.TotalBookingFee:F2}");
            Console.WriteLine($"Booking Status: {newBooking.BookingStatus}");
            Console.WriteLine($"Number of Transactions: {newBooking.BookingTransactions.Count}");

            Console.WriteLine("\nTransaction Details:");
            foreach (Transaction transaction in newBooking.BookingTransactions)
            {
                Console.WriteLine($"Id: {transaction.Id}");
                Console.WriteLine($"Cost: {transaction.Cost}");
                Console.WriteLine($"Time: {transaction.Time}");
                Console.WriteLine();
            }
        }
    }
}
