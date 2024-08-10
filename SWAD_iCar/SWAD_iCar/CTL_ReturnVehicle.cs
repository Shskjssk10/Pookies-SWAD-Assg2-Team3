using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    public class CTL_ReturnVehicle
    {
        private Renter renter1;
        private Booking currentBooking;
        private DateTime returnTime;

        public UI_ReturnVehicle uiReturnVehicle;
        public CTL_ReturnVehicle()
        {
            uiReturnVehicle = new UI_ReturnVehicle(this);
        }

        public Booking InitiateCarReturn(int renterId)
        {
            renter1 = GetRenter(renterId);
            currentBooking = renter1.GetCurrentBooking();
            return currentBooking;
            //return currentBooking;
        }

        public Renter GetRenter(int renterId)
        {
            //can i use program here
            return Program.dummyRenter; 
        }

        public bool CheckLocation(string currentAddress)
        {
            //method 1
            //return currentBooking.CheckLocation(currentAddress);

            //revised method
            if (currentAddress == currentBooking.ReturnMethod.Address)
            {
                return true;
            }
            return false;
        }

        public void SetReturnTime()
        {
            returnTime = currentBooking.SetReturnTime();
            renter1.CompleteExistingBooking(); //CompleteExistingBooking

            //
            //bool penalty = checkPenalty();
            //float PenaltyFee = 0;

            //if (penalty)
            //{
            //    PenaltyFee = calculatePenalty();
            //}
            //notifyAdmin();

            //float DamagesFee = updateInspectionStatus();
            //uiReturnVehicle.displayAnyCharges(PenaltyFee, DamagesFee);
        }

        public float checkPenalty()
        {
            float penaltyFee = 0;
            //how is this in seq diagram
            if (returnTime > currentBooking.EndDateTime)
            {
                penaltyFee = currentBooking.CalculatePenalty(returnTime);
            }

            return penaltyFee;
        }

        //public float calculatePenalty()
        //{
        //    penaltyFee = currentBooking.CalculatePenalty(returnTime);
        //    return penaltyFee;
        //}

        public void notifyAdmin()
        {
            Program.pendingBookings.Add(currentBooking);
        }

        public float checkDamagesFee()
        {
            return currentBooking.DamagesFee;
        }

        public Transaction makePayment(float bookingFee)
        {
            Transaction transaction = renter1.MakePayment(bookingFee);
            addNewTransaction(transaction);
            return transaction;
        }

        public void addNewTransaction(Transaction transaction)
        {
            currentBooking.addNewTransaction(transaction);
        }
    }
}
