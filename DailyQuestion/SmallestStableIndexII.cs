namespace DailyQuestion
{
    public class SmallestStableIndexII
    {
        public int FirstStableIndex(int[] numbers, int maximumAllowedInstability)
        {
            int arrayLength = numbers.Length;

            int[] minimumValueFromCurrentIndexToEnd = new int[arrayLength];

            minimumValueFromCurrentIndexToEnd[arrayLength - 1] = numbers[arrayLength - 1];

            for (int currentIndex = arrayLength - 2; currentIndex >= 0; currentIndex--)
            {
                minimumValueFromCurrentIndexToEnd[currentIndex] = Math.Min(numbers[currentIndex], minimumValueFromCurrentIndexToEnd[currentIndex + 1]);
            }

            int maximumValueFromStartToCurrentIndex = numbers[0];

            for (int currentIndex = 0; currentIndex < arrayLength; currentIndex++)
            {
                maximumValueFromStartToCurrentIndex = Math.Max(maximumValueFromStartToCurrentIndex, numbers[currentIndex]);

                int currentInstabilityScore = maximumValueFromStartToCurrentIndex - minimumValueFromCurrentIndexToEnd[currentIndex];

                if (currentInstabilityScore <= maximumAllowedInstability)
                {
                    return currentIndex;
                }
            }

            return -1;
        }
    }
}