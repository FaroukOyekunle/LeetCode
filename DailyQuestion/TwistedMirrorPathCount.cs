using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class TwistedMirrorPathCount
    {
        public int UniquePaths(int[][] grid)
        {
            const int ModuloDivisor = 1_000_000_007;

            int totalRowCount = grid.Length;
            int totalColumnCount = grid[0].Length;

            int[,] rightwardMirrorDestinationCache = new int[totalRowCount, totalColumnCount];

            int[,] downwardMirrorDestinationCache = new int[totalRowCount, totalColumnCount];

            for (int currentRowIndex = 0; currentRowIndex < totalRowCount; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < totalColumnCount; currentColumnIndex++)
                {
                    rightwardMirrorDestinationCache[currentRowIndex, currentColumnIndex] = -2;
                    downwardMirrorDestinationCache[currentRowIndex, currentColumnIndex] = -2;
                }
            }

            int ResolveMirrorDestination(int mirrorRowIndex, int mirrorColumnIndex, bool isMovingRight)
            {
                int[,] mirrorDestinationCache = isMovingRight ? rightwardMirrorDestinationCache : downwardMirrorDestinationCache;

                if (mirrorDestinationCache[mirrorRowIndex, mirrorColumnIndex] != -2)
                {
                    return mirrorDestinationCache[mirrorRowIndex, mirrorColumnIndex];
                }

                int nextRowIndex = isMovingRight ? mirrorRowIndex + 1 : mirrorRowIndex;

                int nextColumnIndex = isMovingRight ? mirrorColumnIndex : mirrorColumnIndex + 1;

                if (nextRowIndex >= totalRowCount || nextColumnIndex >= totalColumnCount)
                {
                    return mirrorDestinationCache[mirrorRowIndex, mirrorColumnIndex] = -1;
                }

                int resolvedDestination;

                if (grid[nextRowIndex][nextColumnIndex] == 0)
                {
                    resolvedDestination = nextRowIndex * totalColumnCount + nextColumnIndex;
                }
                else
                {
                    resolvedDestination = ResolveMirrorDestination(nextRowIndex, nextColumnIndex, !isMovingRight);
                }

                return mirrorDestinationCache[mirrorRowIndex, mirrorColumnIndex] = resolvedDestination;
            }

            int GetNextCellDestination(int currentRowIndex, int currentColumnIndex, bool isMovingRight)
            {
                int nextRowIndex = isMovingRight ? currentRowIndex : currentRowIndex + 1;

                int nextColumnIndex = isMovingRight ? currentColumnIndex + 1 : currentColumnIndex;

                if (nextRowIndex >= totalRowCount || nextColumnIndex >= totalColumnCount)
                {
                    return -1;
                }

                if (grid[nextRowIndex][nextColumnIndex] == 0)
                {
                    return nextRowIndex * totalColumnCount + nextColumnIndex;
                }

                return ResolveMirrorDestination(nextRowIndex, nextColumnIndex, isMovingRight);
            }

            int[,] pathCountByCell = new int[totalRowCount, totalColumnCount];

            pathCountByCell[0, 0] = 1;

            for (int currentRowIndex = 0; currentRowIndex < totalRowCount; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < totalColumnCount; currentColumnIndex++)
                {
                    if (pathCountByCell[currentRowIndex, currentColumnIndex] == 0)
                    {
                        continue;
                    }

                    long currentCellPathCount = pathCountByCell[currentRowIndex, currentColumnIndex];

                    int rightwardDestination = GetNextCellDestination(currentRowIndex, currentColumnIndex, true);

                    if (rightwardDestination != -1)
                    {
                        int destinationRowIndex = rightwardDestination / totalColumnCount;

                        int destinationColumnIndex = rightwardDestination % totalColumnCount;

                        pathCountByCell[destinationRowIndex, destinationColumnIndex] = (int)((pathCountByCell[destinationRowIndex, destinationColumnIndex] % ModuloDivisor);
                    }

                    int downwardDestination = GetNextCellDestination(currentRowIndex, currentColumnIndex, false);

                    if (downwardDestination != -1)
                    {
                        int destinationRowIndex = downwardDestination / totalColumnCount;

                        int destinationColumnIndex = downwardDestination % totalColumnCount;

                        pathCountByCell[destinationRowIndex, destinationColumnIndex] = (int)((pathCountByCell[destinationRowIndex, destinationColumnIndex] + currentCellPathCount) % ModuloDivisor);
                    }
                }
            }

            return pathCountByCell[totalRowCount - 1, totalColumnCount - 1];
        }
    }
}