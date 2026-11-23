using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class ProductoftheLastKNumbers
    {
        public class ProductOfNumbers
        {
            private readonly List<int> cumulativeProductsSinceLastZero;

            public ProductOfNumbers()
            {
                cumulativeProductsSinceLastZero = new List<int> { 1 };
            }

            public void Add(int number)
            {
                if (number == 0)
                {
                    cumulativeProductsSinceLastZero.Clear();
                    cumulativeProductsSinceLastZero.Add(1);
                    return;
                }

                int previousCumulativeProduct = cumulativeProductsSinceLastZero[^1];

                int currentCumulativeProduct = previousCumulativeProduct * number;

                cumulativeProductsSinceLastZero.Add(currentCumulativeProduct);
            }

            public int GetProduct(int requestedNumberCount)
            {
                int availableNumberCountSinceLastZero = cumulativeProductsSinceLastZero.Count - 1;

                if (requestedNumberCount > availableNumberCountSinceLastZero)
                {
                    return 0;
                }

                int latestCumulativeProduct = cumulativeProductsSinceLastZero[^1];

                int cumulativeProductBeforeRequestedRange = cumulativeProductsSinceLastZero[availableNumberCountSinceLastZero - requestedNumberCount];

                return latestCumulativeProduct / cumulativeProductBeforeRequestedRange;
            }
        }
    }
    /**
         * Your ProductOfNumbers object will be instantiated and called as such:
         * ProductOfNumbers obj = new ProductOfNumbers();
         * obj.Add(num);
         * int param_2 = obj.GetProduct(k);
     */
}