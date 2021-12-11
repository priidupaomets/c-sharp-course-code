<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
</Query>

void Main()
{
	List<Kujund> kujundid = new List<Kujund>();
	kujundid.Add(new Kujund() { Tüüp = KujundiTüüp.Ring });
	kujundid.Add(new Kujund() { Tüüp = KujundiTüüp.Ruut });

	var lõuend = new Lõuend();
	lõuend.Joonista(kujundid);
}

// Define other methods and classes here
public enum KujundiTüüp { Ring, Ruut, Tekst, Pilt, Kolmnurk };

public class Kujund
{
	public KujundiTüüp Tüüp { get; set; }
	public Point Asukoht { get; set; }
	public int Laius { get; set; }
	public int Kõrgus { get; set; }
}

public class Lõuend
{
	public void Joonista(List<Kujund> kujundid)
	{
		foreach (var kujund in kujundid)
		{
			switch (kujund.Tüüp)
			{
				case KujundiTüüp.Ring:
					// joonista ring
					break;
				case KujundiTüüp.Ruut:
					// joonista ruut
					break;
				case KujundiTüüp.Tekst:
					// joonista tekst
					break;
				case KujundiTüüp.Pilt:
					// joonista pilt
					break;
				case KujundiTüüp.Kolmnurk:
					// joonista kolmnurk
					break;
			}
		}
	}
}


//public class Ring : Kujund
//{
//	public override void Joonista()
//	{
//		//base.Joonista();
//		Console.WriteLine("Ring");
//	}
//
//	public int Raadius { get; set; }
//}
//
//public class Ruut : Kujund
//{
//	public override void Joonista()
//	{
//		Console.WriteLine("Ruut");
//	}
//
//	public int KüljePikkus { get; set; }
}