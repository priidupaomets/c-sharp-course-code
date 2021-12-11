<Query Kind="Program" />

void Main()
{
	int[] numbrid = new int[3];
	
	numbrid[0] = 1;
	numbrid[1] = 2;
	
	var x = numbrid[0];
	
	numbrid.Dump();

	Console.WriteLine($"Default int {default(int)}, float={default(float)}, string={default(string)}");

	int[] num2 = new int[] { 1, 7, 8, 4, 2 };
	num2.Dump();
}

// Define other methods and classes here
