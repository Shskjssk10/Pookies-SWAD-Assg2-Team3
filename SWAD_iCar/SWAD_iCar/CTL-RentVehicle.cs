using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    public class CTL_RentVehicle
    {
        private Renter renter1;
        private Car car1;
        public UI_RentVehicle uiRentVehicle;
        private DateTime start;
        private DateTime end;
        private DateOnly startDate;
        private DateOnly endDate;
        private TimeOnly startTime;
        private TimeOnly endTime;
        private List<ICarStation> iCarStations;
        private Location pickUpMethod;
        private Location returnMethod;
        private string pickUpLocation = null; // placeholder for physical address of pickUpMethod
        private string returnLocation = null; // placeholder for physical address of returnMethod
        private float bookingFee = 0;
        private float addressFee;
        private Transaction transaction;
        private bool validPhysicalAddress = false;

        public CTL_RentVehicle()
        {
            uiRentVehicle = new UI_RentVehicle(this);
        }

        public void RentVehicle(int carId, int renterId)
        {
            car1 = GetCar(carId);
            renter1 = GetRenter(renterId);
            end = DateTime.Now; // to trigger the while loop
            start = end.AddHours(1);
            DateTime currentDate = DateTime.Now;
            DateOnly currentDateOnly = DateOnly.FromDateTime(currentDate);
            startDate = DateOnly.FromDateTime(start);
            startTime = TimeOnly.FromDateTime(start);
            endTime = TimeOnly.FromDateTime(end);

            while (start >= end || start <= currentDate || end <= currentDate || (startDate == currentDateOnly && startTime >= endTime))
            {
                uiRentVehicle.PromptStartAndEndDate();
                if (startDate == endDate && startTime >= endTime)
                {
                    uiRentVehicle.DisplayInvalidDateTimeMessage();
                }
            }

            bool allSlotsAvailable = car1.CheckAvailability(start, end);
            bool anyOngoingBooking = renter1.CheckAnyOngoingBooking(start, end);

            if ((anyOngoingBooking == false) && (allSlotsAvailable == true))
            {   
                // Pick Up Method
                uiRentVehicle.PromptPickUpMethod();

                // Return Method
                uiRentVehicle.PromptReturnMethod();

                // Fee for all time slots
                float timeSlotFee = CalculateBookingFee(start, end);

                // Add to Total booking cost
                AddToTotalCost(timeSlotFee);

                uiRentVehicle.DisplayTotalCost(bookingFee);

                Booking newBooking;
                if (transaction != null)
                {
                    newBooking = CreateBooking(start, end, bookingFee, pickUpMethod, returnMethod, car1);
                    car1.AddNewBooking(newBooking);

                    bool status = false;
                    SetStatusToFalse(status);
                    //car1.UpdateTimeSlotsAvailability(start, end, status);
                    newBooking.AddNewTransaction(transaction);

                    uiRentVehicle.DisplayAllDetails(car1, newBooking);
                }

            }
        }

        public Car GetCar(int carId)
        {
            return Program.dummyCar;
        } 
        
        public Renter GetRenter(int renterId) 
        {
            return Program.dummyRenter;
        }

        public void EnterStartAndEndDate(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
            startDate = GetDateOnly(start);
            endDate = GetDateOnly(end);
            startTime = GetTimeOnly(start);
            endTime = GetTimeOnly(end);
            
        }
        public DateOnly GetDateOnly(DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }

        public TimeOnly GetTimeOnly(DateTime dateTime)
        {
            return TimeOnly.FromDateTime(dateTime);
        }


        public void SelectPickUpMethod(string pickUpMethod)
        {
            if (pickUpMethod == "iCar Station")
            {
                iCarStations = GetAlliCarStations();
                uiRentVehicle.DisplayAlliCarStations(iCarStations);

            }
            else if (pickUpMethod == "Physical Address")
            {
                //validPhysicalAddress = false;
                SetValidPhysicalAddressToFalse(validPhysicalAddress);

                while (validPhysicalAddress == false) 
                {
                    uiRentVehicle.PromptPhysicalAddress();
                }
                validPhysicalAddress = false; // reset

                addressFee = CalculateAddressFee(pickUpLocation);
                AddToTotalCost(addressFee);

                //PhysicalAddress physicalAddress = createPhysicalAddress(pickUpLocation, addressFee);
                //SetPhysicalAddressAsPickUpMethod(physicalAddress);
            }
        }

        public List<ICarStation> GetAlliCarStations()
        {
            return Program.ListOfiCarStations;
        }

        public ICarStation? GetiCarStation(int iCarStationId)
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
        public void SetValidPhysicalAddressToFalse(bool validPhysicalAddress)
        {
            validPhysicalAddress = false;
        }

        public void EnterPhysicalAddress(string physicalAddress)
        {
            validPhysicalAddress = ValidatePhysicalAddress(physicalAddress); 
            if (!validPhysicalAddress)
            {
                uiRentVehicle.DisplayInvalidAddressMessage();
                return;
            }

            if (pickUpLocation ==  null) 
            {
                pickUpLocation = physicalAddress;
                return;
            }
            returnLocation = physicalAddress;

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

        public void SetPhysicalAddressAsPickUpMethod(PhysicalAddress physicalAddress)
        {
            pickUpMethod = physicalAddress;
        }

        public void SelectReturnMethod(string returnMethod)
        {
            if (returnMethod == "iCar Station")
            {
                iCarStations = GetAlliCarStations();
                uiRentVehicle.DisplayAlliCarStations(iCarStations);

            }
            else if (returnMethod == "Physical Address")
            {
                validPhysicalAddress = false;
                SetValidPhysicalAddressToFalse(validPhysicalAddress);

                while (validPhysicalAddress == false)
                {
                    uiRentVehicle.PromptPhysicalAddress();
                }
                validPhysicalAddress = false; // reset

                addressFee = CalculateAddressFee(returnLocation);
                AddToTotalCost(addressFee);

                //PhysicalAddress physicalAddress = createPhysicalAddress(returnLocation, addressFee);
                //SetPhysicalAddressAsReturnMethod(physicalAddress);
            }
        }

        public void SetPhysicalAddressAsReturnMethod(PhysicalAddress physicalAddress)
        {
            returnMethod = physicalAddress;
        }

        public float CalculateBookingFee(DateTime start, DateTime end)
        {
            return car1.RentalRate * (int)((end - start).TotalHours);
        }

        public void MakePayment()
        {
            transaction = renter1.MakePayment(bookingFee);
        }

        public void SetStatusToFalse(bool status)
        {
            status = false;
        }

        //public PhysicalAddress createPhysicalAddress(string physicalAddress, float addressFee)
        //{
        //    PhysicalAddress address = new PhysicalAddress(physicalAddress, addressFee);
        //    return address;
        //}

        public Booking CreateBooking(DateTime start, DateTime end, float bookingFee, Location pickUpMethod, Location returnMethod, Car car)
        {
            return renter1.CreateBooking(start, end, bookingFee, pickUpMethod, returnMethod, car);
        }
    }
}