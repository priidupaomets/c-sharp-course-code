namespace Encapsulation
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        private Singleton() { }

        public string Name;

        public static Singleton Instance
        {
            get { return instance; }
        }
    }
}
