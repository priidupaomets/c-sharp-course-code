using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractOfText
{
    class Program
    {
        static void Main(string[] args)
        {
            string lause = "See on väga väga väga väga väga väga väga pikk lause, mis tavaliselt ei mahu korraga kuhugi ära";
            const int maxPikkus = 20;

            Console.WriteLine("Kokkuvõte:");

            // Kutsume välja funktsiooni, mis arvutab teksti kokkuvõtte
            string kokkuvõte = TagastaKokkuvõte(lause, maxPikkus);

            // Tulemuste väljastamine on antud rakenduse osa, mitte funktsiooni, mis tulemust arvutab!
            Console.WriteLine(kokkuvõte);
        }

        /// <summary>
        /// See on korduvalt kasutatav funktsioon, mis arvutab etteantud tekstist etteantud pikkusega kokkuvõtte.
        /// Funktsioon ei tee midagi peale tulemuse arvutamise ja tagastamise, seega saab seda kasutada suvalisest
        /// rakenduse tüübist, olgu selleks konsooli-rakendus, graafilise kasutajaliidesega rakendus, veebirakendus
        /// või isegi mobiilirakendus.
        /// </summary>
        /// <param name="lause">Tekst, mille piiratud pikkusega kokkuvõtet me saada soovime</param>
        /// <param name="maxPikkus">Kokkuvõtte pikkus</param>
        /// <returns>Lühendatud kokkuvõtte tekst</returns>
        private static string TagastaKokkuvõte(string lause, int maxPikkus)
        {
            // Kui lause on juba sobiva pikkusega (või lühem), siis tagastame originaali
            if (lause.Length <= maxPikkus)
            {
                return lause;
            }

            var sonad = lause.Split(' '); // Tükeldame teksti tühikute koha pealt laiali
            var tahtiKokku = 0;  // Loendur, mis arvutab hetkel kokku saanud tähtede arvu
            var kokkuvotteSonad = new List<string>(); // List, mis sisaldab sõnu, mis kokkuvõttesse mahuvad

            // Käime läbi kõik lauses sisalduvad sõnad
            foreach (string sona in sonad)
            {
                // Lisame sõna kokkuvõttesse ja suurendame kogunenud tähtede arvu sõna pikkuse võrra
                kokkuvotteSonad.Add(sona);
                tahtiKokku += sona.Length;

                // Kui tähti on kogunenud rohkem, kui soovitud pikkus oli, lõpetame lisamise
                if (tahtiKokku > maxPikkus)
                {
                    break;
                }
            }

            // Moodustame eraldi kokkuvõtte sõnadest taas ühe terviklause
            string kokkuvote = string.Join(" ", kokkuvotteSonad);

            return kokkuvote;
        }
    }
}
