using CSharpFunctionalExtensions;

namespace SmallestPairSumInArray
{
    public interface ISearchEngine
    {
        Result<(int, int)> SearchSmallestPair(int[] input);
    }

    public class SearchEngine : ISearchEngine
    {
        /// <summary>
        /// Ищет два минимальных элемента массива
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Result<(int, int)> SearchSmallestPair(int[] input)
        {
            int first = int.MaxValue;
            var second = int.MaxValue;

            foreach (var item in input)
            {
                if (item < first)
                {
                    second = first;
                    first = item;
                }
                else if (item < second)
                {
                    second = item;
                }
            }

            return Result.Ok((first, second));
        }
    }
}
