<Query Kind="Program" />

void Main()
{
	Ring ring = new Ring();
	Kujund kujund = ring;
	
	Ring ring2 = (Ring)kujund;

	//Ruut ruut = (Ruut)ring;
	//Ruut ruut2 = (Ruut)kujund;
	
	Type kujundiTüüp = kujund.GetType();
	if (kujundiTüüp == typeof(Ruut))
	{
		Console.WriteLine("ON ruut");
		Ruut ruut2 = (Ruut)kujund;
	}
	else
	{
		Console.WriteLine("Ei ole ruut");
	}
	
	if (kujund is Ruut)
	{
		Console.WriteLine("ON ruut");
		Ruut ruut2 = (Ruut)kujund;
	}
	else
	{
		Console.WriteLine("Ei ole ruut");
	}

	Ruut ruut3 = kujund as Ruut;
	
	int pikkus = ruut3?.KüljePikkus ?? 0;

	//int pikkus = (kujund as Ruut)?.KüljePikkus ?? 0;

	if (ruut3 != null)
	{
		Console.WriteLine("ON ruut");
	}
	else
	{
		Console.WriteLine("Ei ole ruut");
	}

	Ruut ruut4 = kujund as Ruut ?? new Ruut();
	
	
	Joonista(ring);
	Joonista(ruut4);
	Joonista(kujund);
	
	
}

public static void Joonista(Kujund kujund)
{
	kujund.Joonista();
}

// Define other methods and classes here
public abstract class Kujund
{
	public abstract void Joonista();
	//{
	//	Console.WriteLine("Kujund");
	//}
}

public class Ring : Kujund
{
	public override void Joonista()
	{
		//base.Joonista();
		Console.WriteLine("Ring");
	}

	public int Raadius { get; set; }
}

public class Ruut : Kujund
{
	public override void Joonista()
	{
		Console.WriteLine("Ruut");
	}

	public int KüljePikkus { get; set; }
}