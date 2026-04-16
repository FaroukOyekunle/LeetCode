namespace DailyQuestion
{
    public class ClosestEqualElementQueries
    {
        public IList<int> SolveQueries(int[] numbers, int[] queryIndices)
        {
            int totalLength = numbers.Length;

            var valueToIndicesMap = new Dictionary<int, List<int>>();
            for (int currentIndex = 0; currentIndex < totalLength; currentIndex++)
            {
                int currentValue = numbers[currentIndex];

                if (!valueToIndicesMap.ContainsKey(currentValue))
                {
                    valueToIndicesMap[currentValue] = new List<int>();
                }

                valueToIndicesMap[currentValue].Add(currentIndex);
            }

            var queryResults = new List<int>();

            foreach (int queryIndex in queryIndices)
            {
                int targetValue = numbers[queryIndex];
                List<int> occurrenceIndices = valueToIndicesMap[targetValue];

                if (occurrenceIndices.Count == 1)
                {
                    queryResults.Add(-1);
                    continue;
                }

                int positionInOccurrences = occurrenceIndices.BinarySearch(queryIndex);
                if (positionInOccurrences < 0)
                {
                    positionInOccurrences = ~positionInOccurrences;
                }

                int previousOccurrenceIndexPosition = (positionInOccurrences - 1 + occurrenceIndices.Count) % occurrenceIndices.Count;

                int nextOccurrenceIndexPosition = (positionInOccurrences + 1) % occurrenceIndices.Count;

                int previousOccurrenceIndex = occurrenceIndices[previousOccurrenceIndexPosition];
                int nextOccurrenceIndex = occurrenceIndices[nextOccurrenceIndexPosition];

                int distanceToPrevious = Math.Min( Math.Abs(queryIndex - previousOccurrenceIndex), totalLength - Math.Abs(queryIndex - previousOccurrenceIndex));

                int distanceToNext = Math.Min( Math.Abs(queryIndex - nextOccurrenceIndex), totalLength - Math.Abs(queryIndex - nextOccurrenceIndex));

                int minimumDistanceForQuery = Math.Min(distanceToPrevious, distanceToNext);

                queryResults.Add(minimumDistanceForQuery);
            }

            return queryResults;
        }
    }
}