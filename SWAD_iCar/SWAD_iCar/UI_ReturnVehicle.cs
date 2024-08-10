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

        public void InitiateCarReturn(int renterId)
        {
            Booking currentBooking = ctlReturnVehicle.InitiateCarReturn(renterId);
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
            Console.WriteLine("Enter your current address: ");
            enterAddress();
        }

        public void enterAddress()
        {
            //while loop (infinite)
            //bool result = false;
            //while (!result)
            //{
            //    string currentAddress = Console.ReadLine().Trim();
            //    result = ctlReturnVehicle.CheckLocation(currentAddress);
            //    //does this need to be displayed in seq diagram
            //    if (!result)
            //    {
            //        Console.WriteLine("Wrong Address!\n"); 
            //    }
            //}

            //loop with tries (3 max times)
            //int tries = 0;
            //int maximumTries = 3;
            //while (tries < maximumTries)
            //{
            //    string currentAddress = Console.ReadLine().Trim();
            //    result = ctlReturnVehicle.CheckLocation(currentAddress);
            //    if (!result)
            //    {
            //        Console.WriteLine("Wrong Address!\n");
            //    }
            //}

            bool result = false;
            int tries = 0;
            int maximumTries = 3;

            while (tries < maximumTries && !result)
            {
                string currentAddress = Console.ReadLine().Trim();
                result = ctlReturnVehicle.CheckLocation(currentAddress);

                if (result == false)
                {
                    Console.WriteLine("Wrong Address!\n");
                    tries++;
                }
            }

            if (result == false)
            {
                // Continue with the next function (out of the loop)
                Console.WriteLine("Maximum tries reached. Exiting.");
            }
            else
            {
                // Handle the case when the maximum number of tries is reached without success
                promptReturnConfirmation();
            }


            //is this ok?????

            //ctlReturnVehicle.SetReturnTime();
            //displayUpdateSuccess();
            //float penaltyFee = ctlReturnVehicle.checkPenalty();
            //ctlReturnVehicle.notifyAdmin();
            //float damagesFee = ctlReturnVehicle.updateInspectionStatus();
            //displayAnyCharges(penaltyFee, damagesFee);

            //if (penaltyFee > 0)
            //{
            //    payPenalty(penaltyFee);
            //}

            //if (damagesFee > 0)
            //{
            //    payDamages(damagesFee);
            //}



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

        public void promptReturnConfirmation()
        {
            Console.Write("\nProceed with returning of car? (yes/no): ");
            proceedWithReturn();
        }

        public void proceedWithReturn()
        {
            string confirmation = Console.ReadLine().Trim().ToLower();
            if (confirmation == "yes")
            {
                ctlReturnVehicle.SetReturnTime();
                displayUpdateSuccess();
                float penaltyFee = ctlReturnVehicle.checkPenalty();
                ctlReturnVehicle.notifyAdmin();
                float damagesFee = ctlReturnVehicle.checkDamagesFee();
                displayAnyCharges(penaltyFee, damagesFee);

                if (penaltyFee > 0)
                {
                    displayPromptPenalty();
                    payPenalty(penaltyFee);
                }

                if (damagesFee > 0)
                {
                    displayPromptDamages();
                    payDamages(damagesFee);
                }
            }
            else
            {
                Console.WriteLine("Returning of car failed.\n");
            }
        }

        public void displayUpdateSuccess()
        {
            Console.WriteLine("\nBooking is completed.\n");
        }
        
        public void payPenalty(float penaltyFee)
        {

            string confirmation = Console.ReadLine().Trim().ToLower();
            if (confirmation == "yes")
            {
                Transaction transaction = ctlReturnVehicle.makePayment(penaltyFee);
                //ctlReturnVehicle.addNewTransaction(transaction);
                displayPaymentSuccess(transaction);
            }
            else
            {
                Console.WriteLine("Payment Unsuccessful.\n");
            }
            
        }

        public void payDamages(float damagesFee)
        {
            string confirmation = Console.ReadLine().Trim().ToLower();
            if (confirmation == "yes")
            {
                Transaction transaction = ctlReturnVehicle.makePayment(damagesFee);
                //ctlReturnVehicle.addNewTransaction(transaction);
                displayPaymentSuccess(transaction);
            }
            else
            {
                Console.WriteLine("Payment Unsuccessful.\n");
            }
            
        }

        public void displayPromptPenalty()
        {
            Console.WriteLine("Make Payment for Penalty Fee");
            Console.Write("Proceed with the payment for penalty? (yes/no): ");
        }

        public void displayPromptDamages()
        {
            Console.WriteLine("Make Payment for Damages Fee");
            Console.Write("Proceed with the payment for damages? (yes/no): ");
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
        }
    }
}
