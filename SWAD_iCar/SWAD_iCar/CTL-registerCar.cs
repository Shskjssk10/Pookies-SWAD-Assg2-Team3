using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SWAD_iCar
{
    internal class CTL_registerCar
    {
        public Car newCar;
        List<Car> cars = new List<Car>(); 
        public void AddNewCar()
        {
            // Validate and process the new car registration
            if (CheckForCompleteAndCorrect(make, model, year, mileage, licensePlate, insuranceNo, photos, insuranceDetails))
            {
                Console.WriteLine("Car registration successful!");
                //add the car to the list
                cars.Add(newCar);
            }
            else
            {
                Console.WriteLine("Car registration failed. Please check your inputs and try again.");
            }
        }

        public bool CheckForCompleteAndCorrect(string make, string model, DateTime year, float mileage, string licensePlate, int insuranceNo, List<string> photos, Insurance insuranceDetails)
        {
            //check if the make and model are not null or empty
            if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(model))
            {
                return false; //either fields are empty or null
            }

            //check if mileage is a positive number
            if (mileage <= 0)
            {
                return false;
            }

            //check if year is a reasonable value
            int yearValue = year.Year;
            if (yearValue < 1900 || yearValue > DateTime.Now.Year)
            {
                return false;
            }

            //check if license plate is not null or empty
            string licensePlatePattern = @"^[A-Z]{3}\d{4}[A-Z]$";
            if (!Regex.IsMatch(licensePlate, licensePlatePattern))
            {
                return false; //license plate does not match the pattern
            }

            //check if the insurance number is a positive integer (assuming insurance number should be positive)
            if (insuranceNo <= 0)
            {
                return false;
            }

            //check if the photos list is not null and contains at least one photo
            if (photos == null || photos.Count == 0 || photos.Any(photo => string.IsNullOrWhiteSpace(photo)))
            {
                return false;
            }

            // Check if insuranceDetails is not null and contains valid details
            if (insuranceDetails == null || !insuranceDetails.isValid())
            {
                return false; // Insurance details are invalid
            }
            // All fields are valid
            return true;
        }

        public void GetAllCars()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine(cars[i]);
            }
        }

        public bool IsDuplicate()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (newCar.LicensePlate == cars[i].LicensePlate)
                {
                    return true; // Duplicate found
                }
            }
            return false; // No duplicates found
        }

    }


}
