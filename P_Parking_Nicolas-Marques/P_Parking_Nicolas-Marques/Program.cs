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
            bool continueProgram = true; //Cette variable devra être mis en "false" quand nécessaire
            Parking.Display();
            Console.Clear();

            while (continueProgram)
            {
                Menu.DisplayMenu();
            }   
            //Mettre la List<Voiture> dans la classe "Parking"
            List<Voiture> list = new List<Voiture>();



            /*
            list.Add(new Voiture("VD-17344"));
            list.Add(new Voiture("GE-1941"));
            list.Add(new Voiture("FR-679013"));
            list.Add(new Voiture("VS-6o9")); //Invalide pour le débug
            list.Add(new Voiture("V2-69")); //Invalide pour le débug
            */
            
            /*
            Parking.Display();
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].IsValid)
                {
                    Console.WriteLine($"\n{list[i]}");
                }
                else
                {
                    list[i] = null;
                }
            }
            */
        }
    }
}
