<Query Kind="Program" />

void Main()
{
	var cookie = new HttpCookie();
	
	cookie["Nimi"] = "Väärtus";
	//cookie[2] = "Uus asi";
}

// Define other methods and classes here
public class HttpCookie
{
	private readonly Dictionary<string, string> _dict = new Dictionary<string, string>();

	public DateTime Expiry { get; set; }

	//public string this[int key]
	//{
	//	get { return _dict[key]; }
	//	set { _dict[key] = value; }
	//}
	
	public string this[string key]
	{
		get { return _dict[key]; }
		set { _dict[key] = value; }
	}
}
