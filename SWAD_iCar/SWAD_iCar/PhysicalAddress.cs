using System;
namespace SWAD_iCar
{
	public class PhysicalAddress : Location
	{
		private float fee;
		public float Fee
		{
			get { return fee; }
			set { fee = value; }
		}

		public PhysicalAddress(float addressFee, string address) : base(address)
		{
			Fee = addressFee;
		}
	}
}