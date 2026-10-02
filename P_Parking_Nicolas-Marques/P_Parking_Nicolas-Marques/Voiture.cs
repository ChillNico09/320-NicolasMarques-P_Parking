using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    internal class Voiture
    {
        private string _licensingPlate;
        public string LicensingPlate
        {
            get
            {
                return _licensingPlate;
            }
            private set
            {
                if(Regex.IsMatch(value, @"^[A-Z]{2}-\d{1,6}$"))
                {
                    Debug.WriteLine("Valid");
                    _licensingPlate = value;
                    IsValid = true;
                    Console.WriteLine($"Votre voiture ({LicensingPlate}) à été ajouté au parking!");
                }
                else
                {
                    Debug.WriteLine("Invalid");
                    IsValid = false;
                    Console.WriteLine($"Le format est incorrecte. La voiture n'a pas été ajouté.");
                }
            }
        }
        public bool IsValid { get; private set; }
        public Ticket ticketCar { get; private set; }

        public Voiture(string licensingPlate)
        {
            LicensingPlate = licensingPlate;
            if (IsValid)
            {
                Parking.AddVehicle(this);
            }
            
        }

        /// <summary>
        /// Pour recevoir un ticket donner par la méthode "AddVehicle" dans "Parking.cs"
        /// </summary>
        /// <param name="ticket">Pour pouvoir réceptionner le ticket</param>
        public void ReceiveTicket(Ticket ticket)
        {
            ticketCar = ticket;
        }

        public override string ToString()
        {
            return $"Plaque d'immatriculation: {LicensingPlate}\n{ticketCar}";
        }
    }
}
