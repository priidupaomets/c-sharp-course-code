<Query Kind="Program" />

void Main()
{
	var kl = new Test();
	kl.X = 3;
	
	kl.Dump();
	
	Muuda(kl);
	
	kl.Dump();
}

// Define other methods and classes here
void Muuda(Test klass)
{
	klass.X = 7;	
}

class Test 
{
	public int X { get; set; }
}