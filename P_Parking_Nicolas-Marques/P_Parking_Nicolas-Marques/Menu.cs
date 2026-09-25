using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    static internal class Menu
    {
        private static string[] menuText = {"Entrer un véhicule", "Sortir un véhicule", "Afficher le parking", "Rechercher un véhicule", "Statistiques", "Historique", "Quitter"};
        private static int optionNumber = menuText.Length;

        private static string enterText = "Entrer votre choix: ";



        /// <summary>
        /// Afficher le menu
        /// </summary>
        public static void DisplayMenu()
        {
            int optionIndex = 0;
            Console.WriteLine("=== Menu principal ===");
            foreach (var item in menuText)
            {
                optionIndex++;
                Console.WriteLine($"{optionIndex}: {item}");
            }
            Console.Write(enterText);
            UserInputHandler();
        }

        /// <summary>
        /// Vérifie ce que l'utilisateur choisie
        /// </summary>
        private static void UserInputHandler()
        {
            string userString = Console.ReadLine();
            int chosenNumber = 0;
            while (!int.TryParse(userString, out chosenNumber))
            {
                CheckCorrectInput(userString);
                userString = Console.ReadLine();
            }
            CheckInRange(chosenNumber);
        }

        /// <summary>
        /// Vérifie si l'utilisateur a bien entrer un nombre
        /// </summary>
        /// <param name="userText">Le texte entrer par l'utilsateur</param>
        private static void CheckCorrectInput(string userText)
        {
            int leftPos = Console.CursorLeft = 0;
            int topPos = Console.CursorTop -= 1;
            Console.SetCursorPosition(leftPos, topPos);
            for (int i = 0; i < userText.Length + enterText.Length; i++)
            {
                Console.Write(' ');
            }
            Console.SetCursorPosition(leftPos, topPos);
            Console.Write(enterText);
        }

        /// <summary>
        /// Va vérifier si le nombre entrer par l'utilisateur est utilisable
        /// </summary>
        /// <param name="userNumber">Le nombre entré par l'utilisateur</param>
        private static void CheckInRange(int userNumber)
        {
            if(userNumber > 0 && userNumber < optionNumber)
            {
                UseOption(userNumber);
            }
            else
            {
                Console.WriteLine($"Vous devez choisir un nombre entre 1 et {optionNumber}");
                Thread.Sleep(1500);
                UserInputHandler();
            }
            
        }

        /// <summary>
        /// Utiliser l'option que l'utilisateur a entré
        /// </summary>
        /// <param name="optionNumber">Le numéro de l'option a appeler</param>
        private static void UseOption(int optionNumber)
        {
            switch (optionNumber)
            {
                //1: Entrer un véhicule
                case 1:
                    Console.WriteLine("");
                    break;
                //2: Sortir un véhicule
                case 2:
                    Console.WriteLine("");
                    break;
                //3: Afficher le parking
                case 3:
                    CallParking();
                    break;
                //4: Rechercher un véhicule
                case 4:
                    Console.WriteLine("");
                    break;
                //5: Statistiques
                case 5:
                    Console.WriteLine("");
                    break;
                //6: Historique
                case 6:
                    Console.WriteLine("");
                    break;
                //7: Quitter
                case 7:
                    Console.WriteLine("");
                    break;
            }
        }

        /// <summary>
        /// Appeler la classe parking pour l'afficher
        /// </summary>
        private static void CallParking()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Parking.Display();
            Console.WriteLine("\n\n\n");
            DisplayMenu();
        }
    }
}
