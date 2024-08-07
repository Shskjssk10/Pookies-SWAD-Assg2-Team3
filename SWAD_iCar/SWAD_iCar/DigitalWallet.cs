using System;

public class DigitalWallet {
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
	public DigitalWallet(int i, float b)
	{
		Id = i;
		Balance = b;
	}
}
