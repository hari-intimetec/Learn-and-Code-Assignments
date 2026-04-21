public class DataValidator : IDataValidator
{
    public List<Record> Validate(List<Record> records)
    {
        return records
            .Where(record => !string.IsNullOrEmpty(record.Id)
                     && !string.IsNullOrEmpty(record.Name))
            .ToList();
    }
}