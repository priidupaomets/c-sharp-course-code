using System;
using System.Collections.Generic;

namespace Encapsulation
{
    public class Klient2
    {
        private int _id;
        private string _name;
        private List<Tellimus> _tellimused;
        //private DateTime _birthday;  // Kui me ise muutuja ja property defineerime. Auto-genereeritu puhul pole seda vaja

        // Vaikimisi ilma parameetriteta variant
        public Klient2()
        {
            _id = 0;
            _name = string.Empty;
            _tellimused = new List<Tellimus>();
        }

        // Konstruktor, mis kasutab enda algväärtustamiseks ilma parmeetriteta konstruktorit
        public Klient2(int id) : this()
        {
            _id = id;
        }

        // Konstruktor, mis oma algväärtustamiseks kasutab id-põhist variant, mis omakorda ilma parameetriteta varianti
        public Klient2(int id, string name) : this(id)
        {
            _name = name;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        // Property, mis pöördub ose sisemise muutuja poole
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Ainult loetav list, mida väljaspoolt üle kirjuatda ei saa
        public List<Tellimus> Tellimused
        {
            get { return _tellimused; }
        }

        // // Käsitsi loomise puhul on vaja property defineerida nii
        //public DateTime Birthday
        //{
        //    get { return _birthday; }
        //    protected set { _birthday = value; }
        //}

        // Auto-genereeritud property, mis loob ka taustal vajaliku sisemise muutuja
        public DateTime Birthday { get; protected set; }

        // Ainult loetav property, mis arvutab vanuse hetkeseisu põhjal (sarnane SQL kalkuleeritud tabeli veergudele)
        public int Age
        {
            get
            {
                var timespan = DateTime.Today - Birthday;

                return timespan.Days / 365;
            }
        }
    }
}
