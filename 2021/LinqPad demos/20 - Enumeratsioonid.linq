<Query Kind="Program" />

void Main()
{
	var array1 = new int[] {1, 2, 3, 4};
	
	PrintItems(array1);

	var array2 = new List<int>() { 1, 2, 3, 4 };

	PrintItems(array2);

	var array3 = new string[] { "1", "2", "3", "4" };

	PrintItems<string>(array3);

}

// Define other methods and classes here
public void PrintItems<T>(IEnumerable<T> values)
{
	//IEnumerator enumerator = values.GetEnumerator();
	//while (enumerator.MoveNext())
	//{
	//	Console.WriteLine(enumerator.Current);
	//}

	foreach (var item in values)
	{
		Console.WriteLine(item);
	}
}