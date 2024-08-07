using System;

public class Renter : User  {
	private DateTime dateOfBirth;
	private int contact;
	private String bookingHistory;
	private bool isVerified;
	private string password;
	private string email;

	public void CheckAnyOngoingBooking(ref object dateTime_start, ref object dateTime_end) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void CreateBooking(ref object dateTime_start, ref object dateTime_end, ref object float_bookingFee, ref object location_pickUpMethod, ref object location_returnMethod, ref object car_car) {
		throw new System.NotImplementedException("Not implemented");
	}
	public Transaction MakePayment(ref object float_bookingFee) {
		throw new System.NotImplementedException("Not implemented");
	}
	public Booking GetBooking() {
		throw new System.NotImplementedException("Not implemented");
	}
	public Booking GetCurrentBooking() {
		throw new System.NotImplementedException("Not implemented");
	}

	private Booking[] makes;
	private Admin isVerifiedBy;
	private DigitalWallet has;

}
