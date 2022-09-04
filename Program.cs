using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanojskeVeze
{
    class Program
    {
        static void Main(string[] args)
        {
            VstupHrace vstup = new VstupHrace();

            // přijme počet disků (3, 4, 5)
            int nDisk = vstup.NactiPocetDisku();

            Hra hra = new Hra(nDisk);
            
            // Vykreslí herní plochu
            hra.Vykresli();

            do
            {
                ///**** hra *****///
                // Načte zdrojovou a cílovou věž
                hra.VyberZdrojovouVez();
                int zdroj = vstup.NactiPozici();
                if (zdroj < 0)
                    break;

                hra.VyberCilovouVez();

                int cil = vstup.NactiPozici();
                if (cil < 0)
                    break;
                
                // Zkus přesunout disk
                bool legalniTah = hra.Tah(zdroj, cil);
                

                // překreslí plochu
                hra.Vykresli();

                if (!legalniTah)
                {
                    hra.ZpravaHraci("Tento tah není možný " + (zdroj + 1) + " -> " + (cil + 1));
                }
            } while (!hra.Vitez());

            hra.ZpravaHraci("Stiskni libovolnou klávesu a skončíš");

            Console.ReadLine();
        }
    }
}
