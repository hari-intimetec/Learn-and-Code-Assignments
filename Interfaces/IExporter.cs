public interface IExporter
{
    void Export(string path, List<Record> records);
}