namespace DailyQuestion
{
    public class LongestSubsequenceWithNonZeroBitwiseXOR
    {
        public int LongestSubsequence(int[] nums)
        {
            int cumulativeXor = 0;
            bool containsNonZeroElement = false;

            foreach (int currentNumber in nums)
            {
                cumulativeXor ^= currentNumber;

                if (currentNumber != 0)
                {
                    containsNonZeroElement = true;
                }
            }

            if (cumulativeXor != 0)
            {
                return nums.Length;
            }

            return containsNonZeroElement ? nums.Length - 1 : 0;
        }
    }
}