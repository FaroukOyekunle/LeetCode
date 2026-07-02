namespace DailyQuestion
{
    public class FindaSafeWalkThroughaGrid
    {
        private static readonly int[][] AdjacentCellDirections =
        {
            new[] { -1, 0 },
            new[] { 1, 0 },
            new[] { 0, -1 },
            new[] { 0, 1 }
        };

        public bool FindSafeWalk(IList<IList<int>> grid, int initialHealth)
        {
            int totalRowCount = grid.Count;
            int totalColumnCount = grid[0].Count;

            int[,] minimumHealthLossToReachCell = new int[totalRowCount, totalColumnCount];

            for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
                {
                    minimumHealthLossToReachCell[rowIndex, columnIndex] = int.MaxValue;
                }
            }

            LinkedList<(int RowIndex, int ColumnIndex)> zeroOneBreadthFirstSearchDeque = new();

            minimumHealthLossToReachCell[0, 0] = grid[0][0];

            zeroOneBreadthFirstSearchDeque.AddFirst((0, 0));

            while (zeroOneBreadthFirstSearchDeque.Count > 0)
            {
                var (currentRowIndex, currentColumnIndex) = zeroOneBreadthFirstSearchDeque.First.Value;

                zeroOneBreadthFirstSearchDeque.RemoveFirst();

                foreach (int[] movementDirection in AdjacentCellDirections)
                {
                    int neighboringRowIndex = currentRowIndex + movementDirection[0];

                    int neighboringColumnIndex = currentColumnIndex + movementDirection[1];

                    bool isNeighborOutsideGrid = neighboringRowIndex < 0 || neighboringRowIndex >= totalRowCount || neighboringColumnIndex < 0 || neighboringColumnIndex >= totalColumnCount;

                    if (isNeighborOutsideGrid)
                    {
                        continue;
                    }

                    int accumulatedHealthLossToNeighbor = minimumHealthLossToReachCell[currentRowIndex, currentColumnIndex] + grid[neighboringRowIndex, neighboringColumnIndex];

                    bool existingPathIsBetterOrEqual = accumulatedHealthLossToNeighbor >= minimumHealthLossToReachCell[neighboringRowIndex, neighboringColumnIndex];

                    if (existingPathIsBetterOrEqual)
                    {
                        continue;
                    }

                    minimumHealthLossToReachCell[neighboringRowIndex, neighboringColumnIndex] = accumulatedHealthLossToNeighbor;

                    bool neighboringCellIsSafe = grid[neighboringRowIndex, neighboringColumnIndex] == 0;

                    if (neighboringCellIsSafe)
                    {
                        zeroOneBreadthFirstSearchDeque.AddFirst((neighboringRowIndex, neighboringColumnIndex));
                    }
                    else
                    {
                        zeroOneBreadthFirstSearchDeque.AddLast((neighboringRowIndex, neighboringColumnIndex));
                    }
                }
            }

            int minimumHealthLossToReachDestination = minimumHealthLossToReachCell[totalRowCount - 1, totalColumnCount - 1];

            return minimumHealthLossToReachDestination < initialHealth;
        }
    }
}