using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    internal class CTL_manageCar
    {
        public List<Car> getRegisteredCars(CarOwner carOwner)
        {
            return carOwner.getAllRegisteredCars();
        }
        public (bool, Car) selectCar(int carID, List<Car> cars)
        {

            Car? selectedCar = null;
            bool validateSelection(int carID, List<Car> cars)
            {
                foreach (Car car in cars)
                {
                    if (car.Id == carID)
                    {
                        selectedCar = car;
                        return true;
                    }
                }
                return false;
            }
            bool selectionValid = validateSelection(carID, cars);
            return (selectionValid, selectedCar);
        }
        public bool modificationAction(int optionEntered)
        {
            bool modificationActionResponse = false;
            string option = "";
            bool validateOption(int optionEntered)
            {
                if (optionEntered >= 1 && optionEntered <= 3)
                {
                    return true;
                }
                return false;
            }
            modificationActionResponse = validateOption(optionEntered);
            return modificationActionResponse;
        }
        public List<Timeslot> getTimeSlots(Car selectedCar)
        {
            return selectedCar.getTimeSlots();
        }
        public void selectTimes()
        {

        }
        public (bool, List<Timeslot>) selectTimeslots(int startID, int endID, List<Timeslot> registeredTimeslots)
        {
            List<Timeslot> selectedTimeslot = new List<Timeslot>();
            bool validateTimeslots(int startID, int endID, List < Timeslot > registeredTimeslots) 
            {
                bool flag = false;
                foreach (Timeslot timeslot in registeredTimeslots)
                {
                    if (timeslot.Id >= startID && timeslot.Id <= endID)
                    {
                        selectedTimeslot.Add(timeslot);
                        flag = true;
                    }
                }
                return flag;
            }
            return (validateTimeslots(startID, endID, registeredTimeslots), registeredTimeslots);

        }
        public void updateAvailabilityOrRentalRate(int option)
        {

        }
        public void inputNewAvailability(string availability)
        {

        }
        public void inputNewRentalRate(float newRate)
        {

        }
        public void inputNewTimeslotsDateTill(DateTime startDate,  DateTime endDate)
        {

        }
    }
}
