using System;
using System.Collections.Generic;
using System.Linq;
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

        private void AddNewCar()
        {
               
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
            string insuranceNo = Console.ReadLine();

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
            Console.Write("Enter insurance details: ");
            string insuranceDetails = Console.ReadLine(); // Simplified; ideally this would be more structured

            // Create a Car object or equivalent to store the data
            Car car = new Car
            {
                Make = make,
                Model = model,
                Year = year,
                Mileage = mileage,
                LicensePlate = licensePlate,
                InsuranceNumber = insuranceNo,
                Photos = photos,
                InsuranceDetails = insuranceDetails
            };

            // Optional: Display the collected information
            DisplayCarDetails(car);
        }

        private void DisplayCarDetails(Car car)
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

        private void AddNewCar()
        {

        }
    }
}
