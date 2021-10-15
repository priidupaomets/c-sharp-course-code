<Query Kind="Program" />

void Main()
{
	var klient = new Klient(1, "Nipi Tiri");
	//klient.ID;
	var klient2 = new Klient();
	klient2.ID = 12;
	klient2.Nimi = "";

	// Objekti initsialiseerimine
	var klient3 = new Klient()
	{
		ID = 3, 
		Nimi = "Madis"
	};

	var tellimus = new Tellimus();
	//klient.Tellimused = new List<UserQuery.Tellimus>();
	klient.Tellimused.Add(tellimus);
}

// Define other methods and classes here
public class Klient
{
	public int ID;
	public string Nimi;
	public readonly List<Tellimus> Tellimused; // = new List<UserQuery.Tellimus>();
	
	public Klient()
	{
		Tellimused = new List<UserQuery.Tellimus>();
	}
	
	public Klient(int id) : this()
	{
		this.ID = id;
		//Tellimused = new List<UserQuery.Tellimus>();
	}

	public Klient(int id, string nimi): this(id)
	{
		//ID = id;
		Nimi = nimi;
		//Tellimused = new List<UserQuery.Tellimus>();
	}
}

public class Tellimus
{
	
}