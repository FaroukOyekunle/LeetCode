namespace DailyQuestion
{
    public class Shift2DGrid
    {
        public IList<IList<int>> ShiftGrid(int[][] grid, int shiftCount)
        {
            int totalRowCount = grid.Length;
            int totalColumnCount = grid[0].Length;

            int totalGridCellCount = totalRowCount * totalColumnCount;

            shiftCount %= totalGridCellCount;

            int[][] shiftedGrid = new int[totalRowCount][];

            for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
            {
                shiftedGrid[rowIndex] = new int[totalColumnCount];
            }

            for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
                {
                    int currentLinearIndex = rowIndex * totalColumnCount + columnIndex;

                    int shiftedLinearIndex = (currentLinearIndex + shiftCount) % totalGridCellCount;

                    int destinationRowIndex = shiftedLinearIndex / totalColumnCount;

                    int destinationColumnIndex = shiftedLinearIndex % totalColumnCount;

                    shiftedGrid[destinationRowIndex][destinationColumnIndex] = grid[rowIndex][columnIndex];
                }
            }

            IList<IList<int>> shiftedGridResult = new List<IList<int>>();

            foreach (int[] shiftedGridRow in shiftedGrid)
            {
                shiftedGridResult.Add(shiftedGridRow.ToList());
            }

            return shiftedGridResult;
        }
    }
}