<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
</Query>

void Main()
{
	StreamWriter writer = new StreamWriter(@"C:\Test", true);
	try
	{
		writer.WriteLine("TEADE : TERE");
	}
	finally
	{
		writer.Dispose();
	}

	using (StreamWriter writer2 = new StreamWriter(@"C:\Test", true))
	{
		writer2.WriteLine("TEADE : TERE");
	}

	using (var disp = new MyDisposable())
	{
		//disp.Pilt;
	}
}

// Define other methods and classes here
public class MyDisposable : IDisposable
{
	private bool disposed = false;
	private Bitmap pilt;
	
	public MyDisposable()
	{
		pilt = new System.Drawing.Bitmap(@"C:\Temp\...jpg");
		//GC.AddMemoryPressure(130);
	}
	
	~MyDisposable()
	{
		Dispose(false);
	}
	
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	
	private void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (pilt != null)
			{
				//GC.RemoveMemoryPressure(130);
				pilt.Dispose();
				pilt = null;
				disposed = true;
			}
		}
	}
}