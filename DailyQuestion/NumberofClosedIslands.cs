using System;

namespace DailyQuestion
{
    public class NumberofClosedIslands
    {
        public int ClosedIsland(int[][] grid)
        {
            int totalRowCount = grid.Length;
            int totalColumnCount = grid[0].Length;
            int totalClosedIslandCount = 0;

            for (int currentRowIndex = 0; currentRowIndex < totalRowCount; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < totalColumnCount; currentColumnIndex++)
                {
                    if (grid[currentRowIndex][currentColumnIndex] == 0)
                    {
                        bool isCurrentIslandClosed = ExploreIsland(grid, currentRowIndex, currentColumnIndex, totalRowCount, totalColumnCount);

                        if (isCurrentIslandClosed)
                        {
                            totalClosedIslandCount++;
                        }
                    }
                }
            }

            return totalClosedIslandCount;
        }

        private bool ExploreIsland(int[][] grid, int currentRowIndex, int currentColumnIndex, int totalRowCount, int totalColumnCount)
        {
            if (currentRowIndex < 0 || currentRowIndex >= totalRowCount || currentColumnIndex < 0 || currentColumnIndex >= totalColumnCount)
            {
                return false;
            }

            if (grid[currentRowIndex][currentColumnIndex] == 1)
            {
                return true;
            }

            grid[currentRowIndex][currentColumnIndex] = 1;

            bool isIslandClosed = ExploreIsland(grid, currentRowIndex - 1, currentColumnIndex, totalRowCount, totalColumnCount);

            isIslandClosed &= ExploreIsland(grid, currentRowIndex + 1, currentColumnIndex, totalRowCount, totalColumnCount);

            isIslandClosed &= ExploreIsland(grid, currentRowIndex, currentColumnIndex - 1, totalRowCount, totalColumnCount);

            isIslandClosed &= ExploreIsland(grid, currentRowIndex, currentColumnIndex + 1, totalRowCount, totalColumnCount);

            return isIslandClosed;
        }
    }
}