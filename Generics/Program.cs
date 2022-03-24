using Generics;

var path = "C:/Users/urc0m/source/repos/c#/bars/GenericsAndCollections/Generics/log.txt";

var intLogger = new LocalFileLogger<int>(path);
var stringLogger = new LocalFileLogger<string>(path);

try
{
	intLogger.LogInfo("First int log");
	intLogger.LogWarning("Int warning");
	intLogger.LogError("Int error", new Exception("Int logging exception"));

	stringLogger.LogInfo("First string log");
	stringLogger.LogWarning("String warning");
	stringLogger.LogError("String error", new Exception("String logging exception"));
}
catch (Exception ex)
{
	Console.WriteLine($"Ошибка: {ex.Message}");
}