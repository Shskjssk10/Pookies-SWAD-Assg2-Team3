using System;

public class Transaction
{
    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private float cost;

    public float Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    private DateTime time;

    public float Time
    {
        get { return time; }
        set { time = value; }
    }

    public Transaction() { }

    public Transaction(int i, float c, DateTime t)
    {
        Id = i;
        Cost = c;
        Time = t;
    }
}
