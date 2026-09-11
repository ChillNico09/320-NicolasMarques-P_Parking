using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    static internal class Parking
    {
        private static int[] parking = new int[20];

        private static int totalSpot = parking.Length;
        private static int freeSpot;
        private static int usedSpot;

        /// <summary>
        /// Affiche le parking
        /// </summary>
        public static void Display()
        {
            for (int i = 0; i < parking.Length; i++)
            {
                int currentSpotNumber = i + 1;
                if(currentSpotNumber % 5 == 0 && currentSpotNumber > 0)
                {
                    ParkingSpot(true, currentSpotNumber, parking[i]);
                }
                else
                {
                    ParkingSpot(false, currentSpotNumber, parking[i]);
                }
            }
            StatParking();
        }

        /// <summary>
        /// écrit la place de parking.
        /// </summary>
        /// <param name="isEndLine">Pour savoir si on doit faire un retour à la ligne</param>
        /// <param name="spotNumber">Le numéro de la place</param>
        /// <param name="spotState">L'état de la place (libre ou occupé)</param>
        private static void ParkingSpot(bool isEndLine, int spotNumber, int spotState)
        {
            char spotSymbole;
            if (isEndLine)
            {
                if (spotNumber < 10)
                {
                    spotSymbole = CheckParkingSpot(spotState);
                    Console.Write($"|0{spotNumber}:{spotSymbole}|\n");
                }
                else
                {
                    spotSymbole = CheckParkingSpot(spotState);
                    Console.Write($"|{spotNumber}:{spotSymbole}|\n");
                }
            }
            else
            {
                if (spotNumber < 10)
                {
                    spotSymbole = CheckParkingSpot(spotState);
                    Console.Write($"|0{spotNumber}:{spotSymbole}|");
                }
                else
                {
                    spotSymbole = CheckParkingSpot(spotState);
                    Console.Write($"|{spotNumber}:{spotSymbole}|");
                }
            }
        }

        /// <summary>
        /// Permet d'avoir un symbole pour l'état de la place de parking.
        /// </summary>
        /// <param name="spotStatus">Pour savoir l'état du parking (libre ou occupé)</param>
        /// <returns>Retourne le symbole de l'état du parking.
        /// L = Libre
        /// X = occupé
        /// E = erreur/inconnue
        /// </returns>
        private static char CheckParkingSpot(int spotStatus)
        {
            char spotSymbole;
            switch (spotStatus){
                case 0:
                    spotSymbole = 'L';
                    freeSpot++;
                    usedSpot = totalSpot - freeSpot;
                    break;
                case 1:
                    spotSymbole = 'X';
                    usedSpot = totalSpot - freeSpot;
                    break;
                default:
                    spotSymbole = 'E';
                    usedSpot = totalSpot - freeSpot;
                    break;
            }
            return spotSymbole;
        }

        /// <summary>
        /// Affiche diverse statistiques du parking
        /// </summary>
        private static void StatParking()
        {
            double percentageSpotUsed = (double)usedSpot / (double)totalSpot * 100;
            Console.WriteLine("=== Statistiques du parking ===");
            Console.WriteLine($"Nombre de place total: {totalSpot}");
            Console.WriteLine($"Place libre: {freeSpot}");
            Console.WriteLine($"Place occupé: {usedSpot}");
            Console.Write($"Pourcentage d'occupation: {percentageSpotUsed}");
        }
    }
}