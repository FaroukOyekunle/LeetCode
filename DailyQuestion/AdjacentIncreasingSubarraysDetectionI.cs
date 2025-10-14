namespace DailyQuestion
{
    public class AdjacentIncreasingSubarraysDetectionI
    {
        public bool HasIncreasingSubarrays(IList<int> nums, int k)
        {
            int numbersCount = nums.Count;

            bool IsIncreasing(int startIncreasingCount)
            {
                for(int i = startIncreasingCount; i < startIncreasingCount + k - 1; i++)
                {
                    if(nums[i] >= nums[i + 1])
                    {
                        return false;
                    }
                }
                return true;
            }

            for(int a = 0; a + 2 * k <= numbersCount; a++)
            {
                int b = a + k;

                if(IsIncreasing(a) && IsIncreasing(b))
                {
                    return true;
                }
            }

            return false;
        }
    }
}