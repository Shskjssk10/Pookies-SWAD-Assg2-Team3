using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SWAD_iCar
{
    internal class CTL_ManageCar
    {
        private List<CarOwner> listOfCarOwners;
        private CarOwner carOwner;
        private List<Car> carOwnerCars;
        private Car selectedCar;
        private List<Timeslot> registeredTimeslots;
        private List<Timeslot> selectedTimeslots;


        public int validateOption(int option, int max)
        {
            if (option > max || option < 0)
            {
                return 0;
            }
            return option;
        }
        public CTL_ManageCar(List<CarOwner> carOwnerList)
        {
            listOfCarOwners = carOwnerList;
        }

        public (CarOwner, List<Car>) getRegisteredCars(int userId)
        {
            getCarOwner(userId);
            List<Car> cars = carOwner.getAllRegisteredCars();
            carOwnerCars = cars;
            return (carOwner, cars);
        }
        public void getCarOwner(int userId) 
        {
            carOwner = listOfCarOwners.FirstOrDefault(owner => owner.Id == userId);
        }
        public Car? selectCar(int carID)
        {
            return getCar(carID);
        }
        public Car getCar(int carID)
        {
            selectedCar = carOwnerCars.FirstOrDefault(car => car.Id == carID);
            return selectedCar;
        }
        public int modificationAction(int option)
        {
            return validateOption(option, 3);
        }
        public List<Timeslot> getTimeSlots()
        {
            registeredTimeslots = selectedCar.GetTimeSlots();
            return registeredTimeslots;
        }
        public List<Timeslot> selectTimeslots(int startID, int endID)
        {
            selectedTimeslots = registeredTimeslots.Where(timeslot => timeslot.Id >= startID && timeslot.Id <= endID).ToList();
            return selectedTimeslots;
        }

        public bool removeTimeslots(int startID, int endID)
        {
            bool flag = false;
            foreach (Timeslot timeslot in selectedTimeslots)
            {
                flag = selectedCar.RemoveTimeSlots(startID, endID);
            }
            return flag;
        }
        public int availabilityOrRateChange(int option)
        {
            return validateOption(option, 2);
        }
        public bool inputNewAvailability(int newStatus)
        {
            newStatus = validateOption(newStatus, 2);
            if (newStatus == 0)
            {
                return false;
            }
            selectedCar.UpdateTimeSlotsAvailability(selectedTimeslots, newStatus);
            return true;
        }
        public float inputNewRentalRate(float newRate)
        {
            if (newRate <= 0)
            {
                return 0;
            }
            selectedCar.UpdateRentalRate(newRate);
            return newRate; 
        }

        // Still need fixing
        public DateTime? inputNewTimeslotsDateTill(DateTime inputDate)
        {
            DateTime currentDate = DateTime.Now.Date;
            if (inputDate <= currentDate) // Only show error message if there was previous input
            {
                return null;
            }
            DateTime processedDate = inputDate.Date;
            processedDate = processedDate.AddHours(23).AddMinutes(59);
            currentDate = currentDate.AddHours(24);
            while (currentDate < processedDate)
            {
                selectedCar.AddNewTimeSlot(new Timeslot(currentDate, true, selectedCar));
                currentDate = currentDate.AddHours(1);
            }
            return processedDate;
        }
    }
}
