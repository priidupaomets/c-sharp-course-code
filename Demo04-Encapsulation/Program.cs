using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person;

            #region Avaliku konstruktoriga klassist instantsi loomine

            person = new Person();
            person.Nimi = "Nipi Tiri";
            person.Tutvusta();

            #endregion

            #region Privaatse konstruktori korral saame kasutada klassi staatilist funktsiooni

            //var dt = DateTime.Parse("2019-11-02");

            person = Person.Create("Nipi Tiri");
            person.Tutvusta();

            #endregion

            #region Singleton objekti kasutamine

            // Sellest klassist eksisteerib vaid üks instant ja sellele saab ligi läbi Singleton.Instance staatilise property
            var s = Singleton.Instance.Name;

            #endregion

            Klient klient;
            Klient2 klient2;

            #region Kliendi loomine ja algväärtustamine

            klient = new Klient(1, "Madis");
            //klient.Tellimused = new List<Tellimus>(); // Kui Teelimused on deklareeritud kui readonly, siis me seda omistust teha ei saa, muidu aga saaks ja see oleks halb

            // Klassi loomine kasutades intsialisaatori süntaksit, kuid sedasi ei saa garanteerida et vajalikud väljad saavad õiged algväärtused
            klient = new Klient() { ID = 2, Name = "Kati" };

            // Loome kliendi, mis kasutab peidab sisemised muutujad propertyte taha
            klient2 = new Klient2(1, "Madis");

            // Tellimusi saame lisada igal juhul, sõltumata sellest, kas see on defineeritud välja või property kujul
            var tellimus = new Tellimus();
            klient2.Tellimused.Add(tellimus);
            klient2.Tellimused.Add(new Tellimus());

            //// Sellist omistamiset me teha ei saa kuna Property on samuti read-only (ilma setter osata)
            //klient2.Tellimused = new List<Tellimus>();

            Console.ReadLine();

            #endregion
        }
    }
}
