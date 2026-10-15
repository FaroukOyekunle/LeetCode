namespace DailyQuestion
{
    public class SubarraysDistinctElementSumofSquaresI
    {
        public int SumCounts(IList<int> numbers)
        {
            int sumOfSquaredDistinctCounts = 0;

            for (int subarrayStartIndex = 0; subarrayStartIndex < numbers.Count; subarrayStartIndex++)
            {
                var distinctNumbersInSubarray = new HashSet<int>();

                for (int subarrayEndIndex = subarrayStartIndex; subarrayEndIndex < numbers.Count; subarrayEndIndex++)
                {
                    distinctNumbersInSubarray.Add(numbers[subarrayEndIndex]);

                    int distinctNumberCount = distinctNumbersInSubarray.Count;

                    sumOfSquaredDistinctCounts += distinctNumberCount * distinctNumberCount;
                }
            }

            return sumOfSquaredDistinctCounts;
        }
    }
}