using SWAD_iCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class UI_manageCar
{
    private CTL_manageCar CTL_manageCar = new CTL_manageCar();
    public List<Car> getRegisteredCars(CarOwner carOwner)
    {
        List<Car> cars = CTL_manageCar.getRegisteredCars(carOwner);
        foreach (Car car in cars)
        {
            car.ToString();
        }
        return cars;
    }
    public Car? selectCar(List<Car> cars)
    {
        while (true)
        {
            int carID = 0;
            Car selectedCar;
            (bool, Car?) selectionValid = (false, null);
            while (carID == 0)
            {
                try
                {
                    Console.Write("Please enter a car ID to select: ");
                    carID = Convert.ToInt32(Console.ReadLine());
                    selectionValid = CTL_manageCar.selectCar(carID, cars);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Make sure an integer is entered");
                    carID = 0;
                }
            }
            if (selectionValid.Item1 == false)
            {
                Console.WriteLine("Car has not been selected!");
            }
            else
            {
                return selectionValid.Item2;
            }
        }
    }
    public string modificationAction()
    {
        int option = 0;
        bool modificationActionResponse = false;
        while (option == 0)
        {
            Console.WriteLine("=====================\n" +
                "[1] Modify Timeslots\n" +
                "[2] Add Timeslots\n" +
                "[3] Remove Timeslot\n" +
                "Enter option: ");
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
                modificationActionResponse = CTL_manageCar.modificationAction(option);
                if (modificationActionResponse == false)
                {
                    Console.WriteLine("Ensure option entered is between 1 to 3");
                    option = 0;
                }
                else
                {
                    break;
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine("Please ensure that an integer is entered.");
            }
        }
        string choice = "";
        switch (option)
        {
            case 1:
                choice = "Modify Timeslots";
                break;
            case 2:
                choice = "Add Timeslots";
                break;
            case 3:
                choice = "Remove Timeslots";
                break;
        }
        return choice;
    }
    public List<Timeslot> getTimeSlots(Car selectedCar)
    {
        List<Timeslot> registeredTimeSlots = CTL_manageCar.getTimeSlots(selectedCar);
        foreach (Timeslot timeslot in registeredTimeSlots)
        {
            timeslot.ToString();
        }
        return registeredTimeSlots;
    }
    public List<Timeslot> selectTimeSlots(List<Timeslot> registeredTimeslots)
    {
        int startID = 0;
        int endID = 0;
        (bool, List<Timeslot>) timeslotsResponse = (false, new List<Timeslot>());
        while (endID == 0)
        {
            try
            {
                Console.Write("Enter the the first timeslot: ");
                startID = Convert.ToInt32(Console.ReadLine());
                endID = Convert.ToInt32(Console.ReadLine());
                timeslotsResponse = CTL_manageCar.selectTimeslots(startID, endID, registeredTimeslots);
                if (timeslotsResponse.Item1 == false)
                {
                    Console.WriteLine("Ensure that the startID is smaller than endID");
                    endID = 0;
                }
                else
                {
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Please ensure that an integer is entered.");
                endID = 0;
            }
        }
        return timeslotsResponse.Item2;
    }
    public void selectTimeslots(int startID, int endID)
    {

    }
    public void updateAvailabilityorRentaRate(int option)
    {

    }
    public void inputNewAvailability(string newStatus)
    {

    }
    public void inputNewRentalRate(float newRate)
    {

    }
    public void inputNewTimeslotsDateTill()
    {

    }
}

