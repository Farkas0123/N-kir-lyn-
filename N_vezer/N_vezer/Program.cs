using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueen_nemrek
{
    class Program
    {
        static int[] hol;

        static bool Utik_egymast(int x1, int y1, int x2, int y2)
            => (Math.Abs(x1 - x2) == Math.Abs(y1 - y2) || y1 == y2);// || x1==x2 ez a modellből következik!

        static bool Rossz(int i, int j, int[] J)
        { 
            for (int ix = 0; ix < i; ix++) // csúnyán programozunk
                if (Utik_egymast(ix, J[ix], i, j))
                    return true;
            return false;
        }
        /* Ez átment a rekurzióba, for-ciklusként
        static (bool, int) Oszlopban_keres(int i)
        {
            int j = hol[i] + 1; // -1-es inicializálásból itt lesz 0-ás index!
            while (j < hol.Length && Rossz(i, j, hol)) // a rossz-ban lesz szó egyedül a sakkról!
            {
                j++;
            }
            return (j < hol.Length, j);
        }*/

        static bool NQueens(int x)
        {
            bool siker = x == hol.Length;
            bool level = siker;
            //bool remenytelen = ;
            if (siker)
            {
                return true;
            }
            for (int y = hol[x]+1; y < hol.Length; y++)
            {
                if (!Rossz(x, y, hol))
                {
                    hol[x] = y;
                    if (NQueens(x+1))
                    {
                        return true;
                    }
                }
            }
            hol[x] = -1;
            return false;

            // Jobbra-balra keres
            /** /int i = 0;
            while (0 <= i && i < N)
            {
                (bool van, int j) = Oszlopban_keres(i, hol);
                if (van)
                    hol[i++] = j;
                else
                    hol[i--] = -1;
            }
            /**/
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int N = int.Parse(input);
            hol = new int[N];

            for (int ix = 0; ix < N; ix++)
                hol[ix] = -1;
            NQueens(0);
            string stringforma = string.Join(" ", hol);

            Console.WriteLine(stringforma);
            Console.ReadKey();
        }
    }
}