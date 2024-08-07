using System;

public class Booking {
	private int id;
	private DateTime startDateTime;
	private DateTime endDateTime;
	private Location returnMethod;
	private Location pickUpMethod;
	private bool vehicleInspectionStatus;
	private float penaltyFee;
	private float damagesFee;
	private float totalBookingFee;
	private string bookingStatus;

	public string GetBookingDetails() {
		throw new System.NotImplementedException("Not implemented");
	}
	public string ConfirmUpdateBooking(ref object int_bookingId, ref object booking_updatedBooking) {
		throw new System.NotImplementedException("Not implemented");
	}
	public string ProcessCancelBooking(ref object int_bookingId) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AddNewTransaction(ref object transaction_transaction) {
		throw new System.NotImplementedException("Not implemented");
	}
	public bool CheckLocation(ref object string_currentAddress) {
		throw new System.NotImplementedException("Not implemented");
	}
	public bool UpdateBooking() {
		throw new System.NotImplementedException("Not implemented");
	}
	public bool CheckPenalty() {
		throw new System.NotImplementedException("Not implemented");
	}
	public float CalculatePenalty() {
		throw new System.NotImplementedException("Not implemented");
	}

	private Car for;
	private Location dropOffTo;
	private Location pickUpFrom;

	private Renter makes;
	private Report[] about;
	private Admin updates;

}
