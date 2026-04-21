public class FileLogger : ILogger
{
    private readonly string _path;

    public FileLogger(string path)
    {
        Directory.CreateDirectory("logs");
        _path = path;
    }

    public void Log(string message)
    {
        Write("INFO", message);
    }

    public void Error(string message)
    {
        Write("ERROR", message);
    }

    private void Write(string level, string message)
    {
        var line = $"[{DateTime.Now}] [{level}] {message}";
        File.AppendAllText(_path, line + Environment.NewLine);
    }
}