using System;
namespace SWAD_iCar
{
	public class ICarStation : Location
	{
		private static int nextId = 1; // Static field to track the next ID
		private int id;
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public ICarStation(string name, string address) : base(address)
		{
			Id = nextId++;
			Name = name;
		}
	}
}