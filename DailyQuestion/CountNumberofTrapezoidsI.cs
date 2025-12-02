namespace DailyQuestion
{
    public class CountNumberofTrapezoidsI
    {
        public int CountTrapezoids(int[][] points)
        {
            const long MOD = 1_000_000_007;

            Dictionary<int, long> pointsPerY = new();
            foreach(var point in points)
            {
                int y = point[1];

                if(!pointsPerY.ContainsKey(y))
                {
                    pointsPerY[y] = 0;
                }
                pointsPerY[y]++;
            }

            List<long> pairsPerY = new();

            foreach(var entry in pointsPerY)
            {
                long countAtY = entry.Value;
                if(countAtY >= 2)
                {
                    long pairCount = (countAtY * (countAtY - 1) / 2) % MOD;
                    pairsPerY.Add(pairCount);
                }
            }

            if(pairsPerY.Count < 2)
            {
                return 0;
            }

            long trapezoidCount = 0;
            long remainingPairs = 0;

            foreach(long pairCount in pairsPerY)
            {
                remainingPairs = (remainingPairs + pairCount) % MOD;
            }

            foreach(long pairCount in pairsPerY)
            {
                remainingPairs = (remainingPairs - pairCount + MOD) % MOD;
                trapezoidCount = (trapezoidCount + (pairCount * remainingPairs) % MOD) % MOD;
            }

            return (int)(trapezoidCount % MOD);
        }
    }
}