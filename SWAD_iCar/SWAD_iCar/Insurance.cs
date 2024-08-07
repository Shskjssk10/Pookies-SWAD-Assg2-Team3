using System;

public class Insurance
{
    private int policyNo;
    public int PolicyNo
    {
        get { return policyNo; }
        set { policyNo = value; }
    }

    private DateTime expiryDate;
    public DateTime ExpiryDate
    {
        get { return expiryDate; }
        set { expiryDate = value; }
    }

    private DateTime issueDate;
    public DateTime IssueDate
    {
        get { return issueDate; }
        set { issueDate = value; }
    }

    private string insurer;
    public string Insurer
    {
        get { return insurer; }
        set { insurer = value; }
    }

    // Constructor with parameters for all fields
    public Insurance(int policyNo, DateTime expiryDate, DateTime issueDate, string insurer)
    {
        PolicyNo = policyNo;
        ExpiryDate = expiryDate;
        IssueDate = issueDate;
        Insurer = insurer;
    }

    // Override ToString method for displaying insurance details
    public override string ToString()
    {
        return $"Insurance Policy No: {PolicyNo}\n" +
               $"Issue Date: {IssueDate.ToShortDateString()}\n" +
               $"Expiry Date: {ExpiryDate.ToShortDateString()}\n" +
               $"Insurer: {Insurer}\n";
    }
}
