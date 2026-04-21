public interface IDataParser
{
    List<Record> Parse(List<string> lines);
}