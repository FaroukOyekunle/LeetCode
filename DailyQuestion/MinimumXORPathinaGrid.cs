using System;

namespace DailyQuestion
{
    public class MinimumXORPathinaGrid
    {
        public int MinCost(int[][] grid)
        {
            int totalRowCount = grid.Length;
            int totalColumnCount = grid[0].Length;

            const int totalPossibleXorValues = 1024;

            bool[,,] reachableXorValuesByCell = new bool[totalRowCount, totalColumnCount, totalPossibleXorValues];

            reachableXorValuesByCell[0, 0, grid[0][0]] = true;

            for (int currentRowIndex = 0; currentRowIndex < totalRowCount; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < totalColumnCount; currentColumnIndex++)
                {
                    if (currentRowIndex == 0 && currentColumnIndex == 0)
                    {
                        continue;
                    }

                    int currentCellValue = grid[currentRowIndex][currentColumnIndex];

                    if (currentRowIndex > 0)
                    {
                        for (int previousPathXorValue = 0; previousPathXorValue < totalPossibleXorValues; previousPathXorValue++)
                        {
                            if (reachableXorValuesByCell[currentRowIndex - 1, currentColumnIndex, previousPathXorValue])
                            {
                                int updatedPathXorValue = previousPathXorValue ^ currentCellValue;

                                reachableXorValuesByCell[currentRowIndex, currentColumnIndex, updatedPathXorValue] = true;
                            }
                        }
                    }

                    if (currentColumnIndex > 0)
                    {
                        for (int previousPathXorValue = 0; previousPathXorValue < totalPossibleXorValues; previousPathXorValue++)
                        {
                            if (reachableXorValuesByCell[currentRowIndex, currentColumnIndex - 1, previousPathXorValue])
                            {
                                int updatedPathXorValue = previousPathXorValue ^ currentCellValue;

                                reachableXorValuesByCell[currentRowIndex, currentColumnIndex, updatedPathXorValue] = true;
                            }
                        }
                    }
                }
            }

            for (int candidateXorValue = 0; candidateXorValue < totalPossibleXorValues; candidateXorValue++)
            {
                if (reachableXorValuesByCell[totalRowCount - 1, totalColumnCount - 1, candidateXorValue])
                {
                    return candidateXorValue;
                }
            }

            return -1;
        }
    }
}