namespace DailyQuestion
{
    public class MaximumTotalSubarrayValueI
    {
        public long MaxTotalValue(int[] numbers, int repetitionCount)
        {
            int smallestValueInArray = numbers[0];
            int largestValueInArray = numbers[0];

            foreach (int currentValue in numbers)
            {
                if (currentValue < smallestValueInArray)
                {
                    smallestValueInArray = currentValue;
                }

                if (currentValue > largestValueInArray)
                {
                    largestValueInArray = currentValue;
                }
            }

            long maximumPossibleSubarrayValue = (long)largestValueInArray - smallestValueInArray;

            long maximumTotalValue = maximumPossibleSubarrayValue * repetitionCount;

            return maximumTotalValue;
        }
    }
}