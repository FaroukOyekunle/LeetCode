namespace DailyQuestion
{
    public class SumofDistances
    {
        public long[] CalculateDistanceToSameValues(int[] inputNumbers)
        {
            int totalLength = inputNumbers.Length;

            long[] distanceResults = new long[totalLength];

            var valueToAllIndicesMap = new Dictionary<int, List<int>>();

            for (int currentIndex = 0; currentIndex < totalLength; currentIndex++)
            {
                int currentValue = inputNumbers[currentIndex];

                if (!valueToAllIndicesMap.ContainsKey(currentValue))
                {
                    valueToAllIndicesMap[currentValue] = new List<int>();
                }

                valueToAllIndicesMap[currentValue].Add(currentIndex);
            }

            foreach (var indicesWithSameValue in valueToAllIndicesMap.Values)
            {
                int numberOfOccurrences = indicesWithSameValue.Count;

                if (numberOfOccurrences == 1)
                {
                    continue;
                }

                long[] prefixSumOfIndices = new long[numberOfOccurrences];
                prefixSumOfIndices[0] = indicesWithSameValue[0];

                for (int occurrenceIndex = 1; occurrenceIndex < numberOfOccurrences; occurrenceIndex++)
                {
                    prefixSumOfIndices[occurrenceIndex] = prefixSumOfIndices[occurrenceIndex - 1] + indicesWithSameValue[occurrenceIndex];
                }

                for (int occurrenceIndex = 0; occurrenceIndex < numberOfOccurrences; occurrenceIndex++)
                {
                    int actualArrayIndex = indicesWithSameValue[occurrenceIndex];

                    long distanceFromLeftSide = 0;
                    if (occurrenceIndex > 0)
                    {
                        distanceFromLeftSide = (long)occurrenceIndex * actualArrayIndex - prefixSumOfIndices[occurrenceIndex - 1];
                    }

                    long distanceFromRightSide = 0;
                    if (occurrenceIndex < numberOfOccurrences - 1)
                    {
                        distanceFromRightSide = (prefixSumOfIndices[numberOfOccurrences - 1] - prefixSumOfIndices[occurrenceIndex]) - (long)(numberOfOccurrences - occurrenceIndex - 1) * actualArrayIndex;
                    }

                    distanceResults[actualArrayIndex] = distanceFromLeftSide + distanceFromRightSide;
                }
            }

            return distanceResults;
        }
    }
}