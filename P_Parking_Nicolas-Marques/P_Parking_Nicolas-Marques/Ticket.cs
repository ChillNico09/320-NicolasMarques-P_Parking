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
        private DateTime EnterTime;
        public int SpotNumber { get; private set; }
        private int HourlyRate;

        public Ticket(int spotNumber, int hourlyRate)
        {
            EnterTime = DateTime.Now;
            //Console.WriteLine(EnterTime);

            SpotNumber = spotNumber;
            HourlyRate = hourlyRate;
        }

        public void Calc()
        {
            TimeSpan duration = DateTime.Now - EnterTime;
            //Console.WriteLine("\n"+duration.Seconds);
        }
    }
}
