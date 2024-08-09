using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    internal class UI_RegisterCar
    {
        private CTL_RegisterCar ctlRegisterCar;
        List<Car> cars = new List<Car>();

        public UI_RegisterCar()
        {
            ctlRegisterCar = new CTL_RegisterCar();
        }

        public void addNewCar()
        {
            displayRegisterCarForm();
        }

        public void displayRegisterCarForm()
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

            // Prompt for license plate
            Console.Write("Enter Rental Rate: ");
            float rentalRate = float.Parse(Console.ReadLine());

            // Prompt for list of photos
            List<string> photos = new List<string>();
            Console.WriteLine("Enter photo URLs (type 'done' when finished):");
            while (true)
            {
                string photoUrl = Console.ReadLine();
                if (photoUrl.ToLower().Trim() == "done") break;
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
            Car car = new Car(make, model, year, mileage, licensePlate, rentalRate, photos, insuranceDetails);

            promptConfirmation();
        }


        public void promptConfirmation()
        {
            string choice;

            while (true)
            {
                Console.WriteLine("Do you want to register car? (yes or no)");
                choice = Console.ReadLine().ToLower().Trim();

                if (choice == "yes")
                {
                    submitConfirmation();
                    break;
                }
                else if (choice == "no")
                {
                    Console.WriteLine("Car not registered");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }           
        }

        public void addNewCar(string make, string model, int year, float mileage, string licensePlate, float rentalRate, List<string> photos, Insurance insuranceDetails)
        {
            ctlRegisterCar.createCar(make, model, year, mileage, licensePlate, rentalRate, photos, insuranceDetails);
        }
        public void submitConfirmation()
        {
            string make = "Toyota";
            string model = "Camry";
            int year = 2024;
            float mileage = 5000.0f;
            string licensePlate = "XYZ123";
            float rentalRate = 50.0f;
            List<string> photos = new List<string> { "photo1.jpg", "photo2.jpg" };
            Insurance insuranceDetails = new Insurance(123, new DateTime(2024/12/01), new DateTime(2021/12/01), "AIA"); // Assume Insurance is already defined and properly initialized

            addNewCar(make, model, year, mileage, licensePlate, rentalRate, photos, insuranceDetails);
        }

    }
}
