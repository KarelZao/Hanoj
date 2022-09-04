using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanojskeVeze
{
    class Disky
    {
        private int velikost;
        private int vlevo;
        private int nahoru;
        private ConsoleColor barva;

        // Konstruktor předává velikost, pozice a barvu.
        // velikost je od 1 do 5
        public Disky(int velikost, int vlevo, int nahoru, ConsoleColor barva)
        {
            this.velikost = velikost;
            this.vlevo = vlevo;
            this.nahoru = nahoru;
            this.barva = barva;
        }

        // Vrací velikost disku
        public int Velikost
        {
            get
            {
                return velikost;
            }
        }

        // Vykreslí disk
        public void Vykresli()
        {
            Console.BackgroundColor = barva;
            Console.SetCursorPosition(vlevo - velikost*2 + 1, nahoru);
            
            for (int s = 0; s < velikost * 4; s++)
            {
                Console.Write(" ");
            }            

            Console.SetCursorPosition(vlevo, nahoru);
            Console.Write("||");

            Console.ResetColor();
        }

        // Nastaví souřadnice disku
        public void Posun(int left, int top)
        {
            this.vlevo = left;
            this.nahoru = top;
        }

    }
}
