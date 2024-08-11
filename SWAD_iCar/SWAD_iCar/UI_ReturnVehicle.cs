﻿using System;
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

        public UI_ReturnVehicle()
        {
            ctlReturnVehicle = new CTL_ReturnVehicle();
        }

        public void InitiateCarReturn(int renterId)
        {
            Booking currentBooking = ctlReturnVehicle.InitiateCarReturn(renterId);
            DisplayBookingDetails(currentBooking);
            promptAddress();
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
            Console.WriteLine($"Vehicle Inspection Status: {currentBooking.VehicleInspectionStatus}");
            Console.WriteLine($"Penalty Fee: {currentBooking.PenaltyFee}");
            Console.WriteLine($"Damages Fee: {currentBooking.DamagesFee}");
            Console.WriteLine($"Total Booking Fee: ${currentBooking.TotalBookingFee}");
            Console.WriteLine($"Booking Status: {currentBooking.BookingStatus}");
            Console.WriteLine($"Car: {currentBooking.Car.Make} {currentBooking.Car.Model}");
            //Console.WriteLine($"Drop Off To: {currentBooking.DropOffTo.Address}");
            //Console.WriteLine($"Pick Up From: {currentBooking.PickUpFrom.Address}");
            Console.WriteLine($"Transactions: {string.Join(", ", currentBooking.BookingTransactions)}");
        }

        public void promptAddress()
        {
            Console.WriteLine("\nEnter your current address: ");
            enterAddress();
        }

        public void enterAddress()
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

                proceedWithPayment(penaltyFee, damagesFee);

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
                Console.WriteLine("No payment is made.\n");
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
                Console.WriteLine("No payment is made.\n");
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
            Console.WriteLine("\nPayment has been made successfully.");
            Console.WriteLine($"Transaction ID: {transaction.Id}, Cost: {transaction.Cost}, Time: {transaction.Time}.\n");
        }
        //public void checkLocation(string currentAddress)
        //{
        //    ctlReturnVehicle.checkLocation(currentAddress);
        //}

        public void displayAnyCharges(string chargesType, float chargesFee)
        {
            Console.WriteLine($"Pending {chargesType} Fee: {chargesFee}\n");
        }

        public void proceedWithPayment(float penaltyFee, float damagesFee)
        {
            //bool penaltyIsPaid = false;
            //bool damagesIsPaid = false;

            if (penaltyFee > 0)
            {
                penaltyPayment(penaltyFee);
            }

            if (damagesFee > 0)
            {
                damagesPayment(damagesFee);
            }

            // Determine which additional charges are unpaid and display accordingly
            //float totalPendingCharges = 0;
            //if (!penaltyIsPaid)
            //{
            //    totalPendingCharges += penaltyFee;
            //}
            //if (!damagesIsPaid)
            //{
            //    totalPendingCharges += damagesFee;
            //}

            //if (totalPendingCharges > 0)
            //{
            //    Console.WriteLine($"Total Pending Additional Charges: ${totalPendingCharges}");
            //}
        }

        public void penaltyPayment(float penaltyFee)
        {
            displayAnyCharges("Penalty", penaltyFee);
            displayPromptPenalty();
            payPenalty(penaltyFee);
        }

        public void damagesPayment(float damagesFee)
        {
            displayAnyCharges("Damages", damagesFee);
            displayPromptDamages();
            payDamages(damagesFee);
        }
    }
}
