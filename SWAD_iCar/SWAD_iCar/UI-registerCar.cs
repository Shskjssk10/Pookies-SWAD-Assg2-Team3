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

        private void DisplayRegisterCarForm()
        {
            var car = new CarRegistration
            {
                Photos = new List<string>(),
                InsuranceDetails = new InsuranceDetails()
            };


        }

        private void AddNewCar()
        {

        }
    }
}
