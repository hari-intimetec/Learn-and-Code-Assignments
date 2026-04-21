class Program
{
    static void Main()
    {
        var logger = new FileLogger("logs/log.txt");

        var processor = new DataProcessor(
            new FileDataReader(),
            new CsvParser(),
            new DataValidator(),
            new DataTransformer(),
            new CsvDataWriter(),
            logger
        );

        processor.Process("input.csv", "output.csv");

        Console.WriteLine("Done");
    }
}