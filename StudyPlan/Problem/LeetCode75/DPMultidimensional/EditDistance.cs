namespace StudyPlan.Problem.LeetCode75.DPMultidimensional
{
    public class EditDistance
    {
        public int MinDistance(string word1, string word2) 
        {
            int m = word1.Length, n = word2.Length;

            var dp = new int[m + 1, n + 1];

            for(int j = 0; j <= n; j++)
            {
                dp[0, j] = j; 
            }

            for(int i = 0; i <= m; i++)
            {
                dp[i, 0] = i;
            } 

            for(int i = 1; i <= m; i++) 
            {
                for(int j = 1; j <= n; j++) 
                {
                    if(word1[i - 1] == word2[j - 1]) 
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    } 
                    
                    else 
                    {
                        dp[i, j] = 1 + Math.Min(
                            Math.Min(
                                dp[i, j - 1],   
                                dp[i - 1, j]    
                            ),
                            dp[i - 1, j - 1]   
                        );
                    }
                }
            }

            return dp[m, n];
        }
    }
}