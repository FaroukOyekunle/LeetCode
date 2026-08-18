namespace DailyQuestion
{
    public class FindtheLargestAlmostMissingInteger
    {
        public int LargestInteger(int[] nums, int k)
        {
            int largestAlmostMissingValue = -1;

            int[] subarrayPresenceCountByValue = new int[51];

            for (int subarrayStartIndex = 0; subarrayStartIndex <= nums.Length - k; subarrayStartIndex++)
            {
                bool[] valueExistsInCurrentSubarray = new bool[51];

                for (int currentIndex = subarrayStartIndex; currentIndex < subarrayStartIndex + k; currentIndex++)
                {
                    int currentValue = nums[currentIndex];

                    valueExistsInCurrentSubarray[currentValue] = true;
                }

                for (int value = 0; value <= 50; value++)
                {
                    if (valueExistsInCurrentSubarray[value])
                    {
                        subarrayPresenceCountByValue[value]++;
                    }
                }
            }

            for (int value = 50; value >= 0; value--)
            {
                if (subarrayPresenceCountByValue[value] == 1)
                {
                    return value;
                }
            }

            return largestAlmostMissingValue;
        }
    }
}