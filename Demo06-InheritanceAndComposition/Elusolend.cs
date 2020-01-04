using System;

namespace InheritanceAndComposition
{
    // Liidesed erinevate omaduste kirjeldamiseks
    public interface ISööv
    {
        void Söö();
    }

    public interface IMagav
    {
        void Maga();
    }

    public interface IKõndiv
    {
        void Kõnni();
    }

    public interface IUjuv
    {
        void Uju();
    }

    // Baasklass muude elusolendite jaoks, et me saaks neist listi moodustada
    public class Elusolend
    {

    }

    // Inimesele anname oskuse süüa, magada ja kõndida
    public class Inimene : Elusolend, ISööv, IMagav, IKõndiv
    {
        public void Kõnni()
        {
            Console.WriteLine("Inimene : Kõnni");
        }

        public void Maga()
        {
            Console.WriteLine("Inimene : Maga");
        }

        public void Söö()
        {
            Console.WriteLine("Inimene : Söö");
        }
    }

    // Pardile anname võimaluse süüa, magada ja ujuda
    public class Part : Elusolend, ISööv, IMagav, IUjuv
    {
        public void Uju()
        {
            Console.WriteLine("Part : Uju");
        }

        public void Maga()
        {
            Console.WriteLine("Part : Maga");
        }

        public void Söö()
        {
            Console.WriteLine("Part : Söö");
        }
    }
}
