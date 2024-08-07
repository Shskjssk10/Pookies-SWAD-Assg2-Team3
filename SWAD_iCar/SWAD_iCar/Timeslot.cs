using System;
using System.Runtime.CompilerServices;

public class Timeslot {
    public Timeslot(int id, DateTime timeSlot, bool availabilityStatus, Car car)
    {
        Id = id;
        TimeSlot = timeSlot;
        AvailabilityStatus = availabilityStatus;
        Car = car;
    }

    private int id;
	public int Id
	{
		get { return id; }
		set { id = value; }
	}

	private DateTime timeSlot;
	public DateTime TimeSlot
	{
		get { return timeSlot; }
		set { timeSlot = value; }
	}


	private bool availabilityStatus;
	public bool AvailabilityStatus
	{
		get { return availabilityStatus; }
		set { availabilityStatus = value; }
	}

	public void UpdateTimeSlotAvailability(bool status) {
		availabilityStatus = status;
		return;
	}

    private Car car;
	public Car Car
	{
		get { return car; }
		set { car = value; }
	}

    public void ToString()
    {
        Console.WriteLine($"Timeslot Id: {id}, TimeSlot: {timeSlot}, Availability: {availabilityStatus}, Car: {car?.ToString() ?? "No Car"}");
        return;
    }
}
