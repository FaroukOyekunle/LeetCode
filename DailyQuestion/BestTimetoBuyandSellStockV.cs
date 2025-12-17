namespace DailyQuestion
{
    public class BestTimetoBuyandSellStockV
    {
        public long MaximumProfit(int[] stockPrices, int maxTransactions)
        {
            const long NEGATIVE_INFINITY = long.MinValue / 4;

            long[,] transactionStates = new long[maxTransactions + 1, 3];

            for(int transactionCount = 0; transactionCount <= maxTransactions; transactionCount++)
            {
                transactionStates[transactionCount, 0] = 0;
                transactionStates[transactionCount, 1] = NEGATIVE_INFINITY;
                transactionStates[transactionCount, 2] = NEGATIVE_INFINITY;
            }

            foreach(int currentPrice in stockPrices)
            {
                long[,] nextTransactionStates = new long[maxTransactions + 1, 3];

                for(int transactionCount = 0; transactionCount <= maxTransactions; transactionCount++)
                {
                    nextTransactionStates[transactionCount, 0] = transactionStates[transactionCount, 0];
                    nextTransactionStates[transactionCount, 1] = transactionStates[transactionCount, 1];
                    nextTransactionStates[transactionCount, 2] = transactionStates[transactionCount, 2];
                }

                for(int transactionCount = 0; transactionCount <= maxTransactions; transactionCount++)
                {
                    nextTransactionStates[transactionCount, 1] = Math.Max(nextTransactionStates[transactionCount, 1], transactionStates[transactionCount, 0] - currentPrice);
                    nextTransactionStates[transactionCount, 2] = Math.Max(nextTransactionStates[transactionCount, 2], transactionStates[transactionCount, 0] + currentPrice);

                    if(transactionCount + 1 <= maxTransactions)
                    {
                        nextTransactionStates[transactionCount + 1, 0] = Math.Max(nextTransactionStates[transactionCount + 1, 0], transactionStates[transactionCount, 1] + currentPrice);
                        nextTransactionStates[transactionCount + 1, 0] = Math.Max(nextTransactionStates[transactionCount + 1, 0], transactionStates[transactionCount, 2] - currentPrice);
                    }
                }

                transactionStates = nextTransactionStates;
            }

            long maximumProfit = 0;
            for(int transactionCount = 0; transactionCount <= maxTransactions; transactionCount++)
            {
                maximumProfit = Math.Max(maximumProfit, transactionStates[transactionCount, 0]);
            }

            return maximumProfit;
        }
    }
}