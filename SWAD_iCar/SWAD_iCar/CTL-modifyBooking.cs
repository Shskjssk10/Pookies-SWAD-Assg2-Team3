using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    internal class CTL_modifyBooking
    {
        private int bookingIdToModify;
        private List<Renter> renters;
        private Booking originalBooking; // New attribute to store the original booking


        public CTL_modifyBooking(int bookingIdToModify, List<Renter> renters)
        {
            this.bookingIdToModify = bookingIdToModify;
            this.renters = renters;
        }

        public Booking ModifyBooking(int renterId, int bookingId)
        {
            Renter renter1 = GetRenter(renterId);

            originalBooking = renter1.GetBooking(bookingId);

            bool isLessThan24Hours = checkIfLessThan24Hours(originalBooking);

            if (originalBooking == null)
            {
                Console.WriteLine("Booking not found.");
                return null;
            }

            if (isLessThan24Hours == true)
            {
                Console.WriteLine("Cannot modify booking. Less than 24 hours remaining.");
                return null;
            }
            else if (isLessThan24Hours == false) { }
            {
                return originalBooking;
            }
        }

        public Renter GetRenter(int renterId)
        {
            Renter renter1 = renters.FirstOrDefault(r => r.Id == renterId);

            return renter1;
        }

        public bool checkIfLessThan24Hours(Booking booking)
        {
            return (booking.StartDateTime - DateTime.Now).TotalHours < 24;
        }

        public void updateBooking(int bookingId, Booking booking)
        {
            // Validate the booking before updating
            //bool isValid = validateUpdateBooking(booking);
        }

        public bool validateUpdateBooking(Booking updatedBooking)
        {
            // Validate StartDateTime
            if (updatedBooking.StartDateTime <= DateTime.Now)
            {
                Console.WriteLine("Start DateTime must be in the future.");
                return false;
            }

            // Validate EndDateTime
            if (updatedBooking.EndDateTime <= updatedBooking.StartDateTime)
            {
                Console.WriteLine("Start date time must before end date time or End DateTime must be after Start DateTime.");
                return false;
            }

            // Validate ReturnMethod
            if (updatedBooking.ReturnMethod == null)
            {
                Console.WriteLine("Return Method cannot be empty.");
                return false;
            }

            // Validate PickUpMethod
            if (updatedBooking.PickUpMethod == null)
            {
                Console.WriteLine("Pick Up Method cannot be empty.");
                return false;
            }

            // Validate DropOffTo
            if (updatedBooking.DropOffTo == null)
            {
                Console.WriteLine("Drop Off To location cannot be empty.");
                return false;
            }

            // Validate PickUpFrom
            if (updatedBooking.PickUpFrom == null)
            {
                Console.WriteLine("Pick Up From location cannot be empty.");
                return false;
            }

            // Additional validations can be added here

            return true;
        }

        public string confirmUpdateBooking(Booking updatedBooking)
        {
            if (originalBooking != null && originalBooking.Id == updatedBooking.Id)
            {
                // Update the properties of the original booking
                originalBooking.StartDateTime = updatedBooking.StartDateTime;
                originalBooking.EndDateTime = updatedBooking.EndDateTime;
                originalBooking.ReturnMethod = updatedBooking.ReturnMethod;
                originalBooking.PickUpMethod = updatedBooking.PickUpMethod;
                originalBooking.DropOffTo = updatedBooking.DropOffTo;
                originalBooking.PickUpFrom = updatedBooking.PickUpFrom;

                string successMessage = "Booking updated Successfully";
                return successMessage;
            }
            else
            {
                string errorMessage = "Original booking not found or mismatched.";
                return errorMessage;
            }
        }

        public string processCancelBooking(Booking booking)
        {

            return "";
        }
    }
}
