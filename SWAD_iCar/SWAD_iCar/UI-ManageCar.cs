using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace SWAD_iCar
{
    internal class UI_ManageCar
    {
        private CTL_ManageCar CTL_ManageCar;
        private List<Car> cars;
        private CarOwner carOwner;
        private Car selectedCar;
        private UI_Main UI_Mainn;
        private List<Timeslot> registeredTimeslots;
        private List<Timeslot> selectedTimeslots;
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
        public void displayTimeslots(List<Timeslot> timeslots)
        {
            foreach (Timeslot timeslot in timeslots)
            {
                timeslot.ToString();
            }
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
            (int, int) selectTimeslotsResponse;
            switch (timeslotModificationChoice)
            {
                case 1:
                    registeredTimeslots = CTL_ManageCar.getTimeSlots();
                    Console.WriteLine("\nRegistered Timeslots:\n=====================================================");
                    if (registeredTimeslots.Count == 0)
                    {
                        Console.WriteLine("(There are no registered timeslots)");
                        break;
                    }
                    displayTimeslots(registeredTimeslots);
                    selectTimeslotsResponse = selectTimeslots();
                    availabilityOrRateChange();
                    break;
                case 2:
                    inputNewTimeslotsDateTill();
                    break;
                case 3:
                    registeredTimeslots = CTL_ManageCar.getTimeSlots();
                    Console.WriteLine("\nRegistered Timeslots:\n=====================================================");
                    if (registeredTimeslots.Count == 0)
                    {
                        Console.WriteLine("(There are no registered timeslots)");
                        break;
                    }
                    displayTimeslots(registeredTimeslots);
                    selectTimeslotsResponse = selectTimeslots();
                    removeTimeslots(selectTimeslotsResponse.Item1, selectTimeslotsResponse.Item2);
                    break;
            }
        }
        public (int, int) selectTimeslots()
        {
            int startID = 0;
            int endID = 0;
            string message = "";
            while (true)
            {
                try
                {
                    Console.Write("Enter startID: ");
                    startID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter endID: ");
                    endID = Convert.ToInt32(Console.ReadLine());
                    selectedTimeslots = CTL_ManageCar.selectTimeslots(startID, endID);
                    if (startID > endID)
                    {
                        message = "Pleasae ensure that the startID is not bigger than the endID";
                        displayErrorMessage(message);
                    }
                    else if (selectedTimeslots.Count == 0)
                    {
                        message = "There were no timeslots selected. Please try again!";
                        displayErrorMessage(message);
                    }
                    else
                    {
                        return (startID, endID);
                    }
                }
                catch (Exception e)
                {
                    message = e.ToString();
                    displayErrorMessage(message);
                }
            }
        }
        public void removeTimeslots(int startID, int endID)
        {
            bool status = CTL_ManageCar.removeTimeslots(startID, endID);
            string message = "There is an error removing the timeslots";
            switch (status)
            {
                case true:
                    Console.WriteLine("\nRemoved Timeslots:\n=====================================================");
                    displayTimeslots(selectedTimeslots);
                    break;
                case false:
                    displayErrorMessage(message);
                    break;
            }
        }
        public void availabilityOrRateChange()
        {
            string message = "";
            int option = 0;
            int processedOption = 0;
            Console.WriteLine("\nChoose Modification Choice:" +
                "\n=====================================================" +
                "\n[1] Timeslot Availability" +
                "\n[2] Timeslot Rental Rate");
            while (processedOption == 0)
            {
                try
                {
                    Console.Write("Enter option: ");
                    option = Convert.ToInt32(Console.ReadLine());
                    processedOption = CTL_ManageCar.availabilityOrRateChange(option);
                    if (processedOption == 0)
                    {
                        message = "Please ensure to input an integer between 1 to 2";
                        displayErrorMessage(message);
                        processedOption = 0;
                    }
                }
                catch (Exception ex)
                {
                    message = "Please ensure that an integer is inputted.";
                    displayErrorMessage(message);
                }
            }
            Console.WriteLine(processedOption);
            switch (processedOption)
            {
                case 1:
                    inputNewAvailability();
                    break;
                case 2:
                    inputNewRentalRate();
                    break;
            }
        }
        public void inputNewAvailability()
        {
            int newStatus = 0;
            bool inputAvailabilityResponse = false;
            string message = "";
            Console.WriteLine("\nChoose new Availability:" +
                        "\n=====================================================" +
                        "\n[1] Available" +
                        "\n[2] Unavailable");
            while (newStatus == 0)
            {
                try
                {
                    Console.Write("Input: ");
                    newStatus = Convert.ToInt32(Console.ReadLine());
                    inputAvailabilityResponse = CTL_ManageCar.inputNewAvailability(newStatus);
                    switch (inputAvailabilityResponse)
                    {
                        case true:
                            Console.WriteLine("\nUpdated Timeslots:" +
                                "\n=====================================================");
                            displayTimeslots(selectedTimeslots);
                            break;
                        case false:
                            message = "An error occured when timeslots are being added";
                            displayErrorMessage(message);
                            break;
                    }
                }
                catch (FormatException e)
                {
                    message = "Please ensure either true or false";
                    displayErrorMessage(message);
                }
            }
        }
        public void inputNewRentalRate()
        {
            float newRate = 0;
            string message = "";
            Console.WriteLine("\nEnter New Rate\n=====================================================");
            while (true)
            {
                try
                {
                    Console.Write("Input: ");
                    newRate = float.Parse(Console.ReadLine());
                    newRate = CTL_ManageCar.inputNewRentalRate(newRate);
                    if (newRate == 0)
                    {
                        message = "Please ensure that a positive float number is entered.";
                        displayErrorMessage(message);
                    }
                    else
                    {
                        Console.WriteLine("Rate has been successfully updated!");
                        break;

                    }
                }
                catch (FormatException e)
                {
                    message = "Ensure that a float is entered.";
                    displayErrorMessage(message);
                }
            }
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
