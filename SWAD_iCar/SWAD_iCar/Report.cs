using System;


namespace SWAD_iCar
{
    public class Report
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private Admin admin;
        public Admin Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        private Booking booking;
        public Booking Booking
        {
            get { return booking; }
            set { booking = value; }
        }
        public Report(int id, string content, Admin admin, Booking booking)
        {
            this.id = id;
            this.content = content;
            this.admin = admin;
            this.booking = booking;
        }
    }
}
