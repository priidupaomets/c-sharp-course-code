<Query Kind="Program" />

void Main()
{
	StreamReader reader1 = new StreamReader(new MemoryStream());
	StreamReader reader2 = new StreamReader(new FileStream(@"C:\Temp\fail.txt", FileMode.Open));
}

// Define other methods and classes here
