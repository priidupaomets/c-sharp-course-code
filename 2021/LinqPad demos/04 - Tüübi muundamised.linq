<Query Kind="Program" />

void Main()
{
	byte number = 10;
	int arv = number;
	byte num2 = (byte)arv;
	
	byte num3 = Convert.ToByte(arv);
	
	string s = "1234";
	byte num4 = 0; //byte.Parse(s);
	
	if (!byte.TryParse(s, out num4))
	{
		Console.WriteLine("Ei saa konverteerida");
	}
}

// Define other methods and classes here
