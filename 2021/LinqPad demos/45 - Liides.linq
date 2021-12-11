<Query Kind="Program" />

void Main()
{
	List<Kujund> kujundid = new List<Kujund>();
	kujundid.Add(new Ring());
	kujundid.Add(new Ruut());
	kujundid.Add(new Kolmnurk());

	foreach (var k in kujundid)
	{
		k.Joonista();
	}
	
	
	List<IJoonistav> joonistatavad = new List<IJoonistav>();

	joonistatavad.Add(new Ring());
	joonistatavad.Add(new Ruut());
	joonistatavad.Add(new Kolmnurk());

	foreach (var k in kujundid)
	{
		k.Joonista();
	}

}

// Define other methods and classes here
public abstract class Kujund
{
	public abstract void Joonista();
	//{
	//	Console.WriteLine("Kujund");
	//}
}

public interface IJoonistav
{
	void Joonista();
}

public class Ellips : IJoonistav // Kujund
{
	public void Joonista()
	{
		//base.Joonista();
		Console.WriteLine("Ellips");
	}

	public int Laius { get; set; }
	public int Kõrgus { get; set; }
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

public class Ruut : Kujund, IJoonistav
{
	public override void Joonista()
	{
		Console.WriteLine("Ruut");
	}

	public int KüljePikkus { get; set; }
}

public class Kolmnurk : Kujund, IJoonistav
{
	public override void Joonista()
	{
		Console.WriteLine("Kolmnurk");
	}

	public int Kaatet { get; set; }
}