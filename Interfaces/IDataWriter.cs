public interface IDataWriter
{
    void Write(string path, List<Record> records);
}