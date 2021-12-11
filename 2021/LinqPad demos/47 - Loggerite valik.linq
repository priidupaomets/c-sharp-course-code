<Query Kind="Program" />

void Main()
{
	var logger = new AggregateLogger();
	logger.Add(new ConsoleLogger());
	logger.Add(new FileLogger());

	var installer = new Installer(logger);
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

public class FileLogger : ILogger
{
	public void Log(string text)
	{
		//Console.WriteLine(text);
	}
}

public class AggregateLogger : ILogger
{
	private List<ILogger> _loggers = new List<UserQuery.ILogger>();

	public void Add(ILogger logger)
	{
		_loggers.Add(logger);
	}

	public void Log(string text)
	{
		foreach (var logger in _loggers)
		{
			logger.Log(text);
		}
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