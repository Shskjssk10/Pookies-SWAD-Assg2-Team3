using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    internal class UI_modifyBooking
    {

        private CTL_modifyBooking modifyBookingController;
        private int renterId;


        public UI_modifyBooking(CTL_modifyBooking modifyBookingController, int renterId)
        {
            this.modifyBookingController = modifyBookingController;
            this.renterId = renterId;
        }

        public void ModifyBooking(int renterId, int bookingId)
        {
            Console.WriteLine($"Modifying booking {bookingId}");
            Booking booking1 = modifyBookingController.ModifyBooking(renterId, bookingId);
            if (booking1 != null)
            {
                DisplayBookingDetails(booking1);
                DisplayBookingOptions(booking1);

            }


        }

        public void DisplayBookingDetails(Booking booking)
        {
            Console.WriteLine("Booking Details:");
            Console.WriteLine($"ID: {booking.Id}");
            Console.WriteLine($"Start DateTime: {booking.StartDateTime}");
            Console.WriteLine($"End DateTime: {booking.EndDateTime}");
            Console.WriteLine($"Return Method: {booking.ReturnMethod}");
            Console.WriteLine($"Pick Up Method: {booking.PickUpMethod}");
            Console.WriteLine($"Vehicle Inspection Status: {booking.VehicleInspectionStatus}");
            Console.WriteLine($"Penalty Fee: {booking.PenaltyFee}");
            Console.WriteLine($"Damages Fee: {booking.DamagesFee}");
            Console.WriteLine($"Total Booking Fee: {booking.TotalBookingFee}");
            Console.WriteLine($"Booking Status: {booking.BookingStatus}");
            Console.WriteLine($"Car: {booking.Car}");
            Console.WriteLine($"Drop Off To: {booking.DropOffTo}");
            Console.WriteLine($"Pick Up From: {booking.PickUpFrom}");
            Console.WriteLine($"Reports: {string.Join(", ", booking.About)}");
            Console.WriteLine($"Updated By: {booking.UpdatedBy}");
            Console.WriteLine($"Transactions: {string.Join(", ", booking.BookingTransactions)}");
        }

        public void DisplayBookingOptions(Booking booking)
        {
            Console.WriteLine("What type of modification would you like to make to the booking?");
            Console.WriteLine("1. Update Booking");
            Console.WriteLine("2. Cancel Booking");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    selectUpdateBooking(booking);
                    break;
                case "2":
                    selectCancelBookingOption(booking);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    DisplayBookingOptions(booking);
                    break;
            }
        }

        public void selectUpdateBooking(Booking booking1)
        {
            displayUpdateForm();

            bool isValidChange = false;
            while (!isValidChange)
            {
                Booking updatedBooking = submitUpdatedBookingDetails(booking1);

                if (updatedBooking != null)
                {
                    modifyBookingController.updateBooking(updatedBooking.Id, updatedBooking);
                    isValidChange = modifyBookingController.validateUpdateBooking(updatedBooking);

                    if (isValidChange)
                    {
                        displayUpdateConfirmation(updatedBooking);
                    }
                    else
                    {
                        Console.WriteLine("Invalid booking details. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Update was cancelled or invalid. Please try again.");
                }
            }
        }

        public void selectCancelBookingOption(Booking booking)
        {
            displayCancelConfirmation(booking);
        }

        public void displayCancelConfirmation(Booking booking)
        {
            Console.WriteLine("Are you sure you want to cancel the booking?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    confirmCancellation(booking);
                    break;
                case "2":
                    declineCancellation();
                    DisplayBookingDetails(booking);
                    DisplayBookingOptions(booking);
                    break;
            }
        }


        public void displayUpdateForm()
        {
            Console.WriteLine("Select the attribute you want to update:");
            Console.WriteLine("1. Start DateTime");
            Console.WriteLine("2. End DateTime");
            Console.WriteLine("3. Return Method");
            Console.WriteLine("4. Pick Up Method");
            Console.WriteLine("5. Drop Off To");
            Console.WriteLine("6. Pick Up From");
        }

        public void confirmCancellation(Booking booking)
        {
            string result = modifyBookingController.cancelBooking(booking, renterId);

            if (result.Contains("successfully cancelled"))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(result);
            }
        }


        public void declineCancellation()
        {
            Console.WriteLine("Booking cancellation declined.");
        }

        public Booking submitUpdatedBookingDetails(Booking booking)
        {
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter the new Start DateTime (format: yyyy-MM-dd HH:mm), e.g., 2024-09-10 14:30:");
                    DateTime startDateTime;
                    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out startDateTime))
                    {
                        booking.StartDateTime = startDateTime;
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Please use yyyy-MM-dd HH:mm.");
                        return null; // Exit if the format is invalid
                    }
                    return booking;
                case "2":
                    Console.WriteLine("Enter the new End DateTime (format: yyyy-MM-dd HH:mm), e.g., 2024-09-15 18:00:");
                    DateTime endDateTime;
                    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out endDateTime))
                    {
                        booking.EndDateTime = endDateTime;
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Please use yyyy-MM-dd HH:mm.");
                        return null; // Exit if the format is invalid
                    }
                    return booking;
                case "3":
                    Console.WriteLine("Enter the new Return Method:");
                    booking.ReturnMethod = new Location(Console.ReadLine());
                    return booking;
                case "4":
                    Console.WriteLine("Enter the new Pick Up Method:");
                    booking.PickUpMethod = new Location(Console.ReadLine());
                    return booking;
                case "5":
                    Console.WriteLine("Enter the new Drop Off To location:");
                    booking.DropOffTo = new Location(Console.ReadLine());
                    return booking;
                case "6":
                    Console.WriteLine("Enter the new Pick Up From location:");
                    booking.PickUpFrom = new Location(Console.ReadLine());
                    return booking;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return null; // Exit if the choice is invalid
            }
        }

        public void displayUpdateConfirmation(Booking updatedBookingData)
        {
            Console.WriteLine("Are you sure you want to update the booking?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    confirmUpdate(updatedBookingData);
                    break;
                case "2":
                    Console.WriteLine("Update cancelled");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    displayUpdateConfirmation(updatedBookingData); // Redisplay confirmation if invalid input
                    break;
            }
        }

        public void confirmUpdate(Booking booking)
        {
            string resultMessage = modifyBookingController.confirmUpdateBooking(booking);

            if (resultMessage == "Booking updated Successfully")
            {
                DisplaySuccessMessage(resultMessage);
                getBookingDetails(booking.Id);
            }
            else
            {
                DisplayError(resultMessage);
            }
        }


        public void DisplaySuccessMessage(string message)
        {
            Console.WriteLine(message);
        }
    
        public void DisplayError(string message) 
        { 
            Console.WriteLine(message);
        }

        public void getBookingDetails(int bookingId)
        {
            Booking updatedBooking = modifyBookingController.ModifyBooking(renterId, bookingId);

            if (updatedBooking != null)
            {
                DisplayBookingDetails(updatedBooking);
            }
            else
            {
                Console.WriteLine("Failed to retrieve booking details.");
            }
        }

    }
}
