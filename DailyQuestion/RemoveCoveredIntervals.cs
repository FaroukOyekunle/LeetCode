namespace DailyQuestion
{
    public class RemoveCoveredIntervals
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            Array.Sort(intervals, (currentInterval, comparisonInterval) =>
            {
                if (currentInterval[0] == comparisonInterval[0])
                {
                    return comparisonInterval[1].CompareTo(currentInterval[1]);
                }

                return currentInterval[0].CompareTo(comparisonInterval[0]);
            });

            int uncoveredIntervalCount = 0;

            int farthestEndingPointSeen = -1;

            foreach (int[] interval in intervals)
            {
                int intervalStart = interval[0];
                int intervalEnd = interval[1];

                if (intervalEnd > farthestEndingPointSeen)
                {
                    uncoveredIntervalCount++;

                    farthestEndingPointSeen = intervalEnd;
                }
            }

            return uncoveredIntervalCount;
        }
    }
}