[TestClass]
public class ParserTests
{
    private readonly CsvParser _parser = new CsvParser();

    [TestMethod]
    public void Parse_ValidLines_ReturnsRecords()
    {
        var lines = new List<string>
        {
            "1,Item1,100,2024-01-01",
            "2,Item2,200,2024-01-02"
        };

        var result = _parser.Parse(lines);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Item1", result[0].Name);
    }

    [TestMethod]
    public void Parse_InvalidLine_SkipsLine()
    {
        var lines = new List<string>
        {
            "invalid_line"
        };

        var result = _parser.Parse(lines);

        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void Parse_InvalidValue_SetsZero()
    {
        var lines = new List<string>
        {
            "1,Item1,abc"
        };

        var result = _parser.Parse(lines);

        Assert.AreEqual(0, result[0].Value);
    }
}