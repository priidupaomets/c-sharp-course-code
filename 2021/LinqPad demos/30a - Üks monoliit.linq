<Query Kind="Program" />

void Main()
{
	string lause = "See on väga väga väga väga väga väga väga pikk lause, mis tavaliselt ei mahu korraga kuhugi ära";
	const int maxPikkus = 19;
	
	Console.WriteLine("Kokkuvõte:");
	// Kui lause on pikem kui tohib
	if (lause.Length > maxPikkus)
	{
		var sonad = lause.Split(' ');
		var tahtiKokku = 0;
		var kokkuvotteSonad = new List<string>();
	
		foreach (string sona in sonad)
		{
			kokkuvotteSonad.Add(sona);
			tahtiKokku += sona.Length;
	
			if (tahtiKokku > maxPikkus)
			{
				break;
			}
		}
	
		string kokkuvote = string.Join(" ", kokkuvotteSonad);
	
		Console.WriteLine(kokkuvote);
	}
	else // kogu lause mahub ära
	{
		Console.WriteLine(lause);
	}
	
}

// Define other methods and classes here
