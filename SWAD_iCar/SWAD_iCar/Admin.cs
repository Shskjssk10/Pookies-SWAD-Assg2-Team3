using System;
namespace SWAD_iCar
{
    public class Admin : User
    {


        private List<Booking> booking;
        public List<Booking> Booking
        {
            get { return booking; }
            set { booking = value; }
        }

        private List<Renter> renter;
        public List<Renter> Renter
        {
            get { return renter; }
            set { renter = value; }
        }

        private List<Report> report;
        public List<Report> Report
        {
            get { return report; }
            set { report = value; }
        }


        public Admin(int id, string name, string username, Card card, List<Booking> booking, List<Renter> renter, List<Report> report)
            : base(id, name, username, card)
        {
            this.booking = booking;
            this.renter = renter;
            this.report = report;
        }


        public float UpdateInspectionStatus()
        {
            //update status
            return 1;
        }
    }
}
