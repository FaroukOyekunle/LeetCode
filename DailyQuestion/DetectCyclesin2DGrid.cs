namespace DailyQuestion
{
    public class DetectCyclesin2DGrid
    {
        private int totalRows, totalColumns;
        private bool[,] visitedCells;

        private readonly int[][] neighborDirections = new int[][]
        {
            new int[] { 1, 0 },    
            new int[] { -1, 0 },  
            new int[] { 0, 1 },    
            new int[] { 0, -1 }    
        };

        public bool ContainsCycle(char[][] grid)
        {
            totalRows = grid.Length;
            totalColumns = grid[0].Length;

            visitedCells = new bool[totalRows, totalColumns];

            for (int currentRowIndex = 0; currentRowIndex < totalRows; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < totalColumns; currentColumnIndex++)
                {
                    if (!visitedCells[currentRowIndex, currentColumnIndex])
                    {
                        bool cycleFound = DepthFirstSearchForCycle(grid, currentRowIndex, currentColumnIndex, previousRowIndex: -1, previousColumnIndex: -1, characterToMatch: grid[currentRowIndex][currentColumnIndex]);

                        if (cycleFound)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool DepthFirstSearchForCycle(char[][] grid, int currentRowIndex, int currentColumnIndex, int previousRowIndex, int previousColumnIndex, char characterToMatch)
        {
            visitedCells[currentRowIndex, currentColumnIndex] = true;

            foreach (var direction in neighborDirections)
            {
                int nextRowIndex = currentRowIndex + direction[0];
                int nextColumnIndex = currentColumnIndex + direction[1];

                bool isOutOfBounds = nextRowIndex < 0 || nextRowIndex >= totalRows || nextColumnIndex < 0 || nextColumnIndex >= totalColumns;

                if (isOutOfBounds)
                {
                    continue;
                }

                if (grid[nextRowIndex][nextColumnIndex] != characterToMatch)
                {
                    continue;
                }

                bool isPreviousCell = nextRowIndex == previousRowIndex && nextColumnIndex == previousColumnIndex;

                if (isPreviousCell)
                {
                    continue;
                }

                if (visitedCells[nextRowIndex, nextColumnIndex])
                {
                    return true;
                }

                bool cycleDetectedInDeeperPath = DepthFirstSearchForCycle(grid, nextRowIndex, nextColumnIndex, currentRowIndex, currentColumnIndex, characterToMatch);

                if (cycleDetectedInDeeperPath)
                {
                    return true;
                }
            }

            return false;
        }
    }
}