<Query Kind="Program" />

void Main()
{
	string tekst = "7";
	
	int i = 0; //int.Parse(tekst);
	
	if (!int.TryParse(tekst, out i))
	{
		Console.WriteLine("Ei saanud parsida");
	}
	else
	{
		Console.WriteLine($"Parsitud arv: {i}"); 
	}
}

// Define other methods and classes here
