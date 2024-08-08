using System;

namespace SWAD_iCar
{
    private static int nextId = 1; // Static field to track the next ID
    private int id;
    public int Id
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private DateTime startDateTime;
        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }

        private DateTime endDateTime;
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }

        private DateTime returnTime;
        public DateTime ReturnTime
        {
            get { return returnTime; }
            set { returnTime = value; }
        }

        private Location returnMethod;
        public Location ReturnMethod
        {
            get { return returnMethod; }
            set { returnMethod = value; }
        }

        private Location pickUpMethod;
        public Location PickUpMethod
        {
            get { return pickUpMethod; }
            set { pickUpMethod = value; }
        }

        private bool vehicleInspectionStatus;
        public bool VehicleInspectionStatus
        {
            get { return vehicleInspectionStatus; }
            set { vehicleInspectionStatus = value; }
        }

        private float penaltyFee;
        public float PenaltyFee
        {
            get { return penaltyFee; }
            set { penaltyFee = value; }
        }

        private float damagesFee;
        public float DamagesFee
        {
            get { return damagesFee; }
            set { damagesFee = value; }
        }

        private float totalBookingFee;
        public float TotalBookingFee
        {
            get { return totalBookingFee; }
            set { totalBookingFee = value; }
        }

        private string bookingStatus;
        public string BookingStatus
        {
            get { return bookingStatus; }
            set { bookingStatus = value; }
        }

        private Car car;
        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        private List<Report> about = new List<Report>();
        public List<Report> About
        {
            get { return about; }
            set { about = value; }
        }

        private Admin updatedBy;
        public Admin UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        private List<Transaction> bookingTransactions = new List<Transaction>();
        public List<Transaction> BookingTransactions
        {
            get { return bookingTransactions; }
            set { bookingTransactions = value; }
        }

        // Constructor
        public Booking(int id, DateTime startDateTime, DateTime endDateTime, DateTime returnTime, Location returnMethod, Location pickUpMethod, bool vehicleInspectionStatus, float penaltyFee, float damagesFee, float totalBookingFee, string bookingStatus, Car car, Location dropOffTo, Location pickUpFrom, List<Report> about, Admin updates, List<Transaction> bookingTransactions)
        {
            this.id = id;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.returnTime = returnTime;   
            this.returnMethod = returnMethod;
            this.pickUpMethod = pickUpMethod;
            this.vehicleInspectionStatus = vehicleInspectionStatus;
            this.penaltyFee = penaltyFee;
            this.damagesFee = damagesFee;
            this.totalBookingFee = totalBookingFee;
            this.bookingStatus = bookingStatus;
            this.car = car;
            this.dropOffTo = dropOffTo;
            this.pickUpFrom = pickUpFrom;
            this.about = about;
            this.updates = updates;
            this.bookingTransactions = bookingTransactions;
        }

        public DateTime SetReturnTime()
        {
            return this.returnTime = DateTime.Now;
        }

        public string ConfirmUpdateBooking(Booking updatedBooking)
        {
            if (Id == updatedBooking.Id)
            {
                // Update the properties of the original booking
                StartDateTime = updatedBooking.StartDateTime;
                EndDateTime = updatedBooking.EndDateTime;
                ReturnMethod = updatedBooking.ReturnMethod;
                PickUpMethod = updatedBooking.PickUpMethod;
                DropOffTo = updatedBooking.DropOffTo;
                PickUpFrom = updatedBooking.PickUpFrom;

                string successMessage = "Booking updated Successfully";
                return successMessage;
            }
            else
            {
                string errorMessage = "Booking mismatch.";
                return errorMessage;
            }            
        }

        public string ProcessCancelBooking(Renter renter)
        {
            try
            {
                // Change the booking status to "Cancelled"
                BookingStatus = "Cancelled";

                float ogFunds = renter.Wallet.Balance;
                // Add the total booking fee to the renter's wallet
                renter.Wallet.addFunds(totalBookingFee);

                // Return a success message
                string successMessage = $"Booking successfully cancelled.\nYour balance before refund is {ogFunds} \nYour current balance is: {renter.Wallet.Balance}";
                return successMessage;
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error message
                string errorMessage = $"An error occurred while cancelling the booking: {ex.Message}";
                return errorMessage;
            }
        }

        public void AddNewTransaction(Transaction transaction)
        {
            bookingTransactions.Add(transaction);
        }

        public bool CheckLocation(string currentAddress)
        {
            if (returnMethod.Address == currentAddress) return true;
            else return false;

            //throw new System.NotImplementedException("Not implemented");
            // return bool
        }

        //public bool UpdateBooking()
        //{
        //    throw new System.NotImplementedException("Not implemented");
        //    // return bool
        //}

        //public bool CheckPenalty()
        //{
        //    if (DateTime.Now <= endDateTime)
        //    {
                
        //    }

        //    throw new System.NotImplementedException("Not implemented");
        //    // return bool
        //}

        public float CalculatePenalty(DateTime returnTime)
        {
            TimeSpan difference = returnTime - endDateTime;
            // have to reimburse by checking the rental rate in the timeslot
            float penaltyFee = difference.Hours * 5;
            return penaltyFee;

            //throw new System.NotImplementedException("Not implemented");
            // return float
        }

        public void addNewTransaction(Transaction transaction)
        {
            bookingTransactions.Add(transaction);
        }


        // ToString method
        public override string ToString()
        {
            return $"Booking ID: {Id}, Start DateTime: {StartDateTime}, End DateTime: {EndDateTime}, " +
                $"Return Method: {ReturnMethod}, Pick Up Method: {PickUpMethod}, " +
                $"Vehicle Inspection Status: {VehicleInspectionStatus}, Penalty Fee: {PenaltyFee}, " +
                $"Damages Fee: {DamagesFee}, Total Booking Fee: {TotalBookingFee}, " +
                $"Booking Status: {BookingStatus}, Car: {Car}" +
                $"Reports: {About.Length}, Number of Transactions: {BookingTransactions.Count}";
        }
}   }
