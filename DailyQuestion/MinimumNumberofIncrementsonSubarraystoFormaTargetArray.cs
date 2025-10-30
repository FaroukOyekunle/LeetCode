namespace DailyQuestion
{
    public class MinimumNumberofIncrementsonSubarraystoFormaTargetArray
    {
        public int MinNumberOperations(int[] target)
        {
            int operations = target[0];

            for(int i = 1; i < target.Length; i++)
            {
                if(target[i] > target[i - 1])
                {
                    operations += target[i] - target[i - 1];
                }
            }

            return operations;
        }
    }
}