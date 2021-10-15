<Query Kind="Program" />

void Main()
{
	var calc = new Kalkulaator();

	var tulemus = calc.Add(5, 3);
	var tulemus2 = calc.Add(5, 3, 7);
	
	calc.Add(new[] { 1, 2, 3, 4, 5, 6});
}

// Define other methods and classes here
public class Kalkulaator
{
	////public int Add(int n1, int n2) { return n1 + n2; }
	//public int Add(int n1, int n2) => n1 + n2;
	//
	//public float Add(float n1, float n2) { return n1 + n2; }
	//public int Add(int n1, int n2, int n3) { return n1 + n2 + n3; }
	//public int Add(int n1, int n2, int n3, int n4) { return n1 + n2 + n3 + n4; }
	
	public int Add(params int[] numbrid) 
	{
		int sum = default;
		
		foreach (int num in numbrid)
		{
			sum += num;
		}
		
		return sum;
	}
}