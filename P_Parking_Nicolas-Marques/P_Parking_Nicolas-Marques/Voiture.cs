using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    internal class Voiture
    {
        public string LicensingPlate { get; private set; }
        private Ticket ticketCar;

        public Voiture(string licensingPlate, Ticket ticketCar)
        {
            LicensingPlate = licensingPlate;
            this.ticketCar = ticketCar;
        }

        public void testThingy()
        {
            Console.WriteLine(LicensingPlate);
            Console.WriteLine(ticketCar.SpotNumber);
            if (ticketCar.SpotNumber == 1)
            {
                Console.WriteLine("C'est le 1");
            }
            else
            {
                Console.WriteLine("Skibidi trop nul");
            }
        }
    }
}
