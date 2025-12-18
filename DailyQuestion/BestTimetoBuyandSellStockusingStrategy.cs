namespace DailyQuestion
{
    public class BestTimetoBuyandSellStockusingStrategy
    {
        public long MaxProfit(int[] stockPrices, int[] tradingStrategy, int windowSize)
        {
            int totalDays = stockPrices.Length;
            int halfWindow = windowSize / 2;

            long initialProfit = 0;
            for (int dayIndex = 0; dayIndex < totalDays; dayIndex++)
            {
                initialProfit += (long)tradingStrategy[dayIndex] * stockPrices[dayIndex];
            }

            long[] lossArray = new long[totalDays];
            long[] gainArray = new long[totalDays];

            for (int dayIndex = 0; dayIndex < totalDays; dayIndex++)
            {
                long currentProfit = (long)tradingStrategy[dayIndex] * stockPrices[dayIndex];
                lossArray[dayIndex] = -currentProfit;
                gainArray[dayIndex] = stockPrices[dayIndex] - currentProfit;
            }

            long[] lossPrefixSum = new long[totalDays + 1];
            long[] gainPrefixSum = new long[totalDays + 1];

            for (int dayIndex = 0; dayIndex < totalDays; dayIndex++)
            {
                lossPrefixSum[dayIndex + 1] = lossPrefixSum[dayIndex] + lossArray[dayIndex];
                gainPrefixSum[dayIndex + 1] = gainPrefixSum[dayIndex] + gainArray[dayIndex];
            }

            long maximumDelta = 0;

            for (int leftIndex = 0; leftIndex + windowSize <= totalDays; leftIndex++)
            {
                int middleIndex = leftIndex + halfWindow;
                int rightIndex = leftIndex + windowSize;

                long currentDelta =
                    (lossPrefixSum[middleIndex] - lossPrefixSum[leftIndex]) +
                    (gainPrefixSum[rightIndex] - gainPrefixSum[middleIndex]);

                maximumDelta = Math.Max(maximumDelta, currentDelta);
            }

            return initialProfit + maximumDelta;
        }
    }
}