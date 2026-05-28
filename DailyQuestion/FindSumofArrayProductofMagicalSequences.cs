namespace DailyQuestion
{
    public class FindSumofArrayProductofMagicalSequences
    {
        const int MOD = 1_000_000_007;

        public int MagicalSum(int remainderCount, int k, int[] nums)
        {
            int numberOfSequence = nums.Length;

            long[] firstMagicalSum = new long[remainderCount + 1];
            long[] inverseFact = new long[remainderCount + 1];

            firstMagicalSum[0] = 1;

            for(int i = 1; i <= remainderCount; i++)
            {
                firstMagicalSum[i] = firstMagicalSum[i - 1] * i % MOD;
            }

            inverseFact[remainderCount] = ModulusInversion(firstMagicalSum[remainderCount]);

            for(int i = remainderCount - 1; i >= 0; i--)
            {
                inverseFact[i] = inverseFact[i + 1] * (i + 1) % MOD;
            }

            Func<int, int, long> Choose = (a, b) =>
            {
                if(b < 0 || b > a)
                {
                    return 0;
                }

                return firstMagicalSum[a] * inverseFact[b] % MOD * inverseFact[a - b] % MOD;
            };

            long[][] powNums = new long[numberOfSequence][];
            for(int i = 0; i < numberOfSequence; i++)
            {
                powNums[i] = new long[remainderCount + 1];
                powNums[i][0] = 1;

                for(int c = 1; c <= remainderCount; c++)
                {
                    powNums[i][c] = (powNums[i][c - 1] * nums[i]) % MOD;
                }
            }

            long[,,] dp = new long[remainderCount + 1, remainderCount + 1, k + 1];
            dp[0, 0, 0] = 1;

            for(int idx = 0; idx < numberOfSequence; idx++)
            {
                long[,,] next = new long[remainderCount + 1, remainderCount + 1, k + 1];

                for(int t = 0; t <= remainderCount; t++)
                {
                    for(int carry = 0; carry <= remainderCount; carry++)
                    {
                        for(int ones = 0; ones <= k; ones++)
                        {
                            long cur = dp[t, carry, ones];
                            if(cur == 0)
                            {
                                continue;
                            }

                            int maxC = remainderCount - t;
                            for(int c = 0; c <= maxC; c++)
                            {
                                int val = c + carry;
                                int bitwiseShiftValue = val & 1;
                                int newOnes = ones + bitwiseShiftValue;

                                if(newOnes > k)
                                {
                                    continue;
                                }
                                int newCarry = val >> 1;

                                if(newCarry > remainderCount)
                                {
                                    continue;
                                }

                                long ways = Choose(remainderCount - t, c);
                                long mult = cur * ways % MOD * powNums[idx][c] % MOD;
                                next[t + c, newCarry, newOnes] = (next[t + c, newCarry, newOnes] + mult) % MOD;
                            }
                        }
                    }
                }

                dp = next;
            }

            long ans = 0;
            for(int carry = 0; carry <= remainderCount; carry++)
            {
                int carryOnes = PopulateCount(carry);
                for(int ones = 0; ones <= k; ones++)
                {
                    if(ones + carryOnes != k)
                    {
                        continue;
                    }

                    long val = dp[remainderCount, carry, ones];

                    if(val == 0)
                    {
                        continue;
                    }
                    ans = (ans + val) % MOD;
                }
            }

            return (int)ans;
        }

        private static int PopulateCount(int x)
        {
            int cnt = 0;

            while (x > 0)
            {
                x &= x - 1; cnt++;
            }
            
            return cnt;
        }

        private static long ModulusInversion(long x)
        {
            return ModulusRaiseToPower(x, MOD - 2);
        }

        private static long ModulusRaiseToPower(long a, long e)
        {
            long res = 1;
            a %= MOD;

            while (e > 0)
            {
                if ((e & 1) == 1) res = (res * a) % MOD;
                a = (a * a) % MOD;
                e >>= 1;
            }
            return res;
        }
    }
}