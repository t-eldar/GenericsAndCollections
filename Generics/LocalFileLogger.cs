namespace Generics;
public class LocalFileLogger<T> : ILogger
{
	private string _path;
	public LocalFileLogger(string path)
	{
		_path = path; 
	}
	public void LogInfo(string message)
	{
		using var streamWriter = new StreamWriter(_path, true);
		streamWriter.WriteLine($"[Info]: [{typeof(T).Name}] : {message}");
	}

	public void LogWarning(string message)
	{
		using var streamWriter = new StreamWriter(_path, true);
		streamWriter.WriteLine($"[Warning] : [{typeof(T).Name}] : {message}");
	}

	public void LogError(string message, Exception ex)
	{
		using var streamWriter = new StreamWriter(_path, true);
		streamWriter.WriteLine($"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}");
	}
}