public class FileDataReader : IDataReader
{
    public List<string> Read(string path)
    {
        return File.ReadAllLines(path).ToList();
    }
}