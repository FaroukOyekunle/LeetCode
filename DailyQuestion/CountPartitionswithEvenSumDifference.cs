namespace DailyQuestion
{
    public class CountPartitionswithEvenSumDifference
    {
        public int CountPartitions(int[] nums)
        {
            int length = nums.Length;

            int totalArraySum = 0;
            foreach(int value in nums)
            {
                totalArraySum += value;
            }

            int prefixSum = 0;
            int validPartitionCount = 0;

            for(int index = 0; index < length - 1; index++)
            {
                prefixSum += nums[index];
                int suffixSum = totalArraySum - prefixSum;

                if((prefixSum & 1) == (suffixSum & 1))
                {
                    validPartitionCount++;
                }
            }

            return validPartitionCount;
        }
    }
}