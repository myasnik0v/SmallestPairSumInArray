using CSharpFunctionalExtensions;

namespace SmallestPairSumInArray
{
    public interface ISearchEngine
    {
        Result<(int, int)> SearchSmallestPair(int[] input);
    }
}
