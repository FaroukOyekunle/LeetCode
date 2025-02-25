namespace StudyPlan.Problem.LeetCode75.PrefixSum
{
    public class FindPivotIndex
    {
        public int PivotIndex(int[] nums)
        {
            int total = 0;

            foreach(int num in nums)
            {
                total += num;
            }

            int leftSum = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if(leftSum == total - leftSum - nums[i])
                {
                    return i;
                }

                leftSum += nums[i];
            }

            return -1;
        }
    }
}