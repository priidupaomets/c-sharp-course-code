using System;

namespace InheritanceAndComposition
{
    public interface ILogger
    {
        void Log(string text);

        void Error(string text);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }

        public void Error(string text)
        {
            Console.WriteLine("ERROR: " + text);
        }
    }


}
