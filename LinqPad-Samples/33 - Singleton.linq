<Query Kind="Program" />

void Main()
{
	//var con = new Console();
	
	Singleton.Instance.Print("Tekst");
}

public sealed class Singleton
{
	private static readonly Singleton instance = new Singleton();

	private Singleton() { }

	public void Print(string text)
	{
	}

	public static Singleton Instance
	{
		get
		{
			return instance;
		}
	}
}
