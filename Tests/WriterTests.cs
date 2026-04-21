[TestClass]
public class WriterTests
{
    private readonly CsvDataWriter _writer = new CsvDataWriter();

    [TestMethod]
    public void Write_CreatesFile()
    {
        var path = "test_output.csv";

        var records = new List<Record>
        {
            new Record { Id = "1", Name = "A", Value = 10 }
        };

        _writer.Write(path, records);

        Assert.IsTrue(File.Exists(path));
    }
}