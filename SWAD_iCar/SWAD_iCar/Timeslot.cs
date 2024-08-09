using System;
using System.Runtime.CompilerServices;
namespace SWAD_iCar
{
	public class Timeslot
	{
		private static int nextId = 1; // Static field to track the next ID
		public Timeslot(DateTime timeSlot, bool availabilityStatus, Car car)
		{
			Id = nextId++; // Assign the current ID and increment the counter
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

		public void UpdateTimeSlotAvailability(bool status)
		{
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
			Console.WriteLine($"Timeslot Id: {id}, TimeSlot: {timeSlot}, Availability: {availabilityStatus}");
			return;
		}
	}
}