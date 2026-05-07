namespace DailyQuestion
{
    public class JumpGameIX
    {
        public int[] BuildMaximumValueArrayForComponents(int[] inputNumbers)
        {
            int totalElementCount = inputNumbers.Length;

            int[] maximumValueFromLeft = new int[totalElementCount];

            int[] minimumValueFromRight = new int[totalElementCount];

            maximumValueFromLeft[0] = inputNumbers[0];

            for (int currentIndex = 1; currentIndex < totalElementCount; currentIndex++)
            {
                maximumValueFromLeft[currentIndex] = Math.Max( maximumValueFromLeft[currentIndex - 1], inputNumbers[currentIndex]);
            }

            minimumValueFromRight[totalElementCount - 1] = inputNumbers[totalElementCount - 1];

            for (int currentIndex = totalElementCount - 2; currentIndex >= 0; currentIndex--)
            {
                minimumValueFromRight[currentIndex] = Math.Min( minimumValueFromRight[currentIndex + 1], inputNumbers[currentIndex]);
            }

            int[] maximumValueForEachComponent = new int[totalElementCount];

            int currentComponentStartIndex = 0;

            for (int partitionEndIndex = 0; partitionEndIndex < totalElementCount - 1; partitionEndIndex++)
            {
                bool isValidPartitionBoundary = maximumValueFromLeft[partitionEndIndex] <= minimumValueFromRight[partitionEndIndex + 1];

                if (isValidPartitionBoundary)
                {
                    int maximumValueInsideCurrentComponent = inputNumbers[currentComponentStartIndex];

                    for (int scanIndex = currentComponentStartIndex; scanIndex <= partitionEndIndex; scanIndex++)
                    {
                        maximumValueInsideCurrentComponent = Math.Max( maximumValueInsideCurrentComponent, inputNumbers[scanIndex]);
                    }

                    for (int fillIndex = currentComponentStartIndex; fillIndex <= partitionEndIndex; fillIndex++)
                    {
                        maximumValueForEachComponent[fillIndex] = maximumValueInsideCurrentComponent;
                    }

                    currentComponentStartIndex = partitionEndIndex + 1;
                }
            }

            int maximumValueInsideLastComponent = inputNumbers[currentComponentStartIndex];

            for (int currentIndex = currentComponentStartIndex; currentIndex < totalElementCount; currentIndex++)
            {
                maximumValueInsideLastComponent = Math.Max( maximumValueInsideLastComponent, inputNumbers[currentIndex]);
            }

            for (int fillIndex = currentComponentStartIndex; fillIndex < totalElementCount; fillIndex++)
            {
                maximumValueForEachComponent[fillIndex] = maximumValueInsideLastComponent;
            }

            return maximumValueForEachComponent;
        }
    }
}