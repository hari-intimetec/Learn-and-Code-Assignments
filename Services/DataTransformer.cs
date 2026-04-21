public class DataTransformer : IDataTransformer
{
    public void Transform(List<Record> records)
    {
        foreach (var record in records)
        {
            record.Name = record.Name.ToUpper();
        }
    }
}