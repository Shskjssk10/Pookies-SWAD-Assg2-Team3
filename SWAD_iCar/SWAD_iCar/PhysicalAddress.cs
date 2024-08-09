using System;

public class PhysicalAddress : Location  {
	private float fee;
	public float Fee
	{
		get { return fee; }
		set { fee = value; }
	}

	public PhysicalAddress(string address, float addressFee) : base(address)
	{
		Fee = addressFee;
	}
}
