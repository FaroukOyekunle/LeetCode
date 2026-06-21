namespace DailyQuestion
{
    public class MaximumIceCreamBars
    {
        public int MaxIceCream(int[] iceCreamCosts, int availableCoins)
        {
            int highestIceCreamCost = 0;

            foreach (int currentIceCreamCost in iceCreamCosts)
            {
                highestIceCreamCost = Math.Max(highestIceCreamCost, currentIceCreamCost);
            }

            int[] iceCreamCountByCost = new int[highestIceCreamCost + 1];

            foreach (int currentIceCreamCost in iceCreamCosts)
            {
                iceCreamCountByCost[currentIceCreamCost]++;
            }

            int totalPurchasedIceCreams = 0;

            for (int candidateCost = 1; candidateCost <= highestIceCreamCost; candidateCost++)
            {
                if (iceCreamCountByCost[candidateCost] == 0)
                {
                    continue;
                }

                int maximumAffordableQuantity = Math.Min(iceCreamCountByCost[candidateCost], availableCoins / candidateCost);

                totalPurchasedIceCreams += maximumAffordableQuantity;

                availableCoins -= maximumAffordableQuantity * candidateCost;

                if (ailableCoins < candidateCost)
                {
                    break;
                }
            }

            return totalPurchasedIceCreams;
        }
    }
}