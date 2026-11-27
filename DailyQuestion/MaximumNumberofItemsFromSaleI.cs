using System;

namespace DailyQuestion
{
    public class MaximumNumberofItemsFromSaleI
    {
        public int MaximumSaleItems(int[][] items, int budget)
        {
            int totalNumberOfItems = items.Length;

            int lowestPricedItemIndex = 0;
            int lowestItemPrice = int.MaxValue;

            const int ItemFactorIndex = 0;
            const int ItemPriceIndex = 1;

            for (int currentItemIndex = 0; currentItemIndex < totalNumberOfItems; currentItemIndex++)
            {
                int currentItemPrice = items[currentItemIndex][ItemPriceIndex];

                if (currentItemPrice < lowestItemPrice)
                {
                    lowestItemPrice = currentItemPrice;
                    lowestPricedItemIndex = currentItemIndex;
                }
            }

            int[] freeItemCountByPurchasedItem = new int[totalNumberOfItems];

            for (int purchasedItemIndex = 0; purchasedItemIndex < totalNumberOfItems; purchasedItemIndex++)
            {
                int purchasedItemFactor = items[purchasedItemIndex][ItemFactorIndex];

                for (int candidateFreeItemIndex = 0; candidateFreeItemIndex < totalNumberOfItems; candidateFreeItemIndex++)
                {
                    if (purchasedItemIndex == candidateFreeItemIndex)
                    {
                        continue;
                    }

                    int candidateFreeItemFactor = items[candidateFreeItemIndex][ItemFactorIndex];

                    if (candidateFreeItemFactor % purchasedItemFactor == 0)
                    {
                        freeItemCountByPurchasedItem[purchasedItemIndex]++;
                    }
                }
            }

            int[] maximumItemCountByBudget = new int[budget + 1];

            for (int currentItemIndex = 0; currentItemIndex < totalNumberOfItems; currentItemIndex++)
            {
                if (currentItemIndex == lowestPricedItemIndex)
                {
                    continue;
                }

                int currentItemPrice = items[currentItemIndex][ItemPriceIndex];

                int totalItemCountIncludingFreeItems = 1 + freeItemCountByPurchasedItem[currentItemIndex];

                for (int availableBudget = budget; availableBudget >= currentItemPrice; availableBudget--)
                {
                    int maximumItemCountWithoutCurrentItem = maximumItemCountByBudget[availableBudget];

                    int maximumItemCountWithCurrentItem = maximumItemCountByBudget[availableBudget - currentItemPrice] + totalItemCountIncludingFreeItems;

                    maximumItemCountByBudget[availableBudget] = Math.Max(maximumItemCountWithoutCurrentItem, maximumItemCountWithCurrentItem);
                }
            }

            int maximumNumberOfItemsObtainable = 0;

            for (int budgetSpentOnSelectedItems = 0; budgetSpentOnSelectedItems <= budget; budgetSpentOnSelectedItems++)
            {
                int remainingBudgetAfterSelectedItems = budget - budgetSpentOnSelectedItems;

                int itemCountFromSelectedItems = maximumItemCountByBudget[budgetSpentOnSelectedItems];

                maximumNumberOfItemsObtainable = Math.Max(maximumNumberOfItemsObtainable, itemCountFromSelectedItems);

                if (remainingBudgetAfterSelectedItems >= lowestItemPrice)
                {
                    int numberOfCheapestItemsPurchasable = remainingBudgetAfterSelectedItems / lowestItemPrice;

                    int totalItemCountIncludingCheapestItemAndFreeItems = itemCountFromSelectedItems + numberOfCheapestItemsPurchasable + freeItemCountByPurchasedItem[lowestPricedItemIndex];

                    maximumNumberOfItemsObtainable = Math.Max(maximumNumberOfItemsObtainable, totalItemCountIncludingCheapestItemAndFreeItems);
                }
            }

            return maximumNumberOfItemsObtainable;
        }
    }
}