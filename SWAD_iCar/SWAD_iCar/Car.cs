using SWAD_iCar;
using System;


namespace SWAD_iCar
{
    public class Car
    {
        private static int nextId = 1; // Static field to track the next ID
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string make;
        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private DateTime year;
        public DateTime Year
        {
            get { return year; }
            set { year = value; }
        }

        private float mileage;
        public float Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        private List<string> photos;
        public List<string> Photos
        {
            get { return photos; }
            set { photos = value; }
        }

        private bool isWithdrawn;
        public bool IsWithdrawn
        {
            get { return isWithdrawn; }
            set { isWithdrawn = value; }
        }

        private Dictionary<int, string> reviews;
        public Dictionary<int, string> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }

        private string licensePlate;
        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }

        private float rentalRate;
        public float RentalRate
        {
            get { return rentalRate; }
            set { rentalRate = value; }
        }

        private Insurance carInsurance;
        public Insurance CarInsurance
        {
            get { return carInsurance; }
            set { carInsurance = value; }
        }

        private List<Timeslot> registeredTimeSlots;
        public List<Timeslot> RegisteredTimeSlots
        {
            get { return registeredTimeSlots; }
            set { registeredTimeSlots = value; }
        }

        private List<Booking> carBookings;
        public List<Booking> CarBookings
        {
            get { return carBookings; }
            set { carBookings = value; }
        }

        public Car(string make, string model, DateTime year, float mileage, List<string> photos, bool isWithdrawn, Dictionary<int, string> reviews, string licensePlate, float rentalRate)
        {
            Id = nextId++; // Assign the current ID and increment the counter
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
            Photos = photos ?? new List<string>(); // Use an empty list if null
            IsWithdrawn = isWithdrawn;
            Reviews = reviews ?? new Dictionary<int, string>(); // Use an empty dictionary if null
            LicensePlate = licensePlate;
            RentalRate = rentalRate;
            RegisteredTimeSlots = new List<Timeslot>();
            CarBookings = new List<Booking>();
        }

        public bool CheckAvailability(DateTime start, DateTime end)
        {
            // Calculate the number of timeslots (hours) between the start and end times
            int totalTimeSlots = (int)(end - start).TotalHours;

            int numberOfTimeslotsRegistered = 0;
            bool allSlotsAvailable = true;
            foreach (Timeslot aTimeSlot in RegisteredTimeSlots)
            {
                // Check if the timeslot falls within the start and end times
                if ((start >= aTimeSlot.TimeSlot) && (end <= aTimeSlot.TimeSlot))
                {
                    numberOfTimeslotsRegistered++;
                    if (aTimeSlot.AvailabilityStatus == false)
                    {
                        allSlotsAvailable = false;
                        break;
                    }
                }
            }

            // checks if the number of timeslots registred matches the total timeslots wanting to be booked by renter
            return allSlotsAvailable && (totalTimeSlots == numberOfTimeslotsRegistered);
        }

        public List<Timeslot> GetTimeSlots()
        {
            return registeredTimeSlots;
        }

        public void AddNewTimeSlot(Timeslot timeslot)
        {
            registeredTimeSlots.Add(timeslot);
        }

        public bool RemoveTimeSlots(int startID, int endID)
        {
            List<Timeslot> registeredTimeslots = GetTimeSlots();

            int removedCount = registeredTimeslots.RemoveAll(timeslot => timeslot.Id >= startID && timeslot.Id <= endID);
            return true;
        }

        public bool UpdateRentalRate(float newRate)
        {
            try
            {
                rentalRate = newRate;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public void UpdateTimeSlotsAvailability(List<Timeslot> selectedTimeslots, int newStatus)
        {
            Timeslot matchingTimeslot;
            foreach (Timeslot timeslot in selectedTimeslots)
            {
                matchingTimeslot = registeredTimeSlots.FirstOrDefault(t => t.Id == timeslot.Id);
                switch (newStatus)
                {
                    case 1:
                        matchingTimeslot.UpdateTimeSlotAvailability(true);
                        break;
                    case 2:
                        matchingTimeslot.UpdateTimeSlotAvailability(false);
                        break;  
                }
            }
        }
        public void AddNewBooking(Booking newBooking)
        {
            CarBookings.Add(newBooking);
        }
        public override string ToString()
        {
            return $"Car ID:{id} Make: {make} Model: {model} Year: {year} Mileage: {mileage} IsWithdrawn: {isWithdrawn} License Plate: {licensePlate} " +
                $"Rental Rate: {rentalRate} Photos: {(photos.Count > 0 ? string.Join(", ", photos) : "No photos available")}"
                + $"Reviews: {(Reviews.Count > 0 ? string.Join(", ", Reviews.Values) : "No reviews available")}";
        }


        //public override string ToString()
        //{
        //    return $"Car ID: {Id}\n" +
        //           $"Make: {Make}\n" +
        //           $"Model: {Model}\n" +
        //           $"Year: {Year.Year}\n" +
        //           $"Mileage: {Mileage} km\n" +
        //           $"Is Withdrawn: {IsWithdrawn}\n" +
        //           $"License Plate: {LicensePlate}\n" +
        //           $"Rental Rate: ${RentalRate:F2}\n" +
        //           $"Photos: {(Photos.Count > 0 ? string.Join(", ", Photos) : "No photos available")}\n" +
        //           $"Reviews: {(Reviews.Count > 0 ? string.Join(", ", Reviews.Values) : "No reviews available")}";
        //}
    } 
}