using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanojskeVeze
{
    class Vez
    {
        private Disky[] disky;
        private int vlevo;
        private int shora;
        private int spodek;
        private int index;
        private int velikost;
        
        // Vytvoří věž:
        // maxDisk: počet disků
        public Vez(int maxDisk, int vlevo, int shora, int spodek)
        {
            disky = new Disky[maxDisk];
            index = -1;
            this.vlevo = vlevo;
            this.shora = shora;
            this.spodek = spodek;
            velikost = maxDisk;
        }

        // Přesune disk když je věž prázdná, nebo platí podmínka velikosti
        public bool PosunDisk(Disky dsc)
        {
            if (PocetDisku() == 0 || dsc.Velikost < Peek().Velikost)
            {
                index++;
                disky[index] = dsc;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Zvedne disk z věže
        public Disky ZvedniDisk()
        {
            if(velikost > 0)
            {
                Disky disk = disky[index];
                disky[index] = null;

                index--;

                return disk;
            }

            return null;
        }

        // Vrátí nejhornější disk
        public Disky Peek()
        {
            if (index >= 0)
            {
                return disky[index];
            }

            return null;
        }

        // Vykreslí věž s disky
        public void Vykresli()
        {
            // vykreslí tyč
            for (int radek = 0; radek < 8; radek++)
            {
                Console.SetCursorPosition(vlevo, shora + radek);
                Console.Write("{0}", "||");
            }

            // vykreslí disky
            for(int radek = index; radek >= 0; radek--)
            {
                disky[radek].Vykresli();
            }
        }

        // Vrátí počet disků na věži
        public int PocetDisku()
        {
            return index+1;
        }
    }
}
