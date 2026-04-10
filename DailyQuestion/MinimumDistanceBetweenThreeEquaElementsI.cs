namespace DailyQuestion
{
    public class MinimumDistanceBetweenThreeEquaElementsI
    {
        public int GetMinimumDistanceBetweenEqualValueTriplets(int[] numbers)
        {
            var valueToIndicesMap = new Dictionary<int, List<int>>();

            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                int currentValue = numbers[currentIndex];

                if (!valueToIndicesMap.ContainsKey(currentValue))
                {
                    valueToIndicesMap[currentValue] = new List<int>();
                }

                valueToIndicesMap[currentValue].Add(currentIndex);
            }

            int minimumDistance = int.MaxValue;

            foreach (var valueGroup in valueToIndicesMap)
            {
                List<int> occurrenceIndices = valueGroup.Value;

                if (occurrenceIndices.Count < 3)
                {
                    continue;
                }

                for (int startIndex = 0; startIndex <= occurrenceIndices.Count - 3; startIndex++)
                {
                    int leftmostIndex = occurrenceIndices[startIndex];
                    int rightmostIndex = occurrenceIndices[startIndex + 2];

                    int computedDistance = 2 * (rightmostIndex - leftmostIndex);

                    minimumDistance = Math.Min(minimumDistance, computedDistance);
                }
            }

            return minimumDistance == int.MaxValue ? -1 : minimumDistance;
        }
    }
}