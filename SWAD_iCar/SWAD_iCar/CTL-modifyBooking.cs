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
        private Booking originalBooking;


        public CTL_modifyBooking(int bookingIdToModify, List<Renter> renters)
        {
            this.bookingIdToModify = bookingIdToModify;
            this.renters = renters;
        }

        public (Booking booking, string errorMessage) ModifyBooking(int renterId, int bookingId)
        {
            Renter renter = GetRenter(renterId);

            originalBooking = renter.GetBooking(bookingId);

            bool isLessThan24Hours = checkIfLessThan24Hours(originalBooking);

            if (originalBooking == null)
            {
                return (null, "Booking not found.");

            }

            if (isLessThan24Hours == true)
            {
                return (null, "Cannot modify booking. Less than 24 hours remaining.");
            }
            else if (isLessThan24Hours == false) { }
            {
                return (originalBooking, null);
            }
        }

        public Renter GetRenter(int renterId)
        {
            Renter renter = renters.FirstOrDefault(r => r.Id == renterId);

            return renter;
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
            return true;
        }

        public string confirmUpdateBooking(Booking updatedBooking)
        {
            string result = originalBooking.ConfirmUpdateBooking(updatedBooking);

            return result;
        }

        public string cancelBooking(Booking booking, int renterId)
        {
            try
            {
                if (originalBooking != null && originalBooking.Id == booking.Id)
                {
                    Renter renter = GetRenter(renterId);

                    if (renter == null)
                    {
                        throw new Exception("Renter not found.");
                    }

                    string result = booking.ProcessCancelBooking(renter);
                    return result;
                }
                else
                {
                    return "Original booking not found or mismatched.";
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"An error occurred while cancelling the booking: {ex.Message}";
                return errorMessage;
            }
        }

    }
}
