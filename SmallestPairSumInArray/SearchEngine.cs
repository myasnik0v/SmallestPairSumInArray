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
            IValuesProvider valuesProvider = ValuesProvider.Create(input);

            var validationResult = ValidateInput(valuesProvider);
            if (validationResult.IsFailure)
                return Result.Fail<(int, int)>(validationResult.Error);

            int first = int.MaxValue;
            var second = int.MaxValue;

            foreach (var item in valuesProvider.Values)
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


        #region Helpers

        /// <summary>
        /// Проверяет корректность введенного массива
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private Result ValidateInput(IValuesProvider valuesProvider)
        {
            return valuesProvider.ItemsCount < 2
                ? Result.Fail("The array must contain at least two elements.")
                : Result.Ok();
        }

        #endregion
    }
}
