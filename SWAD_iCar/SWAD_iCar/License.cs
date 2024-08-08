using System;

public class License {

    private static int nextId = 1; // Static field to track the next ID
    private int id;
	public int Id { 
		get { return id; }
		set { id = value; }
	}

	private DateTime issueDate;
	public DateTime IssueDate
	{
		get { return issueDate; }
		set { issueDate = value; }
	}

	private int serialNo;
	public int SerialNo
	{
		get { return serialNo; }
		set { serialNo = value; }
	}

	private string issueAuthority;
	public string IssueAuthority
	{
		get { return issueAuthority; }
		set { issueAuthority = value; }
	}

	private DateTime expiryDate;
	public DateTime ExpiryDate
	{
		get { return expiryDate; }
		set { expiryDate = value; }
	}

	private int noOfDemerit;
	public int NoOfDemerit
	{
		get { return noOfDemerit; }
		set { noOfDemerit = value; }
	}

	private List<string> photo;
	public List<string> Photo
	{
		get { return photo; }
		set { photo = value; }
	}

	private Renter renter;
	public Renter Renter
	{
		get { return renter; }
		set { renter = value; }
	}

	public License(DateTime issueDate, int serialNo, string issueAuthority, DateTime expiryDate, int noOfDemerit, List<string> photo, Renter renter)
    {
		Id = nextId++;
        IssueDate = issueDate;
        SerialNo = serialNo;
        IssueAuthority = issueAuthority;
        ExpiryDate = expiryDate;
        NoOfDemerit = noOfDemerit;
        Photo = photo;
        Renter = renter;
    }
}
