namespace DivisorLib
{
    public static class DivisorCounter
    {
        public static int GetDivisorCount(int number)
        {
            int divisorCount = 0;

            for (int potentialDivisor = 1; potentialDivisor * potentialDivisor <= number; potentialDivisor++)
            {
                if (number % potentialDivisor == 0)
                {
                    if (potentialDivisor * potentialDivisor == number)
                        divisorCount += 1;
                    else
                        divisorCount += 2;
                }
            }

            return divisorCount;
        }

        public static int CountNumbersWithEqualAdjacentDivisors(int upperLimit)
        {
            if (upperLimit <= 2)
                return 0;

            int validCount = 0;

            int previousNumberDivisorCount = GetDivisorCount(2);

            for (int currentNumber = 3; currentNumber <= upperLimit; currentNumber++)
            {
                int currentNumberDivisorCount = GetDivisorCount(currentNumber);

                if (currentNumberDivisorCount == previousNumberDivisorCount)
                {
                    validCount++;
                }

                previousNumberDivisorCount = currentNumberDivisorCount;
            }

            return validCount;
        }
    }
}