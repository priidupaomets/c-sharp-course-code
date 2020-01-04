using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 2, 1, 4, 3, 5, 6 };

            var vaikseimad = LeiaVaikseimad(numbers, 3);

            foreach (int num in vaikseimad)
            {
                Console.WriteLine(num);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Leiame nimekirjast N väikseimat numbrit
        /// </summary>
        /// <param name="numbrid">List numbritest</param>
        /// <param name="kogus">Soovitud minimaalsete numbrite arv</param>
        /// <returns>Nimekiri minimaalsetest numbritest</returns>
        static List<int> LeiaVaikseimad(List<int> numbrid, int kogus)
        {
            // Loome sisemise nimekirja tulemuste hoidmiseks
            var pisimad = new List<int>();

            // Kuni soovitud arv minimaalseid numbreid pole täis saanud, jätkame otsinguid
            while (pisimad.Count < kogus)
            {
                // Leiame järgmise minimaalse numbri
                var min = LeiaVaikseim(numbrid);

                // Lisame numbri tulemuste listi ja eemaldame selle algsest listist
                pisimad.Add(min);
                numbrid.Remove(min);
            }

            return pisimad;
        }

        /// <summary>
        /// Leiame listist minimaalse väärtusega numbri
        /// </summary>
        /// <param name="numbrid">List, mille hulgast minimaalset otsida</param>
        /// <returns>Minimaalseim number</returns>
        static int LeiaVaikseim(List<int> numbrid)
        {
            var min = numbrid[0];

            for (int i = 1; i < numbrid.Count; i++)
            {
                // Siin oli meil alguses viga, kus võrdlus oli pahupidi. Selle leidsime silumise (debugging) abil
                if (numbrid[i] < min)
                    min = numbrid[i];
            }

            return min;
        }

    }
}
