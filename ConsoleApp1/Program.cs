using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
        struct RGBColor
        {
            public int Red;
            public int Green;
            public int Blue;
        }

        static void Main(string[] args)
        {
            string[] numbrid = new string[3];
            numbrid[0] = "ä";
            numbrid[1] = "b";

            Console.WriteLine($"{numbrid[0]} {numbrid[1]} {numbrid[2]}");


            //var rgb = new RGBColor();
            //rgb.Red = 12;
            //rgb.Green = 33;
            //rgb.Blue = 87;

            //var summa = Kalkulaator.Liida(1, 3);
            //var summa2 = Kalkulaator.Liida(1.3f, 3.2f);

            //var kalk = new Kalkulaator();

            #region Test 1

            //int number = 1;
            //float hind = 5.65f;
            //char täht = 'ä';
            //string tekst = "See on mingi pikem tekst";
            //bool tõdeVõiMitte = true; // false

            //Console.WriteLine("{0} {1} {2} {3} {4}", number, hind, täht, tekst, tõdeVõiMitte);

            //try
            //{
            //    checked
            //    {
            //        int number = 10;
            //        byte arv = 255;
            //        //arv = (byte)(arv + 1);

            //        string s = "123a";

            //        //number = arv;
            //        // arv = number; // ei tööta
            //        //arv = (byte)number;
            //        //arv = Convert.ToByte(s);
            //        arv = byte.Parse(s);

            //        if (!byte.TryParse(s, out arv))
            //        {
            //            arv = 0;
            //        }

            //        Console.WriteLine($"Uus arv on {arv}, {number}");
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Tehe ebaõnnestus: {e.Message}");
            //}

            //int a = 0;
            //{
            //    int b = 1;
            //    {
            //        int c = 2;
            //    }
            //    {
            //        int c = 3;
            //    }
            //}

            #endregion

            //int a1 = 1, a2 = 1;
            //int b1 = a1++;
            //int b2 = ++a2;

            //Console.WriteLine($"B: {b1} {b2}");
            //Console.WriteLine($"A: {a1} {a2}");

            //Console.WriteLine("Tere tulemast Prog 3 kursusele");
            string sisend = Console.ReadLine();
            Console.WriteLine("Sa sisestasid: " + sisend);

        }
    }
}
