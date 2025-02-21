namespace StudyPlan.Problem.LeetCode75.SlidingWindow
{
    public class MaximumAverageSubarrayI
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            int n = nums.Length;
            long sum = 0;

            for(int i = 0; i < k; i++)
            {
                sum += nums[i];
            }

            long maxSum = sum;

            for(int i = k; i < n; i++)
            {
                sum += nums[i] - nums[i - k];
                if(sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            return (double)maxSum / k;
        }
    }
}