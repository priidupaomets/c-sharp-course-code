<Query Kind="Program" />

static void Main(string[] args)
{
	var numbers = new List<int>() { 2, 1, 4, 3, 5, 6 };

	var vaikseimad = LeiaVaikseimad(numbers, 3);

	foreach (int num in vaikseimad)
	{
		Console.WriteLine(num);
	}
}

static List<int> LeiaVaikseimad(List<int> numbrid, int kogus)
{
	var pisimad = new List<int>();

	while (pisimad.Count < kogus)
	{
		var min = LeiaVaikseim(numbrid);
		pisimad.Add(min);
		numbrid.Remove(min);
	}

	return pisimad;
}

static int LeiaVaikseim(List<int> numbrid)
{
	var min = numbrid[0];

	for (int i = 1; i < numbrid.Count; i++)
	{
		if (numbrid[i] < min)
			min = numbrid[i];
	}

	return min;
}
