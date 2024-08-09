using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    internal class CTL_RegisterCar
    {
        List<Car> cars = new List<Car>();
        public void createCar(int carOwnerId,string make,string model,int year,float mileage,string licensePlate,float rentalRate, List<string> photos, Insurance insuranceDetails)
        {
            Car car = new Car(make, model, year, mileage, licensePlate, rentalRate, photos, insuranceDetails);
        }

        public bool isCorrect(string make, string model, int year, float mileage, string licensePlate, float rentalRate, List<string> photos, Insurance insuranceDetails)
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
            if (year <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(licensePlate))
            {
                return false;
            }

            // Check if rentalRate is a positive number
            if (rentalRate <= 0)
            {
                return false; // Rental rate must be greater than 0
            }

            if (photos == null || photos.Count == 0 || photos.Any(photo => string.IsNullOrWhiteSpace(photo)))
            {
                return false;
            }

            //// Check if insuranceDetails is not null and contains valid details
            //if (insuranceDetails == null || !insuranceDetails.isValid())
            //{
            //    return false; // Insurance details are invalid
            //}
            //// All fields are valid
            return true;
        }

        public bool isDuplicate()
        {
            foreach (Car car in cars)
            {
                if (car.licensePlate)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
