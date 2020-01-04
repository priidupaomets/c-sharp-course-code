using System;
using System.Drawing;

namespace InheritanceAndComposition
{
    public abstract class GraphicsObject
    {
        public Point Location { get; set; }
        public Size Size { get; set; }

        // Kõik graafilised objektid peavad oskama end joonistada
        public abstract void Draw();
    }

    public class Text : GraphicsObject
    {
        public string Title { get; set; }

        // Kirjutame iga konkreetse klassi juures joonistamise meetodi üle
        public override void Draw()
        {
            Console.WriteLine($"Joonista: TEXT \"{Title}\", ");
        }
    }

    public class Picture : GraphicsObject
    {
        public string Url { get; set; }

        public override void Draw()
        {
            Console.WriteLine($"Joonista: PILT \"{Url}\", ");
        }
    }

    public class Rectangle : GraphicsObject
    {
        public override void Draw()
        {
            Console.WriteLine($"Joonista: RISTKÜLIK ");
        }

    }
}
