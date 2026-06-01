namespace DailyQuestion
{
    public class MinimumCostofBuyingCandiesWithDiscount
    {
        public int MinimumCost(int[] candyCosts)
        {
            Array.Sort(candyCosts);
            Array.Reverse(candyCosts);

            int totalPurchaseCost = 0;

            for (int candyIndex = 0; candyIndex < candyCosts.Length; candyIndex++)
            {
                bool isFreeCandy = (candyIndex + 1) % 3 == 0;

                if (!isFreeCandy)
                {
                    totalPurchaseCost += candyCosts[candyIndex];
                }
            }

            return totalPurchaseCost;
        }
    }
}