namespace StudyPlan.Problem.LeetCode75.BitManipulation
{
    public class SingleNumber
    {
        public int SingleNumber(int[] nums) 
        {
            int result = 0;

            foreach(int x in nums) 
            {
                result ^= x;
            }
            
            return result;
        }
    }
}