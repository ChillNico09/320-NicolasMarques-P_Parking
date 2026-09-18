using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_Nicolas_Marques
{
    static internal class RandomNumber
    {
        static Random rng = new Random();
        public static int GenerateNumber(int mini, int maxi)
        {
            return rng.Next(mini, maxi);
        }
    }
}
