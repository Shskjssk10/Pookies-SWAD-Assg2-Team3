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
            var originalBooking = modifyBookingController.ModifyBooking(renterId, bookingId);

            Booking originalBookingData = originalBooking.booking;
            string errorMessage = originalBooking.errorMessage;

            if (originalBookingData != null)
            {
                DisplayBookingDetails(originalBookingData);
                DisplayBookingOptions(originalBookingData);
            }
            else
            {
                DisplayError(errorMessage);
            }
        }

        public void DisplayBookingDetails(Booking booking)
        {
            Console.WriteLine("Booking Details:");
            Console.WriteLine($"ID: {booking.Id}");
            Console.WriteLine($"Start DateTime: {booking.StartDateTime}");
            Console.WriteLine($"End DateTime: {booking.EndDateTime}");
            Console.WriteLine($"Return Method: {booking.ReturnMethod.Address}");
            Console.WriteLine($"Pick Up Method: {booking.PickUpMethod.Address}");
            Console.WriteLine($"Vehicle Inspection Status: {booking.VehicleInspectionStatus}");
            Console.WriteLine($"Penalty Fee: {booking.PenaltyFee}");
            Console.WriteLine($"Damages Fee: {booking.DamagesFee}");
            Console.WriteLine($"Total Booking Fee: ${booking.TotalBookingFee}");
            Console.WriteLine($"Booking Status: {booking.BookingStatus}");
            Console.WriteLine($"Car: {booking.Car.Make} {booking.Car.Model}");
            Console.WriteLine($"Drop Off To: {booking.DropOffTo.Address}");
            Console.WriteLine($"Pick Up From: {booking.PickUpFrom.Address}");
            Console.WriteLine($"Transactions: {string.Join(", ", booking.BookingTransactions)}");
        }

        public void DisplayBookingOptions(Booking booking)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("What type of modification would you like to make to the booking?");
            Console.WriteLine("1. Update Booking");
            Console.WriteLine("2. Cancel Booking");
            Console.WriteLine("------------------------------------");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SelectUpdateBooking(booking);
                    break;
                case "2":
                    SelectCancelBookingOption(booking);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    DisplayBookingOptions(booking);
                    break;
            }
        }

        public void SelectUpdateBooking(Booking originalBookingData)
        {
            DisplayUpdateForm();

            bool isValidChange = false;

            while (!isValidChange)
            {
                Booking updatedBookingData = SubmitUpdatedBookingDetails(originalBookingData);

                modifyBookingController.UpdateBooking(updatedBookingData.Id, updatedBookingData);
                var validatedBooking = modifyBookingController.ValidateUpdateBooking(updatedBookingData);

                if (validatedBooking.booking == null)
                {
                    isValidChange = false;
                    DisplayError(validatedBooking.errorMessage);
                }
                else
                {
                    isValidChange = true;
                    DisplayUpdateConfirmation(validatedBooking.booking);
                }
            }
        }

        public void SelectCancelBookingOption(Booking booking)
        {
            DisplayCancelConfirmation(booking);
        }

        public void DisplayCancelConfirmation(Booking booking)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Are you sure you want to cancel the booking?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine("------------------------------------");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ConfirmCancellation(booking);
                    break;
                case "2":
                    DeclineCancellation();
                    DisplayBookingDetails(booking);
                    DisplayBookingOptions(booking);
                    break;
            }
        }

        public void DisplayUpdateForm()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Select the attribute you want to update:");
            Console.WriteLine("1. Start DateTime");
            Console.WriteLine("2. End DateTime");
            Console.WriteLine("3. Return Method");
            Console.WriteLine("4. Pick Up Method");
            Console.WriteLine("5. Drop Off To");
            Console.WriteLine("6. Pick Up From");
            Console.WriteLine("------------------------------------");
        }

        public void ConfirmCancellation(Booking booking)
        {
            string message = modifyBookingController.CancelBooking(booking, renterId);

            if (message.Contains("successfully cancelled"))
            {
                string successMessage = message;
                DisplaySuccessMessage(successMessage);
            }
            else
            {
                string errorMessage = message;
                DisplayError(errorMessage);
            }
        }

        public void DeclineCancellation()
        {
            Console.WriteLine("Booking cancellation declined.");
        }

        public Booking SubmitUpdatedBookingDetails(Booking booking)
        {
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter the new Start DateTime (format: yyyy-MM-dd HH:mm), e.g., 2024-09-10 14:30:");
                    Console.WriteLine("------------------------------------");

                    DateTime startDateTime;
                    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out startDateTime))
                    {
                        booking.StartDateTime = startDateTime;
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Please use yyyy-MM-dd HH:mm.");
                        return null;
                    }
                    return booking;
                case "2":
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter the new End DateTime (format: yyyy-MM-dd HH:mm), e.g., 2024-09-15 18:00:");
                    Console.WriteLine("------------------------------------");

                    DateTime endDateTime;
                    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out endDateTime))
                    {
                        booking.EndDateTime = endDateTime;
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Please use yyyy-MM-dd HH:mm.");
                        return null;
                    }
                    return booking;
                case "3":
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter the new Return Method:");
                    Console.WriteLine("------------------------------------");

                    booking.ReturnMethod = new Location(Console.ReadLine());
                    return booking;
                case "4":
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter the new Pick Up Method:");
                    Console.WriteLine("------------------------------------");

                    booking.PickUpMethod = new Location(Console.ReadLine());
                    return booking;
                case "5":
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter the new Drop Off To location:");
                    Console.WriteLine("------------------------------------");

                    booking.DropOffTo = new Location(Console.ReadLine());
                    return booking;
                case "6":
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter the new Pick Up From location:");
                    Console.WriteLine("------------------------------------");

                    booking.PickUpFrom = new Location(Console.ReadLine());
                    return booking;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return null;
            }
        }

        public void DisplayUpdateConfirmation(Booking updatedBookingData)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Are you sure you want to update the booking?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine("------------------------------------");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ConfirmUpdate(updatedBookingData);
                    break;
                case "2":
                    Console.WriteLine("Update cancelled");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    DisplayUpdateConfirmation(updatedBookingData);
                    break;
            }
        }

        public void ConfirmUpdate(Booking booking)
        {
            string bookingUpdateResult = modifyBookingController.ConfirmUpdateBooking(booking);

            if (bookingUpdateResult == "Booking updated Successfully")
            {
                Console.WriteLine("************************************");
                DisplaySuccessMessage(bookingUpdateResult);
                Console.WriteLine("************************************");

                var bookingDetails = GetBookingDetails(booking.Id);
                DisplayBookingDetails(bookingDetails.booking);
            }
            else
            {
                DisplayError(bookingUpdateResult);
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

        public (Booking booking, string errorMessage) GetBookingDetails(int bookingId)
        {
            var booking = modifyBookingController.ModifyBooking(renterId, bookingId);

            Booking updatedBookingData = booking.booking;
            string errorMessage = booking.errorMessage;

            return (updatedBookingData, errorMessage);
        }

        public void DisplayBookingHistory(int renterId)
        {
            Renter renter = modifyBookingController.GetRenter(renterId);
            Console.WriteLine("Bookings:");
            foreach (Booking booking in renter.BookingHistory)
            {
                Console.WriteLine("------------------------------------");
                DisplayBookingDetails(booking);
                Console.WriteLine("------------------------------------");
            }
        }
    }
}
