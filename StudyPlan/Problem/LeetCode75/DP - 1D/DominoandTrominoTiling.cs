namespace StudyPlan.Problem.LeetCode75.DP - 1D
{
    public class DominoandTrominoTiling
    {
        public int NumTilings(int n) 
        {
            const int MOD = 1_000_000_007;

            if(n == 1)
            {
                return 1;
            } 

            if(n == 2)
            {
                return 2;
            }
            
            long[] dp = new long[n + 1];
            long[] dp2 = new long[n + 1];
            
            dp[0] = 1;
            dp[1] = 1;
            dp2[0] = 0;
            dp2[1] = 0;
            
            for(int i = 2; i <= n; i++) 
            {
                dp2[i] = (dp[i - 2] + dp2[i - 1]) % MOD;
                dp[i] = (dp[i - 1] + dp[i - 2] + 2 * dp2[i - 1]) % MOD;
            }
            
            return (int)dp[n];
        }
    }
}