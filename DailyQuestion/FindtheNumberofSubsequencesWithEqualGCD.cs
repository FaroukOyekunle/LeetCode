namespace DailyQuestion
{
    public class FindtheNumberofSubsequencesWithEqualGCD
    {
        private const int Modulo = 1_000_000_007;
        private const int MaximumPossibleGcdValue = 200;

        public int SubsequencePairCount(int[] numbers)
        {
            long[,] gcdPairCount = new long[MaximumPossibleGcdValue + 1, MaximumPossibleGcdValue + 1];

            gcdPairCount[0, 0] = 1;

            foreach (int currentNumber in numbers)
            {
                long[,] updatedGcdPairCount = new long[MaximumPossibleGcdValue + 1, MaximumPossibleGcdValue + 1];

                for (int firstSubsequenceGcd = 0; firstSubsequenceGcd <= MaximumPossibleGcdValue; firstSubsequenceGcd++)
                {
                    for (int secondSubsequenceGcd = 0; secondSubsequenceGcd <= MaximumPossibleGcdValue; secondSubsequenceGcd++)
                    {
                        long currentArrangementCount = gcdPairCount[firstSubsequenceGcd, secondSubsequenceGcd];

                        if (currentArrangementCount == 0)
                        {
                            continue;
                        }

                        updatedGcdPairCount[firstSubsequenceGcd, secondSubsequenceGcd] = (updatedGcdPairCount[firstSubsequenceGcd, secondSubsequenceGcd] + currentArrangementCount) % Modulo;

                        int updatedFirstSubsequenceGcd = firstSubsequenceGcd == 0 ? currentNumber : CalculateGreatestCommonDivisor(firstSubsequenceGcd, currentNumber);

                        updatedGcdPairCount[updatedFirstSubsequenceGcd, secondSubsequenceGcd] = (updatedGcdPairCount[updatedFirstSubsequenceGcd, secondSubsequenceGcd] + currentArrangementCount) % Modulo;

                        int updatedSecondSubsequenceGcd = secondSubsequenceGcd == 0 ? currentNumber : CalculateGreatestCommonDivisor(secondSubsequenceGcd, currentNumber);

                        updatedGcdPairCount[firstSubsequenceGcd, updatedSecondSubsequenceGcd] = (updatedGcdPairCount[firstSubsequenceGcd, updatedSecondSubsequenceGcd] + currentArrangementCount) % Modulo;
                    }
                }

                gcdPairCount = updatedGcdPairCount;
            }

            long matchingSubsequencePairCount = 0;

            for (int commonGcdValue = 1; commonGcdValue <= MaximumPossibleGcdValue; commonGcdValue++)
            {
                matchingSubsequencePairCount = (matchingSubsequencePairCount + gcdPairCount[commonGcdValue, commonGcdValue]) % Modulo;
            }

            return (int)matchingSubsequencePairCount;
        }

        private int CalculateGreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                int divisionRemainder = firstNumber % secondNumber;

                firstNumber = secondNumber;
                secondNumber = divisionRemainder;
            }

            return firstNumber;
        }
    }
}