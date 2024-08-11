using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    public class CTL_RentVehicle
    {
        private Renter renter;
        private Car car;
        public UI_RentVehicle uiRentVehicle;
        private DateTime start;
        private DateTime end;
        private List<ICarStation> iCarStations;
        private Location pickUpMethod;
        private Location returnMethod;
        private float bookingFee = 0;
        private float addressFee;
        private Transaction transaction;
        public bool RentVehicle(int carId, int renterId)
        {
            car = GetCar(carId);
            renter = GetRenter(renterId);
            return false; // to get the while loop in UI started
        }

        public Car GetCar(int carId)
        {
            return Program.dummyCar; // for assignment purposes
        } 

        public Renter GetRenter(int renterId) 
        {
            return Program.dummyRenter; // for assignment purposes
        }

        public bool CheckAvailability(DateTime start, DateTime end)
        {   
            this.start = start;
            this.end = end;
            return car.CheckAvailability(start, end);
        }
        
        public bool CheckAnyOngoingBooking(DateTime start, DateTime end)
        {
            return renter.CheckAnyOngoingBooking(start, end);
        }

        public List<ICarStation> GetAlliCarStations()
        {
            iCarStations = Program.ListOfiCarStations;
            return Program.ListOfiCarStations;
        }

        public ICarStation GetiCarStation(int iCarStationId)
        {
            foreach (ICarStation carStation in iCarStations)
            {
                if (carStation.Id == iCarStationId)
                {
                    return carStation;
                }
            }
            return null;
        }

        public void SelectiCarStation(int iCarStationId) 
        {
            ICarStation iCarStation = GetiCarStation(iCarStationId);
            if (pickUpMethod == null)
            {
                pickUpMethod = iCarStation;
                return;
            }
            // returnMethod
            returnMethod = iCarStation;
        }

        public bool ValidatePhysicalAddress(string physicalAddress)
        {
            // for purposes of this assignment, assume all physical address are valid
            return true; 
        }

        public float CalculateAddressFee(string physicalAddress)
        {
            // for purposes of this assignment, assume all physical address cost is 2
            return 2;
        }

        public void AddToTotalCost(float fee)
        {
            bookingFee += fee;
        }

        public float CalculateBookingFee(DateTime start, DateTime end)
        {
            return car.RentalRate * (int)((end - start).TotalHours);
        }

        public (Car, Booking) MakePayment()
        {
            transaction = renter.MakePayment(bookingFee);
            if (transaction != null)
            {
                Booking newBooking = renter.CreateBooking(start, end, bookingFee, pickUpMethod, returnMethod, car);
                car.AddNewBooking(newBooking);
                bool status = false;
                car.UpdateTimeSlotsAvailability(start, end, status);
                newBooking.AddNewTransaction(transaction);

                return (car, newBooking);
            }
            // If payment fails or transaction is null, return null for both
            return (null, null);
        }

        public float GetTotalCost()
        {
            float timeSlotFee = CalculateBookingFee(start, end);
            AddToTotalCost(timeSlotFee);
            return bookingFee;
        }
        public void CreatePhysicalAddress(string physicalAddress)
        {
            addressFee = CalculateAddressFee(physicalAddress);
            AddToTotalCost(addressFee);
            Console.WriteLine("TOtla fee now: " + bookingFee);
            PhysicalAddress address = new PhysicalAddress(addressFee, physicalAddress);
            if (pickUpMethod == null)
            {
                pickUpMethod = address; // can be both pickup and return address
                return; 
            }
            returnMethod = address;
        }

        public Booking CreateBooking(DateTime start, DateTime end, float bookingFee, Location pickUpMethod, Location returnMethod, Car car)
        {
            return renter.CreateBooking(start, end, bookingFee, pickUpMethod, returnMethod, car);
        }
    }
}