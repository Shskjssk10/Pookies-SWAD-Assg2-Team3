using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SWAD_iCar
{
    public class UI_ReturnCar
    {
        private CTL_ReturnCar ctlReturnVehicle;

        public UI_ReturnCar()
        {
            ctlReturnVehicle = new CTL_ReturnCar();
        }

        public void InitiateCarReturn(int renterId)
        {
            Booking currentBooking = ctlReturnVehicle.InitiateCarReturn(renterId);
            DisplayBookingDetails(currentBooking);
            PromptAddress();
        }

        public void DisplayBookingDetails(Booking currentBooking)
        {
            Console.WriteLine("Booking Details:");
            Console.WriteLine($"ID: {currentBooking.Id}");
            Console.WriteLine($"Start DateTime: {currentBooking.StartDateTime}");
            Console.WriteLine($"End DateTime: {currentBooking.EndDateTime}");
            Console.WriteLine($"Return DateTime: {(currentBooking.ReturnTime == null ? "Car has yet to be returned" : currentBooking.ReturnTime.ToString())}");
            Console.WriteLine($"Return Method: {currentBooking.ReturnMethod.Address}");
            Console.WriteLine($"Pick Up Method: {currentBooking.PickUpMethod.Address}");
            Console.WriteLine($"Car: {currentBooking.Car.Make} {currentBooking.Car.Model}");
        }

        public void PromptAddress()
        {
            Console.WriteLine("\nEnter your current address: ");
            EnterAddress();
        }

        public void EnterAddress()
        {

            bool result = false;
            int tries = 0;
            int maximumTries = 3;

            while (tries < maximumTries && !result)
            {
                string currentAddress = Console.ReadLine().Trim();
                result = ctlReturnVehicle.CheckLocation(currentAddress);

                if (result == false)
                {
                    DisplayIncorrectLocation();
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
                PromptReturnConfirmation();
            }

        }

        public void DisplayIncorrectLocation()
        {
            Console.WriteLine("Wrong Address!\n");
        }

        public void PromptReturnConfirmation()
        {
            Console.Write("\nProceed with returning of car? (yes/no): ");
            ProceedWithReturn();
        }

        public void ProceedWithReturn()
        {
            string confirmation = Console.ReadLine().Trim().ToLower();
            if (confirmation == "yes")
            {
                ctlReturnVehicle.SetReturnTime();
                Booking currentBooking = ctlReturnVehicle.CompleteExistingBooking();
                DisplayBookingDetails(currentBooking);
                DisplayUpdateSuccess();
                float penaltyFee = ctlReturnVehicle.CheckPenalty();
                ctlReturnVehicle.NotifyAdmin();
                float damagesFee = ctlReturnVehicle.CheckDamagesFee();

                ProceedWithPayment(penaltyFee, damagesFee);

            }
            else
            {
                Console.WriteLine("Returning of car failed.\n");
            }
        }

        public void DisplayUpdateSuccess()
        {
            Console.WriteLine("\nBooking is completed.\n");
        }

        public void PayPenalty(float penaltyFee)
        {

            string confirmation = Console.ReadLine().Trim().ToLower();
            if (confirmation == "yes")
            {
                Transaction transaction = ctlReturnVehicle.MakePayment(penaltyFee);
                DisplayPaymentSuccess(transaction);
            }
            else
            {
                Console.WriteLine("No payment is made.\n");
            }

        }

        public void PayDamages(float damagesFee)
        {
            string confirmation = Console.ReadLine().Trim().ToLower();
            if (confirmation == "yes")
            {
                Transaction transaction = ctlReturnVehicle.MakePayment(damagesFee);
                DisplayPaymentSuccess(transaction);
            }
            else
            {
                Console.WriteLine("No payment is made.\n");
            }

        }

        public void DisplayPromptPenalty()
        {
            Console.WriteLine("Make Payment for Penalty Fee");
            Console.Write("Proceed with the payment for penalty? (yes/no): ");
        }

        public void DisplayPromptDamages()
        {
            Console.WriteLine("Make Payment for Damages Fee");
            Console.Write("Proceed with the payment for damages? (yes/no): ");
        }

        public void DisplayPaymentSuccess(Transaction transaction)
        {
            Console.WriteLine("\nPayment has been made successfully.");
            Console.WriteLine($"Transaction ID: {transaction.Id}, Cost: {transaction.Cost}, Time: {transaction.Time}.\n");
        }

        public void DisplayAnyCharges(string chargesType, float chargesFee)
        {
            Console.WriteLine($"Pending {chargesType} Fee: {chargesFee}\n");
        }

        public void ProceedWithPayment(float penaltyFee, float damagesFee)
        {
            if (penaltyFee > 0)
            {
                PenaltyPayment(penaltyFee);
            }

            if (damagesFee > 0)
            {
                DamagesPayment(damagesFee);
            }
        }

        public void PenaltyPayment(float penaltyFee)
        {
            DisplayAnyCharges("Penalty", penaltyFee);
            DisplayPromptPenalty();
            PayPenalty(penaltyFee);
        }

        public void DamagesPayment(float damagesFee)
        {
            DisplayAnyCharges("Damages", damagesFee);
            DisplayPromptDamages();
            PayDamages(damagesFee);
        }
    }
}
