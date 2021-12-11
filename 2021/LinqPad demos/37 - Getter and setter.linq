<Query Kind="Program" />

void Main()
{
	var klient = new Klient(1, "Nipi Tiri");

	var tellimus = new Tellimus();
	//klient.Tellimused = new List<UserQuery.Tellimus>();
	klient.Tellimused.Add(tellimus);
	
	//klient.GetNimi();
	//klient.SetNimi("Uus nimi");
	
	var nimi = klient.Nimi;
	klient.Nimi = "Uus nimi";
}

// Define other methods and classes here
public class Klient
{
	public int ID;
	private string _nimi;
	
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

	public Klient(int id, string nimi) : this(id)
	{
		//ID = id;
		_nimi = nimi;
		//Tellimused = new List<UserQuery.Tellimus>();
	}

//	public string GetNimi()
//	{
//		return _nimi;
//	}
//
//	public void SetNimi(string value)
//	{
//		if (!string.IsNullOrEmpty(value))
//			_nimi = value;
//	}

	public string Nimi
	{
		get { return _nimi; }
		private set
		{
			if (!string.IsNullOrEmpty(value))
				_nimi = value;
		}
	}

	public DateTime Synnipaev { get; set; }
	
	public int Vanus
	{
		get 
		{
			var timespan = DateTime.Today - Synnipaev;
			
			return timespan.Days / 365;
		}
	}
}

public class Tellimus
{

}


