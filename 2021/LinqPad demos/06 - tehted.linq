<Query Kind="Program" />

void Main()
{
//	var a = 10;
//	var b = 3;
//
//	// Täisarvulised tulemused
//	Console.WriteLine($"{a + b} {a - b} {a * b} {a / b} {a % b }");
//
//	// Täpne jagamine
//	Console.WriteLine($"{a + b} {a - b} {a * b} {(float)a / (float)b} {a % b }");
//	
//	// Increment ja Decrement
//	int a1 = 1, a2 = 1;
//	
//	int b1 = a1++;
//	int b2 = ++a2;
//
//	Console.WriteLine($"a1={a1} a2={a2} b1={b1} b2={b2}");
	int a1 = 0;
	
	a1 = a1 + 1;
	a1 = a1++;
	
	a1 += 1;
	
	
	int a = 3;
	int b = 7;
	
	var c = a == b || a < b;
	
	// c = !c;
	
	c.Dump();
	
	// Biti-tehted
	int d = 0b0000_0101; // 5
	int e = 0b0000_0011; // 3
						 // -----------------------
						 // AND    0000_0001; // 1
						 // OR     0000_0111; // 7
						 // XOR    0000_0110; // 6

	Console.WriteLine($"{ d & e:x} {d | e:x} {d ^ e}");
}

// Define other methods and classes here
