using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_iCar
{
    internal class UI_RegisterCar
    {
        private CTL_RegisterCar ctlRegisterCar;

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

        }

        public void addNewCar(string make, string model, int year, float mileage, string licensePlate, List<string> photos, Insurance insuranceDetails)
        {

        }

        public bool promptConfirmation()
        {
            return true;
        }

        public void submitConfirmation()
        {

        }
    }
}
