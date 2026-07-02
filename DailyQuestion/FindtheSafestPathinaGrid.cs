namespace DailyQuestion
{
    public class FindtheSafestPathinaGrid
    {
        private static readonly int[][] AdjacentCellDirections =
        {
            new[] { 1, 0 },   
            new[] { -1, 0 },  
            new[] { 0, 1 },  
            new[] { 0, -1 }   
        };

        public int MaximumSafenessFactor(IList<IList<int>> cityGrid)
        {
            int gridDimension = cityGrid.Count;

            int[,] minimumDistanceToNearestThief = ComputeMinimumDistanceToNearestThief(cityGrid);

            int highestPossibleSafenessFactor = 0;

            for (int rowIndex = 0; rowIndex < gridDimension; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < gridDimension; columnIndex++)
                {
                    highestPossibleSafenessFactor = Math.Max(highestPossibleSafenessFactor, minimumDistanceToNearestThief[rowIndex, columnIndex]);
                }
            }

            int minimumCandidateSafeness = 0;
            int maximumCandidateSafeness = highestPossibleSafenessFactor;

            int maximumAchievableSafenessFactor = 0;

            while (minimumCandidateSafeness <= maximumCandidateSafeness)
            {
                int candidateSafenessFactor = minimumCandidateSafeness + (maximumCandidateSafeness - minimumCandidateSafeness) / 2;

                bool pathExistsWithCandidateSafeness = CanReachDestinationWithSafenessFactor(minimumDistanceToNearestThief, candidateSafenessFactor);

                if (pathExistsWithCandidateSafeness)
                {
                    maximumAchievableSafenessFactor = candidateSafenessFactor;

                    minimumCandidateSafeness = candidateSafenessFactor + 1;
                }
                else
                {
                    maximumCandidateSafeness = candidateSafenessFactor - 1;
                }
            }

            return maximumAchievableSafenessFactor;
        }

        private int[,] ComputeMinimumDistanceToNearestThief(IList<IList<int>> cityGrid)
        {
            int gridDimension = cityGrid.Count;

            int[,] minimumDistanceToNearestThief = new int[gridDimension, gridDimension];

            Queue<(int RowIndex, int ColumnIndex)> breadthFirstSearchQueue = new();

            for (int rowIndex = 0; rowIndex < gridDimension; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < gridDimension; columnIndex++)
                {
                    minimumDistanceToNearestThief[rowIndex, columnIndex] = int.MaxValue;

                    if (cityGrid[rowIndex][columnIndex] == 1)
                    {
                        minimumDistanceToNearestThief[rowIndex, columnIndex] = 0;

                        breadthFirstSearchQueue.Enqueue((rowIndex, columnIndex));
                    }
                }
            }

            while (breadthFirstSearchQueue.Count > 0)
            {
                var (currentRowIndex, currentColumnIndex) = breadthFirstSearchQueue.Dequeue();

                foreach (int[] movementDirection in AdjacentCellDirections)
                {
                    int neighboringRowIndex = currentRowIndex + movementDirection[0];

                    int neighboringColumnIndex = currentColumnIndex + movementDirection[1];

                    bool isNeighborOutsideGrid = neighboringRowIndex < 0 || neighboringColumnIndex < 0 || neighboringRowIndex >= gridDimension || neighboringColumnIndex >= gridDimension;

                    if (isNeighborOutsideGrid)
                    {
                        continue;
                    }

                    bool neighborAlreadyProcessed = minimumDistanceToNearestThief[neighboringRowIndex, neighboringColumnIndex] != int.MaxValue;

                    if (neighborAlreadyProcessed)
                    {
                        continue;
                    }

                    minimumDistanceToNearestThief[neighboringRowIndex, neighboringColumnIndex] = minimumDistanceToNearestThief[currentRowIndex, currentColumnIndex] + 1;

                    breadthFirstSearchQueue.Enqueue((neighboringRowIndex, neighboringColumnIndex));
                }
            }

            return minimumDistanceToNearestThief;
        }

        private bool CanReachDestinationWithSafenessFactor(int[,] minimumDistanceToNearestThief, int requiredMinimumSafenessFactor)
        {
            int gridDimension = minimumDistanceToNearestThief.GetLength(0);

            bool startCellIsUnsafe = minimumDistanceToNearestThief[0, 0] < requiredMinimumSafenessFactor;

            bool destinationCellIsUnsafe = minimumDistanceToNearestThief[gridDimension - 1, gridDimension - 1] < requiredMinimumSafenessFactor;

            if (startCellIsUnsafe || destinationCellIsUnsafe)
            {
                return false;
            }

            bool[,] visitedCells = new bool[gridDimension, gridDimension];

            Queue<(int RowIndex, int ColumnIndex)> breadthFirstSearchQueue = new();

            breadthFirstSearchQueue.Enqueue((0, 0));

            visitedCells[0, 0] = true;

            while (breadthFirstSearchQueue.Count > 0)
            {
                var (currentRowIndex, currentColumnIndex) = breadthFirstSearchQueue.Dequeue();

                bool reachedDestination = currentRowIndex == gridDimension - 1 && currentColumnIndex == gridDimension - 1;

                if (reachedDestination)
                {
                    return true;
                }

                foreach (int[] movementDirection in AdjacentCellDirections)
                {
                    int neighboringRowIndex = currentRowIndex + movementDirection[0];

                    int neighboringColumnIndex = currentColumnIndex + movementDirection[1];

                    bool isNeighborOutsideGrid = neighboringRowIndex < 0 || neighboringColumnIndex < 0 || neighboringRowIndex >= gridDimension || neighboringColumnIndex >= gridDimension;

                    if (isNeighborOutsideGrid)
                    {
                        continue;
                    }

                    if (visitedCells[neighboringRowIndex, neighboringColumnIndex])
                    {
                        continue;
                    }

                    bool neighborDoesNotMeetSafenessRequirement = minimumDistanceToNearestThief[neighboringRowIndex, neighboringColumnIndex] < requiredMinimumSafenessFactor;

                    if (neighborDoesNotMeetSafenessRequirement)
                    {
                        continue;
                    }

                    visitedCells[neighboringRowIndex, neighboringColumnIndex] = true;

                    breadthFirstSearchQueue.Enqueue((neighboringRowIndex, neighboringColumnIndex));
                }
            }

            return false;
        }
    }
}