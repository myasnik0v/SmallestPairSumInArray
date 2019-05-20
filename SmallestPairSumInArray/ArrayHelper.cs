using CSharpFunctionalExtensions;
using System;

namespace SmallestPairSumInArray
{
    public class ArrayHelper
    {
        private readonly ISearchEngine _searchEngine;

        public ArrayHelper(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine ?? throw new ArgumentNullException(nameof(searchEngine));
        }

        /// <summary>
        /// Возвращает сумму двух минимальных элементов массива
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Result<int> SumOfSmallestPair(int[] input)
        {
            var smallestPairResult = _searchEngine.SearchSmallestPair(input);

            if (smallestPairResult.IsFailure)
                return Result.Fail<int>(smallestPairResult.Error);

            var sumOfSmallestPair = smallestPairResult.Value.Item1 + smallestPairResult.Value.Item2;

            return Result.Ok(sumOfSmallestPair);
        }
    }
}
