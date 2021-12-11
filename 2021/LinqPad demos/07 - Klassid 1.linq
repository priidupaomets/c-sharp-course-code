<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>


class Program
{
	static void Main(string[] args)
	{
		//var console = new Console();
		
		Console.WriteLine("Hello World!");
		
		var madis = new Inimene(); // Loome inimese tüüpi objekti
		madis.Nimi = "Madis";
		
		madis.Tutvusta();
		
		var c = Kalkulaator.Liida(3, 7);
		var f = Kalkulaator.Liida(3.1f, 6.9f);
		
		c.Dump();
	}
}

// 1. Kapseldamine
// 2. Polümorfism
// 3. 

// Define other methods and classes here
class Inimene
{
	public string Nimi; // Muutuja
	
	public void Tutvusta() // Meetod
	{
		Console.WriteLine("Tere, mina olen " + Nimi);
	}
}

class Kalkulaator
{
	public static int Liida(int a, int b)
	{
		return a + b;
	}

	public static float Liida(float a, float b)
	{
		return a + b;
	}
}