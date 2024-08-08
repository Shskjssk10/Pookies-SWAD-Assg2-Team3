using System;

public class DigitalWallet
{
    private static int nextId = 1; // Static field to track the next ID
    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private float balance;

    public float Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public DigitalWallet()
    {

    }
    public DigitalWallet(float b)
    {
        Id = nextId++;
        Balance = b;
    }

    public void addFunds(float amount)
    {
        balance += amount;
    }

    public void removeFunds(float amount) 
    {
        balance -= amount;
    }
}
