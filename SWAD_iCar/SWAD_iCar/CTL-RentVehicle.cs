using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    public class CTL_RentVehicle
    {
        public Car GetCar(int carId)
        {
            
        } 
        
        public Renter GetRenter(int renterId) 
        {

        }

        public DateOnly GetDateOnly(DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }

        public TimeOnly GetTimeOnly(DateTime dateTime)
        {
            return TimeOnly.FromDateTime(dateTime);
        }

        public List<ICarStation> getAlliCarStations()
        {
            // HELP
        }
    }
}
