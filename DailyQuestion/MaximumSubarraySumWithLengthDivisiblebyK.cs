namespace DailyQuestion
{
    public class MaximumSubarraySumWithLengthDivisiblebyK
    {
        public long MaxSubarraySum(int[] numbers, int k)
        {
            int length = numbers.Length;
            long[] minPrefixSumByRem = new long[k];

            for(int rem = 0; rem < k; rem++)
            {
                minPrefixSumByRem[rem] = long.MaxValue;
            }

            long currentPrefixSum = 0;
            long maxSum = long.MinValue;

            minPrefixSumByRem[0] = 0;

            for(int index = 0; index < length; index++)
            {
                currentPrefixSum += numbers[index];
                int remainder = (int)((index + 1) % k);

                if(minPrefixSumByRem[remainder] != long.MaxValue)
                {
                    long candidateSum = currentPrefixSum - minPrefixSumByRem[remainder];
                    if(candidateSum > maxSum)
                    {
                        maxSum = candidateSum;
                    }
                }

                minPrefixSumByRem[remainder] = Math.Min(minPrefixSumByRem[remainder], currentPrefixSum);
            }

            return maxSum;
        }
    }
}