namespace DailyQuestion
{
    public class SmallestMissingMultipleofK
    {
        public int MissingMultiple(int[] nums, int k)
        {
            HashSet<int> existingNumbers = new(nums);

            int currentMultiple = k;

            while (existingNumbers.Contains(currentMultiple))
            {
                currentMultiple += k;
            }

            return currentMultiple;
        }
    }
}