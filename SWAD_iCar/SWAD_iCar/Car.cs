using System;

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

    private int year;
    public int Year 
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

    private List<Timeslot> registeredTimeSlots;
    public List<Timeslot> RegisteredTimeSlots
    {
        get { return registeredTimeSlots; }
        set { registeredTimeSlots = value; }
    }

    public Car(string make, string model, int year, float mileage, List<string> photos, bool isWithdrawn, Dictionary<int, string> reviews, string licensePlate, float rentalRate)
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
    }

    public List<Timeslot> getTimeSlots()
    {
        return registeredTimeSlots;
    }

    public void addNewTimeSlot(Timeslot timeslot)
    {
        registeredTimeSlots.Add(timeslot);
    }

    public bool removeTimeSlots(int startID, int endID)
    {
        bool flag = false;
        List<Timeslot> registeredTimeslots = getTimeSlots();
        foreach (Timeslot timeslot in registeredTimeslots)
        {
            if (timeslot.Id >= startID || timeslot.Id <= endID)
            {
                registeredTimeslots.Remove(timeslot);
                flag = true;
            }
        }
        return flag;
    }

    public bool updateRentalRate(float newRate)
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

    public override string ToString()
    {
        Console.WriteLine($"Car ID:{id} Make: {make} Model: {model} Year: {year} Mileage: {mileage} IsWithdrawn: {isWithdrawn} License Plate: {licensePlate} " +
            $"Rental Rate: {rentalRate} Photos: {(photos.Count > 0 ? string.Join(", ", photos) : "No photos available")}"
            + $"Reviews: {(Reviews.Count > 0 ? string.Join(", ", Reviews.Values) : "No reviews available")}");
        return "";
    }
}
