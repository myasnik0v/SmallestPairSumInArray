using System;
using System.Collections.Generic;

namespace SmallestPairSumInArray
{
    public interface IValuesProvider
    {
        IEnumerable<int> Values { get; }
        int ItemsCount { get; }
    }

    public class ValuesProvider : IValuesProvider
    {
        private readonly int[] _array;

        private ValuesProvider(int[] input)
        {
            _array = input ?? throw new ArgumentNullException(nameof(input));
        }

        public static ValuesProvider Create(int[] input)
        {
            return new ValuesProvider(input);
        }

        public IEnumerable<int> Values
        {
            get
            {
                foreach (var item in _array)
                    yield return item;
            }
        }

        public int ItemsCount => _array.Length;
    }
}
