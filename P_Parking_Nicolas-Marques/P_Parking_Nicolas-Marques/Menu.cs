using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    static internal class Menu
    {
        private static string[] menuText = {"Entrer un véhicule", "Sortir un véhicule", "Afficher le parking", "Rechercher un véhicule", "Statistiques", "Historique", "Quitter"};
        private static int optionNumber = menuText.Length;

        private static string enterText = "Entrer votre choix: ";
        public static bool ContinueProgram { get; private set; } = true;


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
        /// Va effacer l'input de l'utilisateur si il était faux.
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
            if(userNumber > 0 && userNumber <= optionNumber)
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
                    EnterVehicle();
                    break;
                //2: Sortir un véhicule
                case 2:
                    SearchVehicle(true);
                    break;
                //3: Afficher le parking
                case 3:
                    CallParking();
                    break;
                //4: Rechercher un véhicule
                case 4:
                    SearchVehicle(false);
                    break;
                //5: Statistiques
                case 5:
                    Parking.StatParking(true, false);
                    break;
                //6: Historique
                case 6:
                    Parking.StatParking(false, true);
                    break;
                //7: Quitter
                case 7:
                    ContinueProgram = false;
                    break;
            }
        }

        /// <summary>
        /// Appeler la classe parking pour l'afficher
        /// </summary>
        private static void CallParking()
        {
            ClearConsoleAndPosition();
            Parking.Display();
            ReturnMultipleLines();
            DisplayMenu();
        }

        /// <summary>
        /// Permet à l'utilisateur d'entrer un véhicule
        /// </summary>
        private static void EnterVehicle()
        {
            ClearConsoleAndPosition();
            Console.Write("Ajouter un véhicule\nEntrer une plaque sous ce format (2LettresMajuscules-1à6Chiffres)\nEntrer une valeur : ");
            string userLicensePlate = Console.ReadLine();
            if (userLicensePlate != null)
            {
                new Voiture(userLicensePlate);
            }
            ReturnMultipleLines();
            DisplayMenu();
        }

        /// <summary>
        /// Va rechercher un véhicule via son numéro de place de parking ou sa plaque d'immatriculation
        /// </summary>
        /// <param name="removeCar">Si on doit retirer le véhicule quand il est trouver</param>
        private static void SearchVehicle(bool removeCar)
        {
            ClearConsoleAndPosition();
            if (removeCar)
            {
                Console.Write("Retirer un véhicule\nEntrer une plaque sous ce format (2LettresMajuscules-1à6Chiffres)\nou son numéro de place\nEntrer une valeur : ");
            }
            else
            {
                Console.Write("Rechercher un véhicule\nEntrer une plaque sous ce format (2LettresMajuscules-1à6Chiffres)\nou son numéro de place\nEntrer une valeur : ");
            }
            
            int spotNumber = 0;
            string userLicensePlate = Console.ReadLine();
            if (userLicensePlate != null)
            {
                if(int.TryParse(userLicensePlate, out spotNumber))
                {
                    CallFindVehicle(userLicensePlate, spotNumber, false, removeCar);
                }
                else
                {
                    if (Regex.IsMatch(userLicensePlate, @"^[A-Z]{2}-\d{1,6}$"))
                    {
                        CallFindVehicle(userLicensePlate, spotNumber, true, removeCar);
                    }
                }
            }
            DisplayMenu();
        }

        /// <summary>
        /// Va appeller la méthode "CallFindVehicle" de la classe "Parking"
        /// </summary>
        /// <param name="userLicensePlate">La possible plaque entrer par l'utilisateur</param>
        /// <param name="spotNumber">La possible place de parking enter par l'utilisateur</param>
        /// <param name="checkLicensePlate">Si on doit vérifier la plaque ou le numéro de place</param>
        /// <param name="removeCar">Si on doit retirer le véhicule quand trouver</param>
        private static void CallFindVehicle(string userLicensePlate, int spotNumber, bool checkLicensePlate, bool removeCar)
        {
            bool keepVehicle = true;
            if (removeCar)
            {
                keepVehicle = UserIsSure(true);
                if (keepVehicle)
                {
                    Console.WriteLine("Action annulé");
                }
                else
                {
                    Parking.FindVehicule(userLicensePlate, spotNumber, checkLicensePlate, removeCar);
                }
            }
            else
            {
                Parking.FindVehicule(userLicensePlate, spotNumber, checkLicensePlate, removeCar);
                ReturnMultipleLines();
            }
            
        }

        /// <summary>
        /// Poser la question à l'utilisateur s'il est sûr de vouloir retirer le véhicule entrer
        /// </summary>
        /// <param name="firstCall">Si c'est la première fois qu'il essaye d'entrer son choix (ex: appeler une deuxième fois car la valeur était incorrecte)</param>
        private static bool UserIsSure(bool firstCall)
        {
            int userFinalDecision = 0;
            bool keepVehicle = true;
            if (firstCall)
            {
                Console.Write("Êtes-vous sûr?\nOui = 1\nNon = 0\nEntrer une valeur : ");
            }
            else
            {
                Console.Write("Veillez entrer une valeur valide\nÊtes-vous sûr?\nOui = 1\nNon = 0\nEntrer une valeur : ");
            }
            
            string userEnteredDecision = Console.ReadLine();
            if(int.TryParse(userEnteredDecision, out userFinalDecision))
            {
                keepVehicle = ChoiceSwitchCase(userFinalDecision);
            }
            else
            {
                ClearConsoleAndPosition();
                Console.WriteLine("valeur entrer invalide.");
                keepVehicle = true;
            }
            return keepVehicle;
        }

        private static bool ChoiceSwitchCase(int userDecision)
        {
            bool keepVehicle = true;
            bool madeDecision = false;
            if(!madeDecision)
            {
                switch (userDecision)
                {
                    //Garder
                    case 0:
                        madeDecision = true;
                        keepVehicle = true;
                        break;
                    //Retirer
                    case 1:
                        madeDecision = true;
                        keepVehicle = false;
                        break;
                    default:
                        madeDecision = false;
                        keepVehicle = true;
                        ClearConsoleAndPosition();
                        UserIsSure(false);
                        break;
                }
            }
            return keepVehicle;
        }

        /// <summary>
        /// éfface la console puis remet le curseur au tout début
        /// </summary>
        private static void ClearConsoleAndPosition()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Fait plusieur retour à la ligne
        /// </summary>
        private static void ReturnMultipleLines()
        {
            Console.Write("\n\n\n");
        }
    }
}
