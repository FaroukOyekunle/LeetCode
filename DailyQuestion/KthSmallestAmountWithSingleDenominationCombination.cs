namespace DailyQuestion
{
    public class KthSmallestAmountWithSingleDenominationCombination
    {
        public long FindKthSmallest(int[] coins, int k)
        {
            long minimumPossibleAmount = 1;

            long smallestCoinValue = coins.Min();
            long maximumPossibleAmount = smallestCoinValue * (long)k;

            while (minimumPossibleAmount < maximumPossibleAmount)
            {
                long candidateAmount = minimumPossibleAmount + (maximumPossibleAmount - minimumPossibleAmount) / 2;

                long numberOfValidAmounts = CountValidAmountsUpTo(coins, candidateAmount);

                if (numberOfValidAmounts >= k)
                {
                    maximumPossibleAmount = candidateAmount;
                }
                else
                {
                    minimumPossibleAmount = candidateAmount + 1;
                }
            }

            return minimumPossibleAmount;
        }

        private long CountValidAmountsUpTo(int[] coinValues, long maximumAmount)
        {
            int totalCoinCount = coinValues.Length;
            int totalSubsetCount = 1 << totalCoinCount;

            long validAmountCount = 0;

            for (int subsetMask = 1; subsetMask < totalSubsetCount; subsetMask++)
            {
                long subsetLeastCommonMultiple = 1;
                int selectedCoinCount = 0;
                bool leastCommonMultipleExceedsMaximumAmount = false;

                for (int coinIndex = 0; coinIndex < totalCoinCount; coinIndex++)
                {
                    bool coinIsSelected = (subsetMask & (1 << coinIndex)) != 0;

                    if (!coinIsSelected)
                    {
                        continue;
                    }

                    selectedCoinCount++;

                    subsetLeastCommonMultiple = LeastCommonMultiple(subsetLeastCommonMultiple, coinValues[coinIndex]);

                    if (subsetLeastCommonMultiple > maximumAmount)
                    {
                        leastCommonMultipleExceedsMaximumAmount = true;
                        break;
                    }
                }

                if (leastCommonMultipleExceedsMaximumAmount)
                {
                    continue;
                }

                long numberOfMultiples = maximumAmount / subsetLeastCommonMultiple;

                if (selectedCoinCount % 2 == 1)
                {
                    validAmountCount += numberOfMultiples;
                }
                else
                {
                    validAmountCount -= numberOfMultiples;
                }
            }

            return validAmountCount;
        }

        private long LeastCommonMultiple(long firstNumber, long secondNumber)
        {
            return firstNumber / GreatestCommonDivisor(firstNumber, secondNumber) * secondNumber;
        }

        private long GreatestCommonDivisor(long firstNumber, long secondNumber)
        {
            while (secondNumber != 0)
            {
                long remainderAfterDivision = firstNumber % secondNumber;

                firstNumber = secondNumber;
                secondNumber = remainderAfterDivision;
            }

            return firstNumber;
        }
    }
}