public class DataProcessor
{
    private readonly IDataReader _reader;
    private readonly IDataParser _parser;
    private readonly IDataValidator _validator;
    private readonly IDataTransformer _transformer;
    private readonly IDataWriter _writer;
    private readonly ILogger _logger;

    public DataProcessor(
        IDataReader reader,
        IDataParser parser,
        IDataValidator validator,
        IDataTransformer transformer,
        IDataWriter writer,
        ILogger logger)
    {
        _reader = reader;
        _parser = parser;
        _validator = validator;
        _transformer = transformer;
        _writer = writer;
        _logger = logger;
    }

    public void Process(string input, string output)
    {
        try
        {
            _logger.Log("Processing started");

            var lines = _reader.Read(input);
            var records = _parser.Parse(lines);

            records = _validator.Validate(records);
            _transformer.Transform(records);

            _writer.Write(output, records);

            _logger.Log($"Processed {records.Count} records");
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            throw;
        }
    }
}