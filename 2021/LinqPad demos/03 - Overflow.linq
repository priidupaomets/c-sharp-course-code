<Query Kind="Program" />

void Main()
{
	byte x = 0;

	//// Ei luba teha, kuna 259 ei mahu baidi sisse
	//x = 255;
	//x = x + 4;

	//// Ei anna viga, kuid annab vale tulemuse (3)
	//x = 255;
	//x = (byte)(x + 4);

	//// Lubab konversiooni, kuid viga tekib programmi jooksmise ajal
	//checked
	//{
	//	x = 255;
	//	x = (byte)(x + 4);
	//}

	try
	{
		checked
		{
			x = 255;
			x = (byte)(x + 4);
		}
	}
	catch(ArithmeticException ex)
	{
		Console.WriteLine("Juhtus viga " + ex.Message);
	}
	
	x.Dump();
}

// Define other methods and classes here
void Muuda(Test klass)
{
	klass.X = 7;
	
}
