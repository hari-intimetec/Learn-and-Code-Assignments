[TestClass]
public class TransformerTests
{
    private readonly DataTransformer _transformer = new DataTransformer();

    [TestMethod]
    public void Transform_ConvertsNameToUpperCase()
    {
        var records = new List<Record>
        {
            new Record { Name = "item1" }
        };

        _transformer.Transform(records);

        Assert.AreEqual("ITEM1", records[0].Name);
    }

    [TestMethod]
    public void Transform_EmptyList_DoesNotThrow()
    {
        var records = new List<Record>();

        _transformer.Transform(records);

        Assert.AreEqual(0, records.Count);
    }
}