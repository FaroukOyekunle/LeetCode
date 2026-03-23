namespace DailyQuestion
{
    public class MaximumNonNegativeProductinaMatrix
    {
        public int FindMaximumNonNegativeProductPath(int[][] inputGrid)
        {
            int totalRows = inputGrid.Length;
            int totalColumns = inputGrid[0].Length;

            long[,] maxProductToCell = new long[totalRows, totalColumns];

            long[,] minProductToCell = new long[totalRows, totalColumns];

            maxProductToCell[0, 0] = inputGrid[0][0];
            minProductToCell[0, 0] = inputGrid[0][0];

            for (int rowIndex = 1; rowIndex < totalRows; rowIndex++)
            {
                long currentCellValue = inputGrid[rowIndex][0];

                maxProductToCell[rowIndex, 0] = maxProductToCell[rowIndex - 1, 0] * currentCellValue;

                minProductToCell[rowIndex, 0] =  maxProductToCell[rowIndex, 0];
            }

            for (int columnIndex = 1; columnIndex < totalColumns; columnIndex++)
            {
                long currentCellValue = inputGrid[0][columnIndex];

                maxProductToCell[0, columnIndex] =  maxProductToCell[0, columnIndex - 1] * currentCellValue;

                minProductToCell[0, columnIndex] = maxProductToCell[0, columnIndex];
            }

            for (int rowIndex = 1; rowIndex < totalRows; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex < totalColumns; columnIndex++)
                {
                    long currentCellValue = inputGrid[rowIndex][columnIndex];

                    long productFromTopUsingMax = currentCellValue * maxProductToCell[rowIndex - 1, columnIndex];

                    long productFromTopUsingMin = currentCellValue * minProductToCell[rowIndex - 1, columnIndex];

                    long productFromLeftUsingMax = currentCellValue * maxProductToCell[rowIndex, columnIndex - 1];

                    long productFromLeftUsingMin = currentCellValue * minProductToCell[rowIndex, columnIndex - 1];

                    maxProductToCell[rowIndex, columnIndex] =
                        Math.Max(
                            Math.Max(productFromTopUsingMax, productFromTopUsingMin),
                            Math.Max(productFromLeftUsingMax, productFromLeftUsingMin)
                        );

                    minProductToCell[rowIndex, columnIndex] =
                        Math.Min(
                            Math.Min(productFromTopUsingMax, productFromTopUsingMin),
                            Math.Min(productFromLeftUsingMax, productFromLeftUsingMin)
                        );
                }
            }

            long finalMaximumProduct = maxProductToCell[totalRows - 1, totalColumns - 1];

            if (finalMaximumProduct < 0)
            {
                return -1;
            }

            const int modulo = 1_000_000_007;

            return (int)(finalMaximumProduct % modulo);
        }
    }
}