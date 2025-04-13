namespace StudyPlan.Problem.LeetCode75.BitManipulation
{
    public class CountingBits
    {
        public int[] CountBits(int n) 
        {
            var ans = new int[n + 1];
            ans[0] = 0;

            for (int i = 1; i <= n; i++) 
            {
                ans[i] = ans[i >> 1] + (i & 1);
            }
            
            return ans;
        }
    }
}