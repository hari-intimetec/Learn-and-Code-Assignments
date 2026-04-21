public class JsonExporter : IExporter
{
    public void Export(string path, List<Record> records)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(records);
        File.WriteAllText(path, json);
    }
}