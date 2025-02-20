namespace StudyPlan.Problem.LeetCode75.TwoPointers
{
    public class MaxNumberofK-SumPairs
    {
        public int MaxOperations(int[] nums, int k)
        {

            Dictionary<int, int> frequency = new Dictionary<int, int>();
            int operations = 0;

            foreach(int num in nums)
            {
                int complement = k - num;

                if(frequency.ContainsKey(complement) && frequency[complement] > 0)
                {
                    operations++;
                    frequency[complement]--;
                }

                else
                {
                    if(frequency.ContainsKey(num))
                    {
                        frequency[num]++;
                    }

                    else
                    {
                        frequency[num] = 1;
                    }

                }
            }

            return operations;
        }
    }
}