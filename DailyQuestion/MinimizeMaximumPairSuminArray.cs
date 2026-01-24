namespace DailyQuestion
{
    public class MinimizeMaximumPairSuminArray
    {
        public int MinimizeMaximumPairSum(int[] inputNumbers)
        {
            Array.Sort(inputNumbers);

            int maximumPairSum = 0;
            int leftPointer = 0;
            int rightPointer = inputNumbers.Length - 1;

            while (leftPointer < rightPointer)
            {
                int currentPairSum = inputNumbers[leftPointer] + inputNumbers[rightPointer];
                maximumPairSum = Math.Max(maximumPairSum, currentPairSum);

                leftPointer++;
                rightPointer--;
            }

            return maximumPairSum;
        }
    }
}