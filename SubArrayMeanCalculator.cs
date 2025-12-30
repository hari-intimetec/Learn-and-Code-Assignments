class Program
{
    static void Main(string[] args)
    {
        int[] input = ReadIntArray();
        int numberOfElements = input[0];
        int numberOfQueries = input[1];

        long[] arrayElements = ReadLongArray();
        long[] prefixSum = BuildPrefixSum(arrayElements);

        ProcessQueries(numberOfQueries, prefixSum);
    }

    private static int[] ReadIntArray()
    {
        return Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
    }

    private static long[] ReadLongArray()
    {
        return Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
    }

    private static long[] BuildPrefixSum(long[] elements)
    {
        int length = elements.Length;
        long[] prefixSum = new long[length + 1];

        for (int iterator = 1; iterator <= length; iterator++)
        {
            prefixSum[iterator] = prefixSum[iterator - 1] + elements[iterator - 1];
        }

        return prefixSum;
    }

    private static void ProcessQueries(int numberOfQueries, long[] prefixSum)
    {
        for (int iterator = 0; iterator < numberOfQueries; iterator++)
        {
            int[] queryIndices = ReadIntArray();

            int leftIndex = queryIndices[0];
            int rightIndex = queryIndices[1];

            long subarraySum = GetSubarraySum(prefixSum, leftIndex, rightIndex);
            int subarrayLength = rightIndex - leftIndex + 1;

            long meanFloor = subarraySum / subarrayLength;
            Console.WriteLine(meanFloor);
        }
    }

    private static long GetSubarraySum(long[] prefixSum, int leftIndex, int rightIndex)
    {
        return prefixSum[rightIndex] - prefixSum[leftIndex - 1];
    }
}
