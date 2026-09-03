namespace DailyQuestion
{
    public class ConstructUniformParityArrayII
    {
        public bool UniformArray(int[] nums1)
        {
            int minimumValue = nums1[0];
            bool containsOddValue = (nums1[0] % 2 != 0);

            for (int index = 1; index < nums1.Length; index++)
            {
                minimumValue = Math.Min(minimumValue, nums1[index]);

                if (nums1[index] % 2 != 0)
                {
                    containsOddValue = true;
                }
            }

            return minimumValue % 2 != 0 || !containsOddValue;
        }
    }
}