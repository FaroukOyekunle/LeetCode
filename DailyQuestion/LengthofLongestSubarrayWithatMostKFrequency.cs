namespace DailyQuestion
{
    public class LengthofLongestSubarrayWithatMostKFrequency
    {
        public int MaxSubarrayLength(int[] nums, int k)
        {
            Dictionary<int, int> elementFrequency = new();

            int windowStartIndex = 0;
            int maximumSubarrayLength = 0;

            for (int windowEndIndex = 0; windowEndIndex < nums.Length; windowEndIndex++)
            {
                int currentElement = nums[windowEndIndex];

                if (!elementFrequency.ContainsKey(currentElement))
                {
                    elementFrequency[currentElement] = 0;
                }

                elementFrequency[currentElement]++;

                while (elementFrequency[currentElement] > k)
                {
                    int elementLeavingWindow = nums[windowStartIndex];
                    elementFrequency[elementLeavingWindow]--;
                    windowStartIndex++;
                }

                int currentWindowLength = windowEndIndex - windowStartIndex + 1;

                maximumSubarrayLength = Math.Max(maximumSubarrayLength, currentWindowLength);
            }

            return maximumSubarrayLength;
        }
    }
}