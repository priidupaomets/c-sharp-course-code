<Query Kind="Program" />

void Main()
{
	var color1 = new RGBColor();
	color1.Red = 255;
	color1.Green = 123;
	color1.Blue = 12;
	
	color1.Dump();
	Recolor(ref color1);
	color1.Dump();
}

// Define other methods and classes here
void Recolor(ref RGBColor color)
{
	color.Red = 75;	
	
	color.Dump();
}

public struct RGBColor
{
	//public byte Alpha;
	public byte Red;
	public byte Green;
	public byte Blue;
}