namespace StudyPlan.Problem.LeetCode75.DP - 1D
{
    public class MinCostClimbingStairs
    {
        public int MinCostClimbingStairs(int[] cost) 
        {
            int n = cost.Length;
            int[] dp = new int[n + 1];
            
            dp[0] = 0;
            dp[1] = 0;
            
            for(int i = 2; i <= n; i++) 
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }
            
            return dp[n];
        }
    }
}