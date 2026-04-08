namespace DailyQuestion
{
    public class XORAfterRangeMultiplicationQueriesI
    {
        public int ComputeXorAfterApplyingQueries(int[] numbers, int[][] queries)
        {
            const int MODULO = 1_000_000_007;

            foreach (var currentQuery in queries)
            {
                int leftIndex = currentQuery[0];
                int rightIndex = currentQuery[1];
                int stepSize = currentQuery[2];
                int multiplier = currentQuery[3];

                for (int currentIndex = leftIndex; currentIndex <= rightIndex; currentIndex += stepSize)
                {
                    long updatedValue = (long)numbers[currentIndex] * multiplier % MODULO;
                    numbers[currentIndex] = (int)updatedValue;
                }
            }

            int xorResult = 0;

            foreach (int currentNumber in numbers)
            {
                xorResult ^= currentNumber;
            }

            return xorResult;
        }
    }
}