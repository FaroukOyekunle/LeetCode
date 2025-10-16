namespace DailyQuestion
{
    public class SmallestMissingNonNegativeIntegerAfterOperations
    {
        public int FindSmallestInteger(int[] nums, int value)
        {
            Dictionary<int, int> remainderCount = new Dictionary<int, int>();

            foreach(int value in nums)
            {
                int remainder = ((value % value) + value) % value;

                if(!remainderCount.ContainsKey(remainder))
                {
                    remainderCount[remainder] = 0;
                }

                remainderCount[remainder]++;
            }

            int maximumNumberLimit = 0;

            while(true)
            {
                int reminderLimitCount = maximumNumberLimit % value;

                if(remainderCount.ContainsKey(reminderLimitCount) && remainderCount[reminderLimitCount] > 0)
                {
                    remainderCount[reminderLimitCount]--;
                    maximumNumberLimit++;
                }

                else
                {
                    return maximumNumberLimit;
                }
            }
        }
    }
}