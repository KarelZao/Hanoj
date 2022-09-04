using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanojskeVeze
{
    class VstupHrace
    {
        // Načte vstupni data od hrace, q je konec hry
        public int NactiPozici()
        {            
            while (true)
            {
                ConsoleKeyInfo klavesa = Console.ReadKey(true);
                
                switch(klavesa.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Write("1");
                        return 0;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Write("2");
                        return 1;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Write("3");
                        return 2;
                    case ConsoleKey.Q:
                        Console.Write("q");
                        return -1;
                }
            }
        }

        // Načte počet disků
        public int NactiPocetDisku()
        {
            int pocet = 0;

            while (true)
            {
                try
                {
                    Console.Write("S kolika disky chceš hrát? (3...5): ");
                    pocet = Convert.ToInt32(Console.ReadLine());

                    if (pocet < 3 || pocet > 5)
                    {
                        throw new Exception();
                    }

                    return pocet;
                }
                catch
                {
                    Console.WriteLine("Tento počet není možný.");
                }
            }
        }
    }
}
