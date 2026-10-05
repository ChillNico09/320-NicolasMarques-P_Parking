using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    static internal class Parking
    {
        private static int[] parking = new int[20];
        private static int minParkingIndex = 1;
        private static int maxParkingIndex = parking.Length;

        private static int totalSpot = parking.Length;
        private static int freeSpot;
        private static int usedSpot;

        private static List<Voiture> parkedCarList = new List<Voiture>();
        private static List<Voiture> carList = new List<Voiture>();

        /// <summary>
        /// Affiche le parking
        /// </summary>
        public static void Display()
        {
            freeSpot = 0;
            usedSpot = 0;
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
            StatParking(false, false);
        }

        /// <summary>
        /// Va implémenter le véhicule dans le parking
        /// </summary>
        /// <param name="vehicle">Le véhicule qu'on doit entrer dans le parking</param>
        public static void AddVehicle(Voiture vehicle)
        {
            int randomSpot = RandomNumber.GenerateNumber(minParkingIndex, maxParkingIndex);
            if(freeSpot > 0)
            {
                while(parking[randomSpot] != 0)
                {
                    randomSpot = RandomNumber.GenerateNumber(minParkingIndex, maxParkingIndex);
                }
                parking[randomSpot] = 1;
                randomSpot += 1;
                Ticket ticket = new Ticket(randomSpot, 1);
                //Thread.Sleep(100);
                vehicle.ReceiveTicket(ticket);
                parkedCarList.Add(vehicle);
            }
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
        /// Va rechercher un véhicule via l'input de l'utilisateur
        /// </summary>
        /// <param name="licensePlate">La plaque d'immatriculation possiblement entrer par l'utilisateur</param>
        /// <param name="spotNumber">Le numéro de la place de parking possiblement entrer par l'utilisateur</param>
        /// <param name="checkLicensePlate">Si on veut checker la plaque d'immatriculation ou son numéro de place de parking</param>
        /// <param name="removeCar">Si on veut retirer la voiture ou simplement y afficher ses statisiques</param>
        public static void FindVehicule(string licensePlate, int spotNumber, bool checkLicensePlate, bool removeCar)
        {
            foreach(Voiture car in parkedCarList)
            {
                bool foundCorrectCar = FindVehicleCondition(car, licensePlate, spotNumber, checkLicensePlate, removeCar);
                if (foundCorrectCar)
                {
                    return;
                }
                else
                {
                    foundCorrectCar = FindVehicleCondition(car, licensePlate, spotNumber, checkLicensePlate, removeCar);
                }
            }
            Console.WriteLine("Aucune correspondance n'a pu être trouver.");
        }

        /// <summary>
        /// Va checker la plaque d'immatriculation ou la place de parking
        /// </summary>
        /// <param name="car">La voiture qu'on vérifie pour savoir si c'est la bonne</param>
        /// <param name="licensePlate">La plaque d'immatriculation possiblement entrer par l'utilisateur</param>
        /// <param name="spotNumber">Le numéro de la place de parking possiblement entrer par l'utilisateur</param>
        /// <param name="checkLicensePlate">Si on veut checker la plaque d'immatriculation ou son numéro de place de parking</param>
        /// /// <param name="removeCar">Si on veut retirer la voiture ou simplement y afficher ses statisiques</param>
        private static bool FindVehicleCondition(Voiture car, string licensePlate, int spotNumber, bool checkLicensePlate, bool removeCar)
        {
            if (checkLicensePlate)
            {
                if (car.LicensingPlate == licensePlate)
                {
                    FindVehicleReturn(car, removeCar);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (car.ticketCar.SpotNumber == spotNumber)
                {
                    FindVehicleReturn(car, removeCar);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Va retourner un résultat dépendant si on doit afficher ou retirer le véhicule
        /// </summary>
        /// <param name="car">La voiture</param>
        /// <param name="removeCar">Si on veut retirer la voiture ou simplement y afficher ses statisiques</param>
        private static void FindVehicleReturn(Voiture car, bool removeCar)
        {
            if (removeCar)
            {
                parkedCarList.Remove(car);
                carList.Add(car);
                car.ticketCar.Calc();
                parking[car.ticketCar.SpotNumber-1] = 0;
                Console.WriteLine(car);
            }
            else
            {
                Console.WriteLine(car);
            }
        }

        /// <summary>
        /// Affiche diverse statistiques du parking
        /// </summary>
        /// <param name="isDailyStat">Permet de savoir si on veut les statistiques du jour ou simplement les statistiques du parking</param>
        public static void StatParking(bool isDailyStat, bool isTransactionHistory)
        {
            if (isDailyStat)
            {
                WriteStats(isDailyStat, isTransactionHistory);
            }
            else
            {
                WriteStats(isDailyStat, isTransactionHistory);
            }
        }

        /// <summary>
        /// Va écrire les statistiques.
        /// </summary>
        /// <param name="isDailyStat">Permet de savoir quelle type de statistique à afficher</param>
        private static void WriteStats(bool isDailyStat, bool isTransactionHistory)
        {
            if (isDailyStat)
            {
                Display();
                Console.Clear();
                int totalPricePaid = 0;
                double percentageSpotUsed = (double)usedSpot / (double)totalSpot * 100;
                Console.WriteLine("=== Statistiques du jour ===");
                Console.WriteLine($"Nombre de place total: {totalSpot}");
                Console.WriteLine($"Place libre: {freeSpot}");
                Console.WriteLine($"Place occupé: {usedSpot}");
                Console.WriteLine($"Pourcentage d'occupation: {percentageSpotUsed}");
                totalPricePaid = GetTotalPaidPrice();
                Console.WriteLine($"Montant total payé: {totalPricePaid}");
                WriteAllParkedTime();
            }
            else if (isTransactionHistory)
            {
                Console.Clear();
                Console.WriteLine("=== Historique des transactions ===");
                WriteTransactionHistory();
            }
            else
            {
                double percentageSpotUsed = (double)usedSpot / (double)totalSpot * 100;
                Console.WriteLine("=== Statistiques du parking ===");
                Console.WriteLine($"Nombre de place total: {totalSpot}");
                Console.WriteLine($"Place libre: {freeSpot}");
                Console.WriteLine($"Place occupé: {usedSpot}");
                Console.Write($"Pourcentage d'occupation: {percentageSpotUsed}");
            }
        }

        /// <summary>
        /// Récuperer le montant payé par tout les véhicule qui on quitté le parking
        /// </summary>
        /// <returns>Montant total payé de tout les véhicules qui on quitté le parking</returns>
        private static int GetTotalPaidPrice()
        {
            int totalPricePaid = 0;
            foreach (Voiture car in carList)
            {
                totalPricePaid += car.ticketCar.totalPrice;
            }
            return totalPricePaid;
        }

        /// <summary>
        /// Va écrire la durée de stationnement actuel de tout les véhicules
        /// </summary>
        private static void WriteAllParkedTime()
        {
            foreach (Voiture car in parkedCarList)
            {
                TimeSpan parkedTime = car.ticketCar.GetCurrentParkedTime();
                Console.WriteLine($"\nPlaque d'immatriculation: {car.LicensingPlate}\nTemp de stationement: {parkedTime.Hours}:{parkedTime.Minutes}:{parkedTime.Seconds}");
            }
        }

        /// <summary>
        /// Va écrire l'historique de transactions de tout les véhicules qui sont sortie du parking
        /// </summary>
        private static void WriteTransactionHistory()
        {
            foreach (Voiture car in carList)
            {
                Console.WriteLine($"\nHeure d'entrée: {car.ticketCar.EnterTime} - Plaque d'immatriculations: {car.LicensingPlate}\nHeure d'entrée: {car.ticketCar.ExitTime} - Plaque d'immatriculations: {car.LicensingPlate} - Montant payé: {car.ticketCar.totalPrice}");
            }
        }
    }
}