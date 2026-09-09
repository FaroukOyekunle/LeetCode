namespace DailyQuestion
{
    public class CountCommasinRangeII
    {
        public long CountCommas(long maximumNumber)
        {
            long totalCommaCount = 0;
            long currentCommaThreshold = 1_000;

            while (currentCommaThreshold <= maximumNumber)
            {
                totalCommaCount += maximumNumber - currentCommaThreshold + 1;
                currentCommaThreshold *= 1_000;
            }

            return totalCommaCount;
        }
    }
}