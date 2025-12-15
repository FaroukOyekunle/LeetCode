namespace DailyQuestion
{
    public class NumberofSmoothDescentPeriodsofaStock
    {
        public long GetDescentPeriods(int[] stockPrices)
        {
            long totalDescentPeriods = 0;
            long currentDescentLength = 1;

            for (int currentIndex = 0; currentIndex < stockPrices.Length; currentIndex++)
            {
                if (currentIndex > 0 && stockPrices[currentIndex - 1] - stockPrices[currentIndex] == 1)
                {
                    currentDescentLength++;
                }

                else
                {
                    currentDescentLength = 1;
                }

                totalDescentPeriods += currentDescentLength;
            }

            return totalDescentPeriods;
        }
    }
}