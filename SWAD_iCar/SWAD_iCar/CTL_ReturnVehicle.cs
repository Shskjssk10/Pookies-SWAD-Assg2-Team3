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
        private float penaltyFee;
        private float damagesFee;

        public UI_ReturnVehicle uiReturnVehicle;
        public CTL_ReturnVehicle()
        {
            uiReturnVehicle = new UI_ReturnVehicle(this);
        }

        public Booking ReturnCar(int renterId)
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
            return currentBooking.CheckLocation(currentAddress);
        }

        public void SetReturnTime()
        {
            returnTime = currentBooking.SetReturnTime();
            bool result = renter1.UpdateBooking();
            bool penalty = checkPenalty();
            float PenaltyFee = 0;

            if (penalty)
            {
                PenaltyFee = calculatePenalty();
            }
            notifyAdmin();

            float DamagesFee = updateInspectionStatus();
            uiReturnVehicle.displayAnyCharges(PenaltyFee, DamagesFee);
        }

        public bool checkPenalty()
        {
            if (returnTime > currentBooking.EndDateTime)
            {
                return true;
            }
            return false;
        }

        public float calculatePenalty()
        {
            penaltyFee = currentBooking.CalculatePenalty(returnTime);
            return penaltyFee;
        }

        public void notifyAdmin()
        {
            Program.pendingBookings.Add(currentBooking);
        }

        public float updateInspectionStatus()
        {
            return damagesFee = Program.dummyAdmin.UpdateInspectionStatus();
        }

        public Transaction makePayment(float bookingFee)
        {
            return renter1.MakePayment(bookingFee);
        }

        public void addNewTransaction(Transaction transaction)
        {
            currentBooking.addNewTransaction(transaction);
        }
    }
}
