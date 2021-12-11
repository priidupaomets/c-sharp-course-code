<Query Kind="Program" />

void Main()
{
	Person person = new Person("Nimi Tiri");
	//person.Nimi = "Nipi Tiri";

	Person person2 = Person.Parse("{ name: 'Nipi Tiri', birthday: '2000-01-01' }");

    //Console.WriteLine();

	person.Tutvusta();
	
	//int.Parse("72");
}

public class Person
{
	private string Nimi; // = "Puudub";  // Field

	public Person()
	{
		//Nimi = "_määramata_";
	}
	
	//public Person(string nimi)
	//{
	//	Nimi = nimi;
	//}

	public void Tutvusta()
	{
		Console.WriteLine($"Tere, mina olen {Nimi}");
	}
	
	public static Person Parse(string value)
	{
		Person person = new Person(value);
		//person.Nimi = value;
		
		return person;
	}
}
