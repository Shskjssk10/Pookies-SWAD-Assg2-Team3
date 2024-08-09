using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    internal class CTL_ManageCar
    {
        private List<CarOwner> listOfCarOwners;
        private CarOwner carOwner;
        private List<Car> carOwnerCars;
        private Car selectedCar;
        
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
        public void getTimeSlots()
        {

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
        public void displayTimeslots(List<Timeslot> selectedTimeslots)
        {

        }
        public void inputNewRentalRate(float newRate)
        {

        }
        public DateTime? inputNewTimeslotsDateTill(DateTime inputDate)
        {
            DateTime currentDate = DateTime.Now.Date;
            if (inputDate <= currentDate) // Only show error message if there was previous input
            {
                Console.WriteLine("Error1");
                return null;
            }
            DateTime processedDate = inputDate.Date;
            processedDate = processedDate.AddHours(23).AddMinutes(59);
            currentDate = currentDate.AddHours(24);
            while (currentDate <= processedDate)
            {
                currentDate = currentDate.AddHours(1);
                selectedCar.AddNewTimeSlot(new Timeslot(currentDate, true, selectedCar));
            }
            return processedDate;
        }
    }
}
