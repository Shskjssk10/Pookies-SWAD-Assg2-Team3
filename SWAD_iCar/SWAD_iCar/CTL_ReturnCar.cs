using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    public class CTL_ReturnCar
    {
        private Renter renter1;
        private Booking currentBooking;
        private DateTime returnTime;

        public Booking InitiateCarReturn(int renterId)
        {
            renter1 = GetRenter(renterId);
            currentBooking = renter1.GetCurrentBooking();
            return currentBooking;
        }

        public Renter GetRenter(int renterId)
        {
            return Program.listOfRenters[renterId - 1];
        }

        public bool CheckLocation(string currentAddress)
        {
            if (currentAddress == currentBooking.ReturnMethod.Address)
            {
                return true;
            }
            return false;
        }

        public void SetReturnTime()
        {
            returnTime = currentBooking.SetReturnTime();
        }

        public Booking CompleteExistingBooking()
        {
            renter1.CompleteExistingBooking();
            return currentBooking;
        }

        public float CheckPenalty()
        {
            float penaltyFee = 0;
            if (returnTime > currentBooking.EndDateTime)
            {
                penaltyFee = currentBooking.CalculatePenalty(returnTime);
            }

            return penaltyFee;
        }

        public void NotifyAdmin()
        {
            Program.pendingBookings.Add(currentBooking);
        }

        public float CheckDamagesFee()
        {
            return currentBooking.DamagesFee;
        }

        public Transaction MakePayment(float bookingFee)
        {
            Transaction transaction = renter1.MakePayment(bookingFee);
            currentBooking.AddNewTransaction(transaction);
            return transaction;
        }
    }
}
