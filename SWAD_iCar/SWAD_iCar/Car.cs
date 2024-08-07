using System;

public class Car {
	private int id;
	private string make;
	private string model;
	private DateTime year;
	private float mileage;
	private List<string> photos;
	private bool isWithdrawn;
	private Dict<int, string> reviews;
	private string licensePlate;
	private float rentalRate;

	public bool CheckAvailability(ref object dateTime_start, ref object dateTime_end) {
		throw new System.NotImplementedException("Not implemented");
	}
	public List<TimeSlot> GetTimeSlots() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AddNewBooking(ref object booking_newBooking) {
		throw new System.NotImplementedException("Not implemented");
	}
	public bool RemoveTimeSlots(ref object int_startId, ref object int_endId) {
		throw new System.NotImplementedException("Not implemented");
	}
	public bool UpdateRentalRate(ref object float_newRate) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void UpdateTimeSlotsAvailability(ref object dateTime_start, ref object dateTime_end, ref object bool_status) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Insurance has;

	private Booking[] for;
	private CarOwner registers;

}
