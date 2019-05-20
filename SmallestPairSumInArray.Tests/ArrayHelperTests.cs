using CSharpFunctionalExtensions;
using Moq;
using Xunit;

namespace SmallestPairSumInArray.Tests
{
    public class ArrayHelperTests
    {
        private readonly Mock<ISearchEngine> _mockSearchEngine;

        public ArrayHelperTests()
        {
            _mockSearchEngine = new Mock<ISearchEngine>();
        }

        [Fact]
        public void SumOfSmallestPair()
        {
            var input = new int[] { 0, 1 };

            _mockSearchEngine
                .Setup(m => m.SearchSmallestPair(input))
                .Returns(Result.Ok((0, 1)));
            var arrayHelper = new ArrayHelper(_mockSearchEngine.Object);

            var smallestPairResult = arrayHelper.SumOfSmallestPair(input);

            Assert.True(smallestPairResult.IsSuccess);
            Assert.Equal(1, smallestPairResult.Value);
        }
    }
}
