namespace StudyPlan.Problem.LeetCode75.SlidingWindow
{
    public class MaxConsecutiveOnesIII
    {
        public int LongestOnes(int[] nums, int k)
        {
            int left = 0, zeros = 0, maxLen = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    zeros++;
                }

                while (zeros > k)
                {
                    if (nums[left] == 0)
                    {
                        zeros--;
                    }
                    left++;
                }

                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }
    }
}