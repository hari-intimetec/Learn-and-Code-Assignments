using Xunit;
using DivisorLib;

namespace DivisorTests
{
    public class DivisorCounterTests
    {
        [Fact]
        public void ShouldReturnTwoForInputFifteen()
        {
            int result = DivisorCounter.CountNumbersWithEqualAdjacentDivisors(15);
            Assert.Equal(2, result);
        }

        [Fact]
        public void ShouldReturnOneForInputThree()
        {
            int result = DivisorCounter.CountNumbersWithEqualAdjacentDivisors(3);
            Assert.Equal(1, result);
        }

        [Fact]
        public void ShouldReturnZeroWhenInputIsTwo()
        {
            int result = DivisorCounter.CountNumbersWithEqualAdjacentDivisors(2);
            Assert.Equal(0, result);
        }

        [Fact]
        public void ShouldReturnZeroWhenInputIsLessThanTwo()
        {
            int result = DivisorCounter.CountNumbersWithEqualAdjacentDivisors(1);
            Assert.Equal(0, result);
        }

        [Fact]
        public void ShouldNotReturnNegativeForLargerInput()
        {
            int result = DivisorCounter.CountNumbersWithEqualAdjacentDivisors(10);
            Assert.True(result >= 0);
        }
    }
}