using System;

namespace DailyQuestion
{
    public class MinimumCosttoAcquireRequiredItems
    {
        public long MinimumCost(int type1ItemCost, int type2ItemCost, int sharedItemCost, int requiredType1ItemCount, int requiredType2ItemCount)
        {
            long sharedItemCount = Math.Min(requiredType1ItemCount, requiredType2ItemCount);

            long minimumTotalCost = sharedItemCount * Math.Min(sharedItemCost, type1ItemCost + type2ItemCost);

            long remainingType1ItemCount = requiredType1ItemCount - sharedItemCount;
            long remainingType2ItemCount = requiredType2ItemCount - sharedItemCount;

            minimumTotalCost += remainingType1ItemCount * Math.Min(type1ItemCost, sharedItemCost);

            minimumTotalCost += remainingType2ItemCount * Math.Min(type2ItemCost, sharedItemCost);

            return minimumTotalCost;
        }
    }
}