<Query Kind="Program" />

void Main()
{
	string lause = "See on väga väga väga väga väga väga väga pikk lause, mis tavaliselt ei mahu korraga kuhugi ära";
	const int maxPikkus = 19;

	Console.WriteLine("Kokkuvõte:");

	//string kokkuvote = Summarize(lause, maxPikkus);
	string kokkuvote = lause.Summarize(maxPikkus);
	Console.WriteLine(kokkuvote);
}

public static class StringExtensions
{
	// Define other methods and classes here
	public static string Summarize(this string lause, int maxPikkus = 20)
	{
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

			return kokkuvote;
		}
		else // kogu lause mahub ära
		{
			return lause;
		}
	}
}
