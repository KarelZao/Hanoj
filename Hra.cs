using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanojskeVeze
{
    class Hra
    {
        private int tahy;
        private int nDisk;
        private Vez[] veze;

        // Konstruktor :
        // bere počet disků ( nDisk ).
        // 1. Vytvoří 3 věže
        // 2. Vytvoří n disků velikosti 1, 2, 3 .... na věži 0
        // 3. Nastaví velikost konzoly na Map.MaxLeft a Map.MaxTop
        public Hra(int nDisk)
        {
            veze = new Vez[3];
            veze[0] = new Vez(nDisk, HraciPlocha.VezVlevo[0], HraciPlocha.VezTop, HraciPlocha.VezTyc);
            veze[1] = new Vez(nDisk, HraciPlocha.VezVlevo[1], HraciPlocha.VezTop, HraciPlocha.VezTyc);
            veze[2] = new Vez(nDisk, HraciPlocha.VezVlevo[2], HraciPlocha.VezTop, HraciPlocha.VezTyc);

            for (int i = nDisk-1, index = 0; i >= 0; i--, index++)
            {
                veze[0].PosunDisk(new Disky(i+1, HraciPlocha.VezVlevo[0], HraciPlocha.VezTyc - index, HraciPlocha.BarvyDisku[i]));
            }

            Console.SetWindowSize(HraciPlocha.MaxLeft, HraciPlocha.MaxTop);

            this.nDisk = nDisk;
            tahy = 0;
        }

        // Hraje počítač
        public void HrajeStroj(int disky, int src, int aux, int dst)
        {
            if(disky > 0)
            {
                HrajeStroj(disky - 1, src, dst, aux);
                Tah(src, dst);
                HrajeStroj(disky - 1, aux, src, dst);
            }
        }

        public bool Tah(int src, int dst)
        {
            try
            {
                // update počtu tahů
                tahy++;

                // nový tah
                if (src >= 0 && src <= 2 && dst >= 0 && dst <= 2 && veze[src].PocetDisku() > 0)
                {
                    if(veze[dst].PosunDisk(veze[src].Peek()))
                    {
                        veze[dst].Peek().Posun(HraciPlocha.VezVlevo[dst], HraciPlocha.VezTyc - veze[dst].PocetDisku()+1);

                        veze[src].ZvedniDisk();

                        return true;
                    }
                } 

                return false;
            }
            catch
            {
                return false;
            }            
        }

        // Zobrazí výzvu v barvach
        public void ZpravaHraci(string vyzva)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(HraciPlocha.ZpravaZleva, HraciPlocha.ZpravaShora);

            Console.Write(vyzva);

            Console.ResetColor();
        }

        public void Vykresli()
        {
            Console.Clear();

            // vytvoří základnu
            Console.SetCursorPosition(HraciPlocha.ZakladnaLeft, HraciPlocha.ZakladnaTop);
            for(int i = HraciPlocha.ZakladnaLeft; i <= HraciPlocha.ZakladnaRight; i++)
            {
                Console.Write("=");
            }

            // vytvoří věže
            for(int i = 0; i < veze.Length; i++)
            {
                veze[i].Vykresli();
            }
            
            // tahy
            Console.SetCursorPosition(HraciPlocha.TahyVlevo, HraciPlocha.TahyShora);
            Console.Write("Počet tahů: {0}", tahy);
        }

        public bool Vitez()
        {
            return (veze[2].PocetDisku() == nDisk);
        }

        // Zobrazí výzvu "Zdrojova vez (1,2,3,q):"
        public void VyberZdrojovouVez()
        {
            Console.SetCursorPosition(HraciPlocha.Nalevo, HraciPlocha.Nahoru);
            Console.Write("Zdrojová věž (1,2,3,q): ");
        }

        // Zobrazí výzvu "Cílová vez (1,2,3,q): "
        public void VyberCilovouVez()
        {
            Console.SetCursorPosition(HraciPlocha.Zleva, HraciPlocha.Zhora);
            Console.Write("Cílová věž (1,2,3,q): ");
        }

    }
}
