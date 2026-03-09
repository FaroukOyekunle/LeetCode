namespace DailyQuestion
{
    public class FindAllPossibleStableBinaryArraysI
    {
        const int MODULO = 1_000_000_007;

        public int NumberOfStableArrays(int zeroCount, int oneCount, int maxRunLength)
        {
            long[,,,] dp = new long[zeroCount + 1, oneCount + 1, 2, maxRunLength + 1];

            if (zeroCount > 0)
            {
                dp[1, 0, 0, 1] = 1; 
            }

            if (oneCount > 0)
            {
                dp[0, 1, 1, 1] = 1; 
            }

            for (int currentZeroCount = 0; currentZeroCount <= zeroCount; currentZeroCount++)
            {
                for (int currentOneCount = 0; currentOneCount <= oneCount; currentOneCount++)
                {
                    for (int lastDigit = 0; lastDigit <= 1; lastDigit++)
                    {
                        for (int currentRunLength = 1; currentRunLength <= maxRunLength; currentRunLength++)
                        {
                            long currentCount = dp[currentZeroCount, currentOneCount, lastDigit, currentRunLength];
                            if (currentCount == 0)
                            {
                                continue;
                            }

                            if (lastDigit == 0)
                            {
                                if (currentZeroCount + 1 <= zeroCount && currentRunLength + 1 <= maxRunLength)
                                {
                                    dp[currentZeroCount + 1, currentOneCount, 0, currentRunLength + 1] =
                                        (dp[currentZeroCount + 1, currentOneCount, 0, currentRunLength + 1] + currentCount) % MODULO;
                                }

                                if (currentOneCount + 1 <= oneCount)
                                {
                                    dp[currentZeroCount, currentOneCount + 1, 1, 1] =
                                        (dp[currentZeroCount, currentOneCount + 1, 1, 1] + currentCount) % MODULO;
                                }
                            }

                            else
                            {
                                if (currentOneCount + 1 <= oneCount && currentRunLength + 1 <= maxRunLength)
                                {
                                    dp[currentZeroCount, currentOneCount + 1, 1, currentRunLength + 1] =
                                        (dp[currentZeroCount, currentOneCount + 1, 1, currentRunLength + 1] + currentCount) % MODULO;
                                }

                                if (currentZeroCount + 1 <= zeroCount)
                                {
                                    dp[currentZeroCount + 1, currentOneCount, 0, 1] =
                                        (dp[currentZeroCount + 1, currentOneCount, 0, 1] + currentCount) % MODULO;
                                }
                            }
                        }
                    }
                }
            }

            long totalStableArrays = 0;

            for (int runLength = 1; runLength <= maxRunLength; runLength++)
            {
                totalStableArrays = (totalStableArrays + dp[zeroCount, oneCount, 0, runLength]) % MODULO;
                totalStableArrays = (totalStableArrays + dp[zeroCount, oneCount, 1, runLength]) % MODULO;
            }

            return (int)totalStableArrays;
        }
    }
}