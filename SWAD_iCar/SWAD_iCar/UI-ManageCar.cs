using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    internal class UI_ManageCar
    {
        private CTL_ManageCar CTL_ManageCar;
        private List<Car> cars;
        private CarOwner carOwner;
        private Car selectedCar;
        private UI_Main UI_Mainn;
        public void displayErrorMessage(string message)
        {
            Console.WriteLine(message);
        }
        public UI_ManageCar(CTL_ManageCar ctl_ManagerCar, UI_Main ui_main) 
        {
            CTL_ManageCar = ctl_ManagerCar;
            UI_Mainn = ui_main;
        }
        public void getRegisteredCars(int userId)
        {
            (CarOwner, List<Car>) response = CTL_ManageCar.getRegisteredCars(userId);
            carOwner = response.Item1;
            cars = response.Item2;
            displayCars(cars);
            selectCar();
        }
        public void displayCars(List<Car> cars)
        {
            Console.WriteLine("\nList of Registerd Cars:\n=====================================================");
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
        public void displayCar(Car car)
        {
            Console.WriteLine("\nSelected Car:\n=====================================================");
            Console.WriteLine(car.ToString());
        }
        public void selectCar()
        {
            string message;
            Car? selectedCar = null;
            while (selectedCar == null)
            {
                try
                {
                    Console.Write("Enter Car ID: ");
                    int carID = Convert.ToInt32(Console.ReadLine());
                    selectedCar = CTL_ManageCar.selectCar(carID);
                    if (selectedCar == null)
                    {
                        message = "Please ensure that the correct Car ID has been entered";
                        displayErrorMessage(message);
                    }
                    else
                    {
                        displayCar(selectedCar);
                        modificationAction();
                    }
                }
                catch (Exception ex)
                {
                    message = "Please ensure that an integer is entered.";
                    displayErrorMessage(message);
                }
            }
        }
        public void modificationAction()
        {
            string message = "";
            int option = 0;
            int timeslotModificationChoice = 0;
            Console.WriteLine("\nChoose Modification Choice:" +
                "\n=====================================================" +
                "\n[1] Modify Existing Timeslots" +
                "\n[2] Add Timeslots" +
                "\n[3] Remove Timeslots");
            while (timeslotModificationChoice == 0)
            {
                try
                {
                    Console.Write("Enter option: ");
                    option = Convert.ToInt32(Console.ReadLine());
                    timeslotModificationChoice = CTL_ManageCar.modificationAction(option);
                    if (timeslotModificationChoice == 0)
                    {
                        message = "Please ensure to input an integer between 1 to 3";
                        displayErrorMessage(message);
                        timeslotModificationChoice = 0;
                    }
                }
                catch (Exception ex)
                {
                    message = "Please ensure that an integer is inputted.";
                    displayErrorMessage(message);
                }
            }
            switch (timeslotModificationChoice)
            {
                case 1:
                    break;
                case 2:
                    inputNewTimeslotsDateTill();
                    break;
                case 3:
                    break;
            }
        }
        public void selectTimeslots(int startID, int endID)
        {

        }
        public void availabilityOrRateChange(int option)
        {

        }
        public void inputNewAvailability(bool newStatus)
        {

        }
        public void inputNewRentalRate(float newRate)
        {

        }
        public void inputNewTimeslotsDateTill()
        {
            DateTime inputDate;
            DateTime? processedDate;
            string message;
            Console.WriteLine("\nAdding of Timeslots:\n=====================================================");
            Console.Write("Ensure that date entered is of the following format [YYYY/MM/DD]");
            while (true)
            {
                try
                {
                    Console.Write("\nInput: ");
                    inputDate = Convert.ToDateTime(Console.ReadLine());
                    processedDate = CTL_ManageCar.inputNewTimeslotsDateTill(inputDate);
                    if (processedDate == null)
                    {
                        message = "Please ensure that date entered is after the current date.";
                        displayErrorMessage(message);
                    }
                    else
                    {
                        Console.WriteLine("Timeslots have been successfully added!");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    message = "Please ensure a date is entered";
                    displayErrorMessage(message);
                }
            }
        }
    }
}
