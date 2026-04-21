class FakeReader : IDataReader
{
    public List<string> Read(string path)
        => new List<string> { "1,Item1,100" };
}

class FakeParser : IDataParser
{
    public List<Record> Parse(List<string> lines)
        => new List<Record> { new Record { Id = "1", Name = "A" } };
}

class FakeValidator : IDataValidator
{
    public List<Record> Validate(List<Record> records) => records;
}

class FakeTransformer : IDataTransformer
{
    public void Transform(List<Record> records) { }
}

class FakeWriter : IDataWriter
{
    public bool WasCalled = false;

    public void Write(string path, List<Record> records)
    {
        WasCalled = true;
    }
}

class FakeLogger : ILogger
{
    public void Log(string message) { }
    public void Error(string message) { }
}