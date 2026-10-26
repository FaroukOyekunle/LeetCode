using System;

namespace DailyQuestion
{
    public class CountIslandsWithTotalValueDivisiblebyK
    {
        public int CountIslands(int[][] grid, int divisor)
        {
            int totalRowCount = grid.Length;
            int totalColumnCount = grid[0].Length;
            int totalQualifyingIslandCount = 0;

            for (int currentRowIndex = 0; currentRowIndex < totalRowCount; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < totalColumnCount; currentColumnIndex++)
                {
                    if (grid[currentRowIndex][currentColumnIndex] > 0)
                    {
                        long currentIslandTotalValue = CalculateIslandValue(grid, currentRowIndex, currentColumnIndex, totalRowCount, totalColumnCount);

                        if (currentIslandTotalValue % divisor == 0)
                        {
                            totalQualifyingIslandCount++;
                        }
                    }
                }
            }

            return totalQualifyingIslandCount;
        }

        private long CalculateIslandValue(int[][] grid, int currentRowIndex, int currentColumnIndex, int totalRowCount, int totalColumnCount)
        {
            if (currentRowIndex < 0 || currentRowIndex >= totalRowCount || currentColumnIndex < 0 || currentColumnIndex >= totalColumnCount || grid[currentRowIndex][currentColumnIndex] == 0)
            {
                return 0;
            }

            int currentCellValue = grid[currentRowIndex][currentColumnIndex];
            grid[currentRowIndex][currentColumnIndex] = 0;

            long islandTotalValue = currentCellValue;

            islandTotalValue += CalculateIslandValue(grid, currentRowIndex - 1, currentColumnIndex, totalRowCount, totalColumnCount);

            islandTotalValue += CalculateIslandValue(grid, currentRowIndex + 1, currentColumnIndex, totalRowCount, totalColumnCount);

            islandTotalValue += CalculateIslandValue(grid, currentRowIndex, currentColumnIndex - 1, totalRowCount, totalColumnCount);

            islandTotalValue += CalculateIslandValue(grid, currentRowIndex, currentColumnIndex + 1, totalRowCount, totalColumnCount);

            return islandTotalValue;
        }
    }
}