namespace StudyPlan.Problem.LeetCode75.DPMultidimensional
{
    public class LongestCommonSubsequence
    {
        public int LongestCommonSubsequence(string text1, string text2) 
        {
    
            int m = text1.Length, n = text2.Length;
            var dp = new int[m + 1, n + 1];

            for(int i = 1; i <= m; i++) 
            {
                for(int j = 1; j <= n; j++) 
                {
                    if(text1[i - 1] == text2[j - 1]) 
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    } 
                    
                    else 
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[m, n];
        }
    }
}