using CSharpFunctionalExtensions;
using System;
using Xunit;

namespace SmallestPairSumInArray.Tests
{
    public class SearchEngineTests
    {
        private readonly ISearchEngine _searchEngine;

        public SearchEngineTests()
        {
            _searchEngine = new SearchEngine();
        }

        [Theory]
        [ClassData(typeof(ArraysWithMoreThanOneElements))]
        public void SearchSmallestPair_NumbersArrayWithMoreThanOneElements_ExpectedSmallestPair
            (int[] input, Result<(int, int)> expected)
        {
            var smallestPairResult = _searchEngine.SearchSmallestPair(input);

            Assert.True(smallestPairResult.IsSuccess);
            Assert.Equal(expected.Value, smallestPairResult.Value);
        }

        [Theory]
        [ClassData(typeof(ArraysWithLessThanOneElements))]
        public void SearchSmallestPair_NumbersArrayWithLessThanTwoElements_ResultFailed(int[] input)
        {
            var expected = Result.Fail<(int, int)>("The array must contain at least two elements.");

            var smallestPairResult = _searchEngine.SearchSmallestPair(input);

            Assert.True(smallestPairResult.IsFailure);
            Assert.Equal(smallestPairResult.Error, expected.Error);
        }


        private class ArraysWithMoreThanOneElements : TheoryData<int[], Result<(int, int)>>
        {
            public ArraysWithMoreThanOneElements()
            {
                Add(new int[] { 0, 1 }, Result.Ok((0, 1)));
                Add(new int[] { 4, 0, 3, 19, 492, -10, 1 }, Result.Ok((-10, 0)));
                Add(new int[100000000], Result.Ok((0, 0)));
            }
        }

        private class ArraysWithLessThanOneElements : TheoryData<int[]>
        {
            public ArraysWithLessThanOneElements()
            {
                Add(Array.Empty<int>());
                Add(new int[] { 0 });
            }
        }
    }
}
