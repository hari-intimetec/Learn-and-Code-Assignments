public class CsvParser : IDataParser
{
    public List<Record> Parse(List<string> lines)
    {
        var records = new List<Record>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');

            if (parts.Length < 3) continue;

            records.Add(new Record
            {
                Id = parts[0],
                Name = parts[1],
                Value = double.TryParse(parts[2], out var v) ? v : 0,
                Date = parts.Length > 3 && DateTime.TryParse(parts[3], out var d) ? d : null
            });
        }

        return records;
    }
}