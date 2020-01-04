using System;

namespace Encapsulation
{
    public class Person
    {
        // Klassi väli ehk klassi tasandil muutuja
        public string Nimi;

        // Kui me vähemalt ühe konstruktori ise loome, peame vajadusel kirjutama ka parameetriteta konstruktori
        public Person()
        {
            this.Nimi = "";
        }

        // Kui konstruktor privaatsena deklareerida, siis ei saa klassiväliselt sellest objekti luua. Antud juhul lahendab olukorra staatiline "Create" meetod
        private Person(string nimi)
        {
            this.Nimi = nimi;
        }

        // Klassi instantsi (objekti) tasemel kasutatav meetod (ehk klassist tuleb esmalt objekt luua)
        public void Tutvusta()
        {
            Console.WriteLine($"Tere, mina olen {Nimi}");
        }

        // Staatiline ehk klassi-tasandil meetod
        public static Person Create(string nimi)
        {
            Person person = new Person(nimi);
            return person;
        }
    }
}
