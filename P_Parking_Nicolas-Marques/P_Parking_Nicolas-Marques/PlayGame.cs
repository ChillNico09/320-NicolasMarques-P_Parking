using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    internal static class PlayGame
    {
        private static bool continueProgram = Menu.ContinueProgram;

        /// <summary>
        /// Va commencer le programme, afficher le menu etc...
        /// </summary>
        public static void StartProgram()
        {
            InitiateParking();

            while (continueProgram)
            {
                Menu.DisplayMenu();
                UpdateValues();
            }
        }

        /// <summary>
        /// Mettre à jour les valeurs qui pointe sur d'autre classes
        /// </summary>
        private static void UpdateValues()
        {
            continueProgram = Menu.ContinueProgram;
        }

        /// <summary>
        /// Initialiser le parking pour ensuite y ajouter des voitures
        /// </summary>
        private static void InitiateParking()
        {
            Parking.Display();
            Console.Clear();
        }
    }
}
