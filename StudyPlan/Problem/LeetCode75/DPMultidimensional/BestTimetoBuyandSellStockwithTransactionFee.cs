namespace StudyPlan.Problem.LeetCode75.DPMultidimensional
{
    public class BestTimetoBuyandSellStockwithTransactionFee
    {
        public int MaxProfit(int[] prices, int fee) 
        {
            int n = prices.Length;
            int cash = 0, hold = -prices[0];
            
            for(int i = 1; i < n; i++) 
            {
                int prevCash = cash, prevHold = hold;

                cash = Math.Max(prevCash, prevHold + prices[i] - fee);

                hold = Math.Max(prevHold, prevCash - prices[i]);
            }
            
            return cash;
        }
    }
}