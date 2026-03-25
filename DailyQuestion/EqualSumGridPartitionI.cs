namespace DailyQuestion
{
    public class EqualSumGridPartitionI
    {
        public bool CanPartitionGridIntoEqualSumSections(int[][] inputGrid)
        {
            int totalRowCount = inputGrid.Length;
            int totalColumnCount = inputGrid[0].Length;

            long totalGridSum = 0;

            for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
                {
                    totalGridSum += inputGrid[rowIndex][columnIndex];
                }
            }

            if (totalGridSum % 2 != 0)
            {
                return false;
            }

            long targetHalfSum = totalGridSum / 2;

            long cumulativeRowSum = 0;

            for (int rowIndex = 0; rowIndex < totalRowCount - 1; rowIndex)
            {
                for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
                {
                    cumulativeRowSum += inputGrid[rowIndex][columnIndex];
                }

                if (cumulativeRowSum == targetHalfSum)
                {
                    return true;
                }
            }

            long[] columnWiseSums = new long[totalColumnCount];

            for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
                {
                    columnWiseSums[columnIndex] += inputGrid[rowIndex][columnIndex];
                }
            }

            long cumulativeColumnSum = 0;

            for (int columnIndex = 0; columnIndex < totalColumnCount - 1; columnIndex++)
            {
                cumulativeColumnSum += columnWiseSums[columnIndex];

                if (cumulativeColumnSum == targetHalfSum)
                {
                    return true;
                }
            }

            return false;
        }
    }
}