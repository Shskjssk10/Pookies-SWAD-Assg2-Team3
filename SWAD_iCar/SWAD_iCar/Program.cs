// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//have test car owner 
//have test car 
//add to car owner
DateTime dateOfBirth = new DateTime(2005, 5, 12);
DateTime expDate = new DateTime(2024, 08, 19);
Card card = new Card("credit", 123, 667, expDate);
CarOwner testCarOwner = new CarOwner(1, "hendrik", "hendrikywr", card ,dateOfBirth, 91234567);

Console.WriteLine(testCarOwner.Username);





