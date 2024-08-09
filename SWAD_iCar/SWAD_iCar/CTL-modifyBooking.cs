using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    internal class CTL_modifyBooking
    {
        private List<Renter> renters;
        private Booking originalBooking;
        private Renter renter;


        public CTL_modifyBooking(List<Renter> renters)
        {
            this.renters = renters;
        }

        public (Booking booking, string errorMessage) ModifyBooking(int renterId, int bookingId)
        {
            renter = GetRenter(renterId);

            if (renter == null)
            {
                return (null, "Renter not found.");
            }

            originalBooking = renter.GetBooking(bookingId);
 
            if (originalBooking == null)
            {
                return (null, "Booking not found.");
            }

            bool isLessThan24Hours = checkIfLessThan24Hours(originalBooking);

            if (isLessThan24Hours)
            {
                return (null, "Cannot modify booking. Less than 24 hours remaining.");
            }

            // Booking can be modified
            return (originalBooking, null);
        }


        public Renter GetRenter(int renterId)
        {
            renter = renters.FirstOrDefault(r => r.Id == renterId);

            return renter;
        }

        public bool checkIfLessThan24Hours(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking));
            }
            return (booking.StartDateTime - DateTime.Now).TotalHours < 24;
        }

        public void updateBooking(int bookingId, Booking booking)
        {
            // Validate the booking before updating
            //bool isValid = validateUpdateBooking(booking);
        }

        public (Booking booking, string errorMessage) validateUpdateBooking(Booking updatedBooking)
        {
            // Validate StartDateTime
            if (updatedBooking.StartDateTime <= DateTime.Now)
            {
                return (null, "Start DateTime must be in the future.");
            }

            // Validate EndDateTime
            if (updatedBooking.EndDateTime <= updatedBooking.StartDateTime)
            {
                return (null, "End DateTime must be after Start DateTime.");
            }

            // Validate ReturnMethod
            if (updatedBooking.ReturnMethod == null)
            {
                return (null, "Return Method cannot be empty.");
            }

            // Validate PickUpMethod
            if (updatedBooking.PickUpMethod == null)
            {
                return (null, "Pick Up Method cannot be empty.");
            }

            // Validate DropOffTo
            if (updatedBooking.DropOffTo == null)
            {
                return (null, "Drop Off To location cannot be empty.");
            }

            // Validate PickUpFrom
            if (updatedBooking.PickUpFrom == null)
            {
                return (null, "Pick Up From location cannot be empty.");
            }

            // If all validations pass
            return (updatedBooking, string.Empty);
        }


        public string confirmUpdateBooking(Booking updatedBooking)
        {
            string bookingUpdateResult = originalBooking.ConfirmUpdateBooking(updatedBooking);
            return bookingUpdateResult;
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
