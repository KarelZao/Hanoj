using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanojskeVeze
{
    class HraciPlocha
    {
        public const int MaxTop = 30;
        public const int MaxLeft = 100;
        public const int ZakladnaLeft = 5;
        public const int ZakladnaRight = 95;
        public const int ZakladnaTop = 18;
        public const int VezTop = 10;
        public const int VezTyc = 17;
        public static int[] VezVlevo = { 20, 50, 80 };
        public const int Nalevo = 5;
        public const int Nahoru = 23;
        public const int Zleva = 35;
        public const int Zhora = 23;
        public const int ZpravaZleva = 5;
        public const int ZpravaShora = 25;
        public const int TahyVlevo = 5;
        public const int TahyShora = 2;
        public static ConsoleColor[] BarvyDisku =
        {
            ConsoleColor.Red, // Disk 1 
            ConsoleColor.DarkGreen, // Disk 2 
            ConsoleColor.Yellow, // Disk 3 
            ConsoleColor.DarkBlue, // Disk 4 
            ConsoleColor.Magenta // Disk 5 
        };
    }
}
