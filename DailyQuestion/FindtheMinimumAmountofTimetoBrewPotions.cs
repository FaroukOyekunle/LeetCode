namespace DailyQuestion
{
    public class FindtheMinimumAmountofTimetoBrewPotions
    {
        public long MinTime(int[] skill, int[] mana)
        {
            int n = skill.Length;
            int m = mana.Length;

            long[] prefixSumForPreviousPortion = new long[n];
            long[] prefixSumForCurrentPortion = new long[n];

            long runningPotion = 0;
            for(int i = 0; i < n; i++)
            {
                runningPotion += (long)skill[i] * mana[0];
                prefixSumForPreviousPortion[i] = runningPotion;
            }

            long subPrevious = 0L; 

            for(int j = 1; j < m; j++)
            {
                long runningCurrentSum = 0L;        
                long maxRhs = long.MinValue;  

                for(int i = 0; i < n; i++)
                {
                    long rhs = subPrevious + prefixSumForPreviousPortion[i] - runningCurrentSum;
                    if (rhs > maxRhs)
                    {
                        maxRhs = rhs;
                    }

                    runningCurrentSum += (long)skill[i] * mana[j];
                    prefixSumForCurrentPortion[i] = runningCurrentSum;
                }

                subPrevious = maxRhs;

                var tmp = prefixSumForPreviousPortion;
                prefixSumForPreviousPortion = prefixSumForCurrentPortion;
                prefixSumForCurrentPortion = tmp;
            }

            return subPrevious + prefixSumForPreviousPortion[n - 1];
        }

    }
}