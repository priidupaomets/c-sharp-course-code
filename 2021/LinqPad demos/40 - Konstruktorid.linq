<Query Kind="Program" />

void Main()
{
	//var auto1 = new Sõiduk("123ABC");
	////auto1.RegistriNumber = "123ABC";
	//var number = auto1.RegistriNumber;
	
	var auto2 = new Veoauto("653HJH", 2);
	//auto2.TelgedeArv = 1;
}

// Define other methods and classes here
public class Sõiduk
{
	private string _registriNumber;
	
	public Sõiduk(string regNo)
	{
		_registriNumber = regNo;
		Console.WriteLine("Sõiduk");
	}
	
	public string RegistriNumber
	{
		get { return _registriNumber; }
	}
}

public class Veoauto : Sõiduk
{
	public Veoauto(string regNo)
		: base(regNo)
	{
		//_registriNumber = regNo;
		TelgedeArv = 2;
		Console.WriteLine("Veoauto");
	}

	public Veoauto(string regNo, int telgedeArv) 
		: this(regNo)
	{
		TelgedeArv = telgedeArv;
		Console.WriteLine("Veoauto 2");
	}
	
	public int TelgedeArv { get; private set; }
}