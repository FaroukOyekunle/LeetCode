namespace DailyQuestion
{
    public class MaximumTotalSubarrayValueII
    {
        private class SparseTableRangeQuery
        {
            private readonly int[,] rangeMaximumTable;
            private readonly int[,] rangeMinimumTable;
            private readonly int[] logarithmLookup;

            public SparseTableRangeQuery(int[] numbers)
            {
                int arrayLength = numbers.Length;
                int maximumPowerOfTwo = (int)Math.Log2(arrayLength) + 2;

                rangeMaximumTable = new int[arrayLength, maximumPowerOfTwo];
                rangeMinimumTable = new int[arrayLength, maximumPowerOfTwo];
                logarithmLookup = new int[arrayLength + 1];

                for (int length = 2; length <= arrayLength; length++)
                {
                    logarithmLookup[length] = logarithmLookup[length / 2] + 1;
                }

                for (int startIndex = 0; startIndex < arrayLength; startIndex++)
                {
                    rangeMaximumTable[startIndex, 0] = numbers[startIndex];
                    rangeMinimumTable[startIndex, 0] = numbers[startIndex];
                }

                for (int power = 1; power < maximumPowerOfTwo; power++)
                {
                    int intervalLength = 1 << power;

                    for (int startIndex = 0; startIndex + intervalLength <= arrayLength; startIndex++)
                    {
                        int secondHalfStartIndex = startIndex + (1 << (power - 1));

                        rangeMaximumTable[startIndex, power] = Math.Max(rangeMaximumTable[startIndex, power - 1], rangeMaximumTable[secondHalfStartIndex, power - 1]);

                        rangeMinimumTable[startIndex, power] = Math.Min(rangeMinimumTable[startIndex, power - 1], rangeMinimumTable[secondHalfStartIndex, power - 1]);
                    }
                }
            }

            public int GetMaximumValueInRange(int rangeStartIndex, int rangeEndIndex)
            {
                int power = logarithmLookup[rangeEndIndex - rangeStartIndex + 1];

                return Math.Max(rangeMaximumTable[rangeStartIndex, power], rangeMaximumTable[rangeEndIndex - (1 << power) + 1, power]);
            }

            public int GetMinimumValueInRange(int rangeStartIndex, int rangeEndIndex)
            {
                int power = logarithmLookup[rangeEndIndex - rangeStartIndex + 1];

                return Math.Min(rangeMinimumTable[rangeStartIndex, power], rangeMinimumTable[rangeEndIndex - (1 << power) + 1, power]);
            }
        }

        public long MaxTotalValue(int[] numbers, int numberOfSelections)
        {
            int arrayLength = numbers.Length;

            var rangeQueryHelper = new SparseTableRangeQuery(numbers);

            var subarrayValueMaxHeap = new PriorityQueue<(long subarrayValue, int startIndex, int endIndex), long>();

            for (int subarrayStartIndex = 0; subarrayStartIndex < arrayLength; subarrayStartIndex++)
            {
                long currentSubarrayValue = (long)rangeQueryHelper.GetMaximumValueInRange(subarrayStartIndex, arrayLength - 1)
                    - rangeQueryHelper.GetMinimumValueInRange(subarrayStartIndex, arrayLength - 1);

                subarrayValueMaxHeap.Enqueue((currentSubarrayValue, subarrayStartIndex, arrayLength - 1), -currentSubarrayValue);
            }

            long totalMaximumValue = 0;

            for (int selectionNumber = 0; selectionNumber < numberOfSelections; selectionNumber++)
            {
                var highestValueSubarray = subarrayValueMaxHeap.Dequeue();

                totalMaximumValue += highestValueSubarray.subarrayValue;

                if (highestValueSubarray.endIndex > highestValueSubarray.startIndex)
                {
                    int reducedRangeEndIndex = highestValueSubarray.endIndex - 1;

                    long reducedSubarrayValue = (long)rangeQueryHelper.GetMaximumValueInRange(highestValueSubarray.startIndex, reducedRangeEndIndex)
                        - rangeQueryHelper.GetMinimumValueInRange(highestValueSubarray.startIndex, reducedRangeEndIndex);

                    subarrayValueMaxHeap.Enqueue((reducedSubarrayValue, highestValueSubarray.startIndex, reducedRangeEndIndex), -reducedSubarrayValue);
                }
            }

            return totalMaximumValue;
        }
    }
}