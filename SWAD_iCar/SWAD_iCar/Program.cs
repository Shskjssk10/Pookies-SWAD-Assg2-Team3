// See https://aka.ms/new-console-template for more information
using SWAD_iCar;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, World!");

//have test car owner 
//have test car 
//add to car owner
DateTime dob = new DateTime(2005, 5, 12);
DateTime cardExpDate = new DateTime(2024, 8, 19);
DateTime insuranceExpDate = new DateTime(2025, 3, 08);
DateTime insuranceIssueDate = new DateTime(2021, 05, 06);
Card card = new Card("credit", 123, 667, cardExpDate);
var photosForCamry = new List<string> { "image1.jpg", "image2.jpg" };
Insurance insuranceDetails = new Insurance(1, insuranceExpDate, insuranceIssueDate, "AIA");
CarOwner owner = new CarOwner(1, "Hendrik", "hendrikywr", card, dob, 91234567);

CTL_registerCar registerCTL = new CTL_registerCar();
UI_registerCar registerUI = new UI_registerCar();

registerUI.AddNewCar();


registerCTL.AddNewCar(1, "Toyota", "Camry", 2020, 15000, "SJF1234A", 1, photosForCamry, insuranceDetails);
// Print the owner details
Console.WriteLine(owner.ToString());

foreach (var car in owner.GetCars())
{
    Console.WriteLine(car);
}




