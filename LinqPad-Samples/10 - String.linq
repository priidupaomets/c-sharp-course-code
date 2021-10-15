<Query Kind="Program" />

void Main()
{
	string tekst = "Tekstijada";
	
	char ch1 = tekst[0];
	char ch2 = tekst[1];
	
	string eesnimi = "Nipi", perekonnanimi = "Tiri";
	
	string täisnimi1 = eesnimi + " " + perekonnanimi;
	string täisnimi2 = string.Format("{0} {1}", eesnimi, perekonnanimi);
	string täisnimi3 = $"{eesnimi} {perekonnanimi}";
	
	StringBuilder sb = new StringBuilder();
	sb.Append(eesnimi);
	sb.Append(" ");
	sb.Append(perekonnanimi);
	
	string täisnimi4 = sb.ToString();
}

// Define other methods and classes here
