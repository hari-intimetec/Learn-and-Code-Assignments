[TestClass]
public class ExporterTests
{
    [TestMethod]
    public void JsonExporter_WritesFile()
    {
        var exporter = new JsonExporter();
        var path = "test.json";

        var records = new List<Record>
        {
            new Record { Id = "1", Name = "A", Value = 10 }
        };

        exporter.Export(path, records);

        Assert.IsTrue(File.Exists(path));
    }
}