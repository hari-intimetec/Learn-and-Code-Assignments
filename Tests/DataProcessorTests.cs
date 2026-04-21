[TestClass]
public class DataProcessorTests
{
    [TestMethod]
    public void Process_CallsAllDependencies()
    {
        var reader = new FakeReader();
        var parser = new FakeParser();
        var validator = new FakeValidator();
        var transformer = new FakeTransformer();
        var writer = new FakeWriter();
        var logger = new FakeLogger();

        var processor = new DataProcessor(
            reader, parser, validator, transformer, writer, logger);

        processor.Process("input.csv", "output.csv");

        Assert.IsTrue(writer.WasCalled);
    }
}