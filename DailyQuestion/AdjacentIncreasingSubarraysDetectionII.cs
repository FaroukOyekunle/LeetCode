namespace DailyQuestion
{
    public class AdjacentIncreasingSubarraysDetectionII
    {
        public int MaxIncreasingSubarrays(IList<int> nums)
        {
            int numberCount = nums.Count;
            if(numberCount < 2)
            {
                return 0;
            }

            int[] includeLeftNumberCount = new int[numberCount];
            int[] includeRightNumberCount = new int[numberCount];

            includeLeftNumberCount[0] = 1;
            for(int i = 1; i < numberCount; i++)
            {
                includeLeftNumberCount[i] = (nums[i] > nums[i - 1]) ? includeLeftNumberCount[i - 1] + 1 : 1;
            }

            includeRightNumberCount[numberCount - 1] = 1;
            for(int i = numberCount - 2; i >= 0; i--)
            {
                includeRightNumberCount[i] = (nums[i] < nums[i + 1]) ? includeRightNumberCount[i + 1] + 1 : 1;
            }

            int maximumKCount = 0;
            for(int i = 0; i < numberCount - 1; i++)
            {
                int response = Math.Min(includeLeftNumberCount[i], includeRightNumberCount[i + 1]);
                maximumKCount = Math.Max(maximumKCount, response);
            }

            return maximumKCount;
        }
    }
}