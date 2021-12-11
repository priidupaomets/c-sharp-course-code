<Query Kind="Program" />

void Main()
{
	var installer = new Installer(new ConsoleLogger());
}

// Define other methods and classes here
public class Logger : ILogger
{
	public void Log(string text)
	{
		//throw new NotImplementedException();
	}
}

public class ConsoleLogger : ILogger
{
	public void Log(string text)
	{
		Console.WriteLine(text);
	}
}

public interface ILogger
{
	void Log(string text);
}

public class Installer
{
	private ILogger _logger;

	public Installer(ILogger logger)
	{
		_logger = logger;
	}

	public void Install()
	{
		// ...
		_logger.Log("Valmis");
	}
}