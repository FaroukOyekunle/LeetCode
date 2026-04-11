namespace DailyQuestion
{
    public class MinimumDistanceBetweenThreeEqualElementsII
    {
        public int GetMinimumDistanceForEqualValueTriplets(int[] numbers)
        {
            var valueToIndexListMap = new Dictionary<int, List<int>>();

            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                int currentValue = numbers[currentIndex];

                if (!valueToIndexListMap.ContainsKey(currentValue))
                {
                    valueToIndexListMap[currentValue] = new List<int>();
                }

                valueToIndexListMap[currentValue].Add(currentIndex);
            }

            int minimumDistanceFound = int.MaxValue;

            foreach (var valueGroupEntry in valueToIndexListMap)
            {
                List<int> occurrenceIndices = valueGroupEntry.Value;

                if (occurrenceIndices.Count < 3)
                {
                    continue;
                }

                for (int tripletStartIndex = 0; tripletStartIndex <= occurrenceIndices.Count - 3; tripletStartIndex++)
                {
                    int firstIndexInTriplet = occurrenceIndices[tripletStartIndex];
                    int thirdIndexInTriplet = occurrenceIndices[tripletStartIndex + 2];

                    int computedDistance = 2 * (thirdIndexInTriplet - firstIndexInTriplet);

                    minimumDistanceFound = Math.Min(minimumDistanceFound, computedDistance);
                }
            }

            return minimumDistanceFound == int.MaxValue ? -1 : minimumDistanceFound;
        }
    }
}