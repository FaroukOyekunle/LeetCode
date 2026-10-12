namespace DailyQuestion
{
    public class ApplyOperationsonArraytoMaximizeSumofSquares
    {
        public int MaxSum(IList<int> numbers, int numberOfElementsToSelect)
        {
            const long ModuloDivisor = 1_000_000_007;
            const int TotalBitPositions = 31;

            int[] frequencyByBitPosition = new int[TotalBitPositions];

            foreach (int currentNumber in numbers)
            {
                for (int currentBitPosition = 0; currentBitPosition < TotalBitPositions; currentBitPosition++)
                {
                    if ((currentNumber & (1 << currentBitPosition)) != 0)
                    {
                        frequencyByBitPosition[currentBitPosition]++;
                    }
                }
            }

            long maximumSumOfSquaredNumbers = 0;

            for (int selectedNumberIndex = 0; selectedNumberIndex < numberOfElementsToSelect; selectedNumberIndex++)
            {
                long reconstructedNumberFromAvailableBits = 0;

                for (int currentBitPosition = 0; currentBitPosition < TotalBitPositions; currentBitPosition++)
                {
                    if (frequencyByBitPosition[currentBitPosition] > 0)
                    {
                        reconstructedNumberFromAvailableBits |= 1L << currentBitPosition;

                        frequencyByBitPosition[currentBitPosition]--;
                    }
                }

                maximumSumOfSquaredNumbers = (maximumSumOfSquaredNumbers + reconstructedNumberFromAvailableBits * reconstructedNumberFromAvailableBits) % ModuloDivisor;
            }

            return (int)maximumSumOfSquaredNumbers;
        }
    }
}