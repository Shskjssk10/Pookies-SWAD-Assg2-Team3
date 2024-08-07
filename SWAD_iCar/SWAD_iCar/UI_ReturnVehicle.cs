using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SWAD_iCar
{
    public class UI_ReturnVehicle
    {
        private CTL_ReturnVehicle ctlReturnVehicle;

        public UI_ReturnVehicle(CTL_ReturnVehicle ctlReturnVehicle)
        {
            this.ctlReturnVehicle = ctlReturnVehicle;
        }

        public void ReturnCar(int renterId)
        {
            Booking currentBooking = ctlReturnVehicle.ReturnCar(renterId);
            DisplayBookingDetails(currentBooking);
            promptAddress(); 
        }

        public void DisplayBookingDetails(Booking currentBooking)
        {
            //improve the displaying of this
            Console.WriteLine($"Booking ID: {currentBooking.Id}\n" +
                $"Start Time: {currentBooking.StartDateTime}\n" +
                $"End Time: {currentBooking.EndDateTime}\n" + 
                $"Pick Up From: {currentBooking.PickUpMethod.Address}\n" +
                $"Drop Off To: {currentBooking.ReturnMethod.Address}\n");

            //ctlReturnVehicle.getRenter();
        }

        public void promptAddress()
        {
            Console.Write("Enter your current address: ");
            enterAddress();
        }

        public void enterAddress()
        {
            bool result = false;
            do
            {
                string currentAddress = Console.ReadLine().Trim();
                result = ctlReturnVehicle.CheckLocation(currentAddress);
                if (!result)
                {
                    Console.WriteLine("Wrong Address!\n"); //does this need to be displayed in seq diagram
                } 
            } while (!result);

            ctlReturnVehicle.SetReturnTime();
            displayUpdateSuccess();


            //bool penalty = ctlReturnVehicle.checkPenalty();
            //float penaltyFee = 0;

            //if (penalty)
            //{
            //    penaltyFee = ctlReturnVehicle.calculatePenalty();
            //}

            //ctlReturnVehicle.notifyAdmin();
            //float damagesFee = ctlReturnVehicle.updateInspectionStatus();
            
            //HMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
            //if(penaltyFee != 0)
            //{

            //    payPenalty(penaltyFee);
            //}

            //if(damagesFee != 0)
            //{
            //    payDamages(damagesFee);
            //}
        }

        public void displayUpdateSuccess()
        {
            Console.WriteLine("Booking updated");
        }
        
        public void payPenalty(float penaltyFee)
        {
            Console.WriteLine("Make Payment for Penalty Fee");
            Console.Write("Enter yes to pay penalty: ");
            string answer = Console.ReadLine().Trim().ToLower();
            if (answer == "yes")
            {
                Transaction transaction = ctlReturnVehicle.makePayment(penaltyFee);
                ctlReturnVehicle.addNewTransaction(transaction);
                displayPaymentSuccess(transaction);
            }
            else
            {
                Console.WriteLine("Payment Unsuccessful.");
            }
            
        }

        public void payDamages(float damagesFee)
        {
            //should this be in the seq diagram
            Console.WriteLine("Make Payment for Damages Fee");
            Console.Write("Enter yes to pay damages: ");
            string answer = Console.ReadLine().Trim().ToLower();
            if (answer == "yes")
            {
                Transaction transaction = ctlReturnVehicle.makePayment(damagesFee);
                ctlReturnVehicle.addNewTransaction(transaction);
                displayPaymentSuccess(transaction);
            }
            else
            {
                Console.WriteLine("Payment Unsuccessful.");
            }
            
        }

        public void displayPaymentSuccess(Transaction transaction)
        {
            Console.WriteLine($"Transaction ID: {transaction.Id}, Cost: {transaction.Cost}, Time: {transaction.Time}.\n");
        }
        //public void checkLocation(string currentAddress)
        //{
        //    ctlReturnVehicle.checkLocation(currentAddress);
        //}

        public void displayAnyCharges(float PenaltyFee, float DamagesFee)
        {
            Console.WriteLine("Pending Fees: \n" +
                $"Penalty Fee: {PenaltyFee}\n" +
                $"Damages Fee: {DamagesFee}\n");

            if (PenaltyFee != 0)
            {
                payPenalty(PenaltyFee);
            }

            if (DamagesFee != 0)
            {
                payDamages(DamagesFee);
            }
        }
    }
}
