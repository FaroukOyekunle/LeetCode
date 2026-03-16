namespace DailyQuestion
{
    public class GetBiggestThreeRhombusSumsinaGrid
    {
        public int[] GetThreeLargestRhombusSums(int[][] grid)
        {
            int totalRows = grid.Length;
            int totalColumns = grid[0].Length;

            SortedSet<int> uniqueRhombusSums = new SortedSet<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            for (int row = 0; row < totalRows; row++)
            {
                for (int column = 0; column < totalColumns; column++)
                {
                    uniqueRhombusSums.Add(grid[row][column]);

                    int maxRhombusSize = Math.Min(
                        Math.Min(totalRows - 1 - row, column),
                        Math.Min(totalColumns - 1 - column, totalRows - 1 - row)
                    );

                    for (int size = 1; row + 2 * size < totalRows && column - size >= 0 && column + size < totalColumns; size++)
                    {
                        int rhombusSum = 0;

                        int topRow = row;
                        int topColumn = column;

                        for (int i = 0; i < size; i++)
                        {
                            rhombusSum += grid[topRow + i][topColumn - i];
                        }

                        for (int i = 0; i < size; i++)
                        {
                            rhombusSum += grid[topRow + size + i][topColumn - size + i];
                        }

                        for (int i = 0; i < size; i++)
                        {
                            rhombusSum += grid[topRow + 2 * size - i][topColumn + i];
                        }

                        for (int i = 0; i < size; i++)
                        {
                            rhombusSum += grid[topRow + size - i][topColumn + size - i];
                        }

                        uniqueRhombusSums.Add(rhombusSum);
                    }
                }
            }

            return uniqueRhombusSums.Take(3).ToArray();
        }
    }
}