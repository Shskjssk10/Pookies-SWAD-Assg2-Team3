using System;

public class Admin : User
{


    private Booking booking;
    public Booking Booking
    {
        get { return booking; }
        set { booking = value; }
    }

    private Renter renter;
    public Renter Renter
    {
        get { return renter; }
        set { renter = value; }
    }

    private Report report;
    public Report Report
    {
        get { return report; }
        set { report = value; }
    }


    public Admin(int id, string name, string username, Card card, Booking booking, Renter renter, Report report)
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
