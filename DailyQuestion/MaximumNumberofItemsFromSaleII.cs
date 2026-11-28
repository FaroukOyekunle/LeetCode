using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class MaximumNumberofItemsFromSaleI
    {
        public int MaximumSaleItems(int[][] items, int budget)
        {
            const int ItemFactorIndex = 0;
            const int ItemPriceIndex = 1;

            int totalNumberOfItems = items.Length;
            int lowestItemPrice = int.MaxValue;

            int[] itemCountByFactor = new int[totalNumberOfItems + 1];

            foreach (int[] currentItem in items)
            {
                int currentItemFactor = currentItem[ItemFactorIndex];
                int currentItemPrice = currentItem[ItemPriceIndex];

                itemCountByFactor[currentItemFactor]++;

                lowestItemPrice = Math.Min(lowestItemPrice, currentItemPrice);
            }

            int[] freeItemCountByFactor = new int[totalNumberOfItems + 1];

            for (int currentFactor = 1; currentFactor <= totalNumberOfItems; currentFactor++)
            {
                if (itemCountByFactor[currentFactor] == 0)
                {
                    continue;
                }

                int totalNumberOfItemsWithDivisibleFactors = 0;

                for (int divisibleFactor = currentFactor; divisibleFactor <= totalNumberOfItems; divisibleFactor += currentFactor)
                {
                    totalNumberOfItemsWithDivisibleFactors += itemCountByFactor[divisibleFactor];
                }

                freeItemCountByFactor[currentFactor] = totalNumberOfItemsWithDivisibleFactors - 1;
            }

            long maximumPriceForDoubleItemValue = 2L * lowestItemPrice;

            List<(int PurchasePrice, int MaximumPurchasableCopies)> profitablePurchases = new();

            foreach (int[] currentItem in items)
            {
                int currentItemFactor = currentItem[ItemFactorIndex];
                int currentItemPrice = currentItem[ItemPriceIndex];

                int availableFreeItemCount = freeItemCountByFactor[currentItemFactor];

                if (availableFreeItemCount > 0 && currentItemPrice <= maximumPriceForDoubleItemValue)
                {
                    profitablePurchases.Add((currentItemPrice, availableFreeItemCount));
                }
            }

            profitablePurchases.Sort((firstPurchase, secondPurchase) => firstPurchase.PurchasePrice.CompareTo(secondPurchase.PurchasePrice));

            long maximumNumberOfItemsObtainable = 0;
            long remainingBudget = budget;

            foreach (var currentPurchase in profitablePurchases)
            {
                if (remainingBudget < currentPurchase.PurchasePrice)
                {
                    break;
                }

                long numberOfCopiesToPurchase = Math.Min(currentPurchase.MaximumPurchasableCopies, remainingBudget / currentPurchase.PurchasePrice);

                maximumNumberOfItemsObtainable += numberOfCopiesToPurchase * 2;

                remainingBudget -= numberOfCopiesToPurchase * currentPurchase.PurchasePrice;
            }

            maximumNumberOfItemsObtainable +=  remainingBudget / lowestItemPrice;

            return (int)maximumNumberOfItemsObtainable;
        }
    }
}