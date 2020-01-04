using System.Collections.Generic;

namespace Encapsulation
{
    public class Klient
    {
        public int ID;
        public string Name;
        public readonly List<Tellimus> Tellimused; // Sisemine muutuja, mille välise tagant-järele muutmise keelame ära kasutades readonly võtmesõna

        // Vaikimisi ilma parameetriteta variant
        public Klient()
        {
            ID = 0;
            Name = string.Empty;
            Tellimused = new List<Tellimus>();
        }

        // Konstruktor, mis kasutab enda algväärtustamiseks ilma parmeetriteta konstruktorit
        public Klient(int id) : this()
        {
            ID = id;
        }

        // Konstruktor, mis oma algväärtustamiseks kasutab id-põhist variant, mis omakorda ilma parameetriteta varianti
        public Klient(int id, string name) : this(id)
        {
            Name = name;
        }
    }

}
