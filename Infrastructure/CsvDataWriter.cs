public class CsvDataWriter : IDataWriter
{
    public void Write(string path, List<Record> records)
    {
        var lines = new List<string>
        {
            "ID,NAME,VALUE,DATE,DOUBLED,SQUARED"
        };

        lines.AddRange(records.Select(r =>
            $"{r.Id},{r.Name},{r.Value},{r.Date},{r.DoubledValue},{r.SquaredValue}"
        ));

        File.WriteAllLines(path, lines);
    }
}