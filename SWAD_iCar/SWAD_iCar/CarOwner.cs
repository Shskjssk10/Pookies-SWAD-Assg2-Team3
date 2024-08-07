using System;

public class CarOwner : User
{
    private DateTime dateOfBirth;

    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    private int contact;

    public int Contact
    {
        get { return contact; }
        set { contact = value; }
    }

    public CarOwner(DateTime dob, int contact)
    {
        dateOfBirth = dob;
        this.contact = contact;
    }
}