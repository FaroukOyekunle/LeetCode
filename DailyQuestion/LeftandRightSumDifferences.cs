namespace DailyQuestion
{
    public class LeftandRightSumDifferences
    {
        public int[] LeftRightDifference(int[] numbers)
        {
            int totalArraySum = numbers.Sum();

            int cumulativeLeftSum = 0;

            int[] leftRightDifferenceArray = new int[numbers.Length];

            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                int cumulativeRightSum = totalArraySum - cumulativeLeftSum - numbers[currentIndex];

                leftRightDifferenceArray[currentIndex] = Math.Abs(cumulativeLeftSum - cumulativeRightSum);

                cumulativeLeftSum += numbers[currentIndex];
            }

            return leftRightDifferenceArray;
        }
    }
}