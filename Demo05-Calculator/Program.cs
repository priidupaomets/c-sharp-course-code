using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int tulemus;
            float fTulemus;

            var calc = new Calculator();

            #region Üle laetud funktsioonide kasutamine

            tulemus = calc.Add(1, 2);
            tulemus = calc.Add(1, 2, 3);
            tulemus = calc.Add(1, 2, 3, 4);
            fTulemus = calc.Add(7f, 2f);

            // Numbrite massiivi kasutamine nii massiivi, kui tavaliste parameetrite kaudu (kasutades params võtmesõna funktsiooni juures)
            // Märkus: kui meil juba on massiivi kujul variant, siis varasemaid 2-4 parameetriga variante tegelikult enam vaja ei olegi!
            tulemus = calc.Add(1, 2, 3, 4, 5);
            tulemus = calc.Add(1, 2, 3, 4, 5, 6, 7, 8, 98);
            tulemus = calc.Add(new int[] { 1, 2, 3, 4, 5 });

            #endregion

            #region Referentsväärtuse kasutamine, ehk muutuja, mille väärtust funktsiooni sees muudetakse

            tulemus = 2;

            Console.WriteLine($"Tulemus: {tulemus}");

            calc.Add(ref tulemus, 7);
            calc.Add(ref tulemus, 2);
            calc.Add(ref tulemus, 3);
            calc.Add(ref tulemus, 4);
            calc.Add(ref tulemus, 5);

            Console.WriteLine($"Tulemus: {tulemus}");

            #endregion

            #region Mitme väärtuse tagastamine

            var numbers = new int[] { 1, 2, 3, 4, 5 };
            int min = 0, max = 0, avg = 0;

            // Kasutades OUT parameetreid
            calc.CalculateMinMaxAvg(numbers, out min, out max, out avg);

            // Tagastades arvud klassi kaudu
            Arvud x = calc.CalculateMinMaxAvgAsClass(numbers);

            min = x.Min;
            max = x.Max;
            avg = x.Avg;

            // Tagastades väärtused Tuple abil
            (min, max, avg) = calc.CalculateMinMaxAvgAsTuple(numbers);

            #endregion

            Console.ReadLine();
        }
    }


}
