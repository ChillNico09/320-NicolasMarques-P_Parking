using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HelloWorld!");
            Ticket ticket = new Ticket(1, 1);
            Parking.Display();
            Thread.Sleep(1000);
            ticket.Calc();
            List<Voiture> list = new List<Voiture>();
            
            list.Add(new Voiture("hello", ticket));
            Voiture voiture1 = new Voiture("hello", ticket);
            voiture1.testThingy();

            if (list[0].LicensingPlate == "hello")
            {
                Console.WriteLine("LEEEEEEEEEEEEEEEEETS GO");
            }
            else
            {
                Console.WriteLine("Quelle dommage");
            }
                Console.ReadLine();
        }
    }
}
