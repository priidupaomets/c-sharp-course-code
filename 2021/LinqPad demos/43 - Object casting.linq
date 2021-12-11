<Query Kind="Program" />

void Main()
{
	Ring ring = new Ring();
	Kujund kujund = ring;
	Object obj = ring;

	Object objI = 7;
	
	Ring ring2 = (Ring)obj;
	
	//ArrayList alist = new ArrayList();
	//alist.Add(ring);
	//alist.Add(kujund);
	//alist.Add(objI);
	//alist.Add("Suvaline tekst");
	//
	//foreach (var item in alist)
	//{
	//	item.
	//}
	
	List<Kujund> kujundid = new List<Kujund>();
	kujundid.Add(ring);
	kujundid.Add(new Ruut());
	kujundid.Add(new Kolmnurk());
	
	foreach (var k in kujundid)
	{
		k.Joonista();
	}
}

// Define other methods and classes here

// Define other methods and classes here
public abstract class Kujund
{
	public abstract void Joonista();
	//{
	//	Console.WriteLine("Kujund");
	//}
}

public class Ellips: Kujund
{
	public override void Joonista()
	{
		//base.Joonista();
		Console.WriteLine("Ellips");
	}

	public int Laius { get; set; }
	public int Kõrgus { get; set; }
}


public class Ring : Ellips //Kujund
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

public class Kolmnurk : Kujund
{
	public override void Joonista()
	{
		Console.WriteLine("Kolmnurk");
	}

	public int Kaatet { get; set; }
}