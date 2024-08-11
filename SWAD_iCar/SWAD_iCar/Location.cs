using System;
namespace SWAD_iCar
{
	public class Location
	{
		private string address;
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
		public Location(string address)
		{
			Address = address;
		}
	}
}