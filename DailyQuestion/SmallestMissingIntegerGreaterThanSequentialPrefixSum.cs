namespace DailyQuestion
{
    public class SmallestMissingIntegerGreaterThanSequentialPrefixSum
    {
        public int MissingInteger(int[] nums)
        {
            int sequentialPrefixSum = nums[0];

            for (int currentIndex = 1; currentIndex < nums.Length; currentIndex++)
            {
                int previousValue = nums[currentIndex - 1];
                int currentValue = nums[currentIndex];

                if (currentValue != previousValue + 1)
                {
                    break;
                }

                sequentialPrefixSum += currentValue;
            }

            HashSet<int> existingNumbers = new HashSet<int>(nums);

            int smallestMissingInteger = sequentialPrefixSum;

            while (existingNumbers.Contains(smallestMissingInteger))
            {
                smallestMissingInteger++;
            }

            return smallestMissingInteger;
        }

    }
}