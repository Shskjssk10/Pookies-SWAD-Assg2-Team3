using System;

public class ICarStation : Location  {
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

	public ICarStation(int id, string name, string address) : base(address) {
		Id = id;
		Name = name;
	}
}
