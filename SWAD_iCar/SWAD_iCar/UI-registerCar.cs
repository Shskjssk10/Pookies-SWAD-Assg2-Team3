using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SWAD_iCar
{
    public class UI_registerCar
    {
        private CTL_registerCar ctlRegisterCar;

        public UI_registerCar()
        {
            ctlRegisterCar = new CTL_registerCar();
        }

        public void AddNewCar()
        {
            DisplayRegisterCarForm();
        }

        public void DisplayRegisterCarForm()
        {
            // Prompt for make
            Console.Write("Enter car make: ");
            string make = Console.ReadLine();

            // Prompt for model
            Console.Write("Enter car model: ");
            string model = Console.ReadLine();

            // Prompt for year
            Console.Write("Enter car year: ");
            int year = int.Parse(Console.ReadLine());

            // Prompt for mileage
            Console.Write("Enter car mileage: ");
            int mileage = int.Parse(Console.ReadLine());

            // Prompt for license plate
            Console.Write("Enter license plate: ");
            string licensePlate = Console.ReadLine();

            // Prompt for insurance number
            Console.Write("Enter insurance number: ");
            int insuranceNo = int.Parse(Console.ReadLine());

            // Prompt for list of photos
            List<string> photos = new List<string>();
            Console.WriteLine("Enter photo URLs (type 'done' when finished):");
            while (true)
            {
                string photoUrl = Console.ReadLine();
                if (photoUrl.ToLower() == "done") break;
                photos.Add(photoUrl);
            }

            // Prompt for insurance details
            Console.Write("Enter insurance policy number: ");
            int policyNo = int.Parse(Console.ReadLine());

            Console.Write("Enter insurance expiry date (YYYY-MM-DD): ");
            DateTime expiryDate;
            while (!DateTime.TryParse(Console.ReadLine(), out expiryDate))
            {
                Console.WriteLine("Invalid date format. Please enter the date in YYYY-MM-DD format.");
                Console.Write("Enter insurance expiry date (YYYY-MM-DD): ");
            }

            Console.Write("Enter insurance issue date (YYYY-MM-DD): ");
            DateTime issueDate;
            while (!DateTime.TryParse(Console.ReadLine(), out issueDate))
            {
                Console.WriteLine("Invalid date format. Please enter the date in YYYY-MM-DD format.");
                Console.Write("Enter insurance issue date (YYYY-MM-DD): ");
            }

            Console.Write("Enter insurance insurer: ");
            string insurer = Console.ReadLine();

            // Create the Insurance object with the provided details
            Insurance insuranceDetails = new Insurance(policyNo, expiryDate, issueDate, insurer);

            // Create a Car object or equivalent to store the data
            Car car = new Car(make, model, year, mileage, licensePlate, insuranceNo, photos, insuranceDetails);

            // Optional: Display the collected information
            DisplayCarDetails(car);
        }

        public void DisplayCarDetails(Car car)
        {
            Console.WriteLine("\nCar Details:");
            Console.WriteLine($"Make: {car.Make}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Year: {car.Year}");
            Console.WriteLine($"Mileage: {car.Mileage}");
            Console.WriteLine($"License Plate: {car.LicensePlate}");
            Console.WriteLine($"Insurance Number: {car.InsuranceNo}");
            Console.WriteLine($"Insurance Details: {car.InsuranceDetails}");
            Console.WriteLine("Photos:");
            foreach (var photo in car.Photos)
            {
                Console.WriteLine(photo);
            }
        }

        public void AddNewCar(int carOwnerId, string make, string model, int year, float mileage, string licensePlate, int insuranceNo, List<string> photos, Insurance insuranceDetails)
        {
            Console.WriteLine("Are you sure you want to add new car?");
            string option = Console.ReadLine();
            if (option == "yes")
            {
                ctlRegisterCar.AddNewCar(carOwnerId, make, model, year, mileage, licensePlate, insuranceNo, photos, insuranceDetails);
            }
            else
            {
                Console.WriteLine("Add new car cancelled");
            }
        }
    }
}
