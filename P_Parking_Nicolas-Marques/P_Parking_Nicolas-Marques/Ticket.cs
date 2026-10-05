using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    internal class Ticket
    {
        public DateTime EnterTime { get; private set; }
        public DateTime ExitTime { get; private set; }
        private int _spotNumber;
        private bool isParked;

        public int totalPrice {  get; private set; }
        public int SpotNumber
        {
            get
            {
                return _spotNumber;
            }
            private set
            {
                if (value >= 0 && value <= 20)
                {
                    _spotNumber = value;
                }
            }
        }
        private int HourlyRate;

        public Ticket(int spotNumber, int hourlyRate)
        {
            EnterTime = DateTime.Now;
            isParked = true;

            SpotNumber = spotNumber;
            HourlyRate = hourlyRate;
        }

        /// <summary>
        /// Calculer la durée total du stationnement puis le montant total payé
        /// </summary>
        public void Calc()
        {
            isParked = false;
            ExitTime = DateTime.Now;
            TimeSpan duration = GetCurrentParkedTime();
            totalPrice = (int)duration.TotalSeconds;
        }

        /// <summary>
        /// Va calculé la durée du stationnement actuel
        /// </summary>
        /// <returns>La durée actuel de stationnement</returns>
        public TimeSpan GetCurrentParkedTime()
        {
            TimeSpan duration = DateTime.Now - EnterTime;
            return duration;
        }


        public override string ToString()
        {
            if (isParked)
            {
                return $"Parker au numéro: {SpotNumber}\nHeure d'entrer: {EnterTime.Hour}:{EnterTime.Minute}:{EnterTime.Second}";
            }
            else
            {
                return $"Parker au numéro: {SpotNumber}\nHeure d'entrer: {EnterTime.Hour}:{EnterTime.Minute}:{EnterTime.Second}\nHeure de sortie: {ExitTime.Hour}:{ExitTime.Minute}:{ExitTime.Second}\nMontant payé: {totalPrice}";
            }
        }
    }
}
