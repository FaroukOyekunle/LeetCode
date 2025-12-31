namespace DailyQuestion
{
    public class LastDayWhereYouCanStillCross
    {
        public int LatestDayToCross(int totalRows, int totalColumns, int[][] floodedCells)
        {
            int leftBoundary = 0;
            int rightBoundary = floodedCells.Length;
            int latestPossibleDay = 0;

            while(leftBoundary <= rightBoundary)
            {
                int middleDay = leftBoundary + (rightBoundary - leftBoundary) / 2;

                if(CanCross(totalRows, totalColumns, floodedCells, middleDay))
                {
                    latestPossibleDay = middleDay;
                    leftBoundary = middleDay + 1;
                }

                else
                {
                    rightBoundary = middleDay - 1;
                }
            }

            return latestPossibleDay;
        }

        private bool CanCross(int totalRows, int totalColumns, int[][] floodedCells, int currentDay)
        {
            int[,] grid = new int[totalRows, totalColumns];

            for(int cellIndex = 0; cellIndex < currentDay; cellIndex++)
            {
                int floodedRow = floodedCells[cellIndex][0] - 1;
                int floodedColumn = floodedCells[cellIndex][1] - 1;
                grid[floodedRow, floodedColumn] = 1;
            }

            Queue<(int row, int column)> traversalQueue = new Queue<(int row, int column)>();
            bool[,] visitedCells = new bool[totalRows, totalColumns];

            for(int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
            {
                if(grid[0, columnIndex] == 0)
                {
                    traversalQueue.Enqueue((0, columnIndex));
                    visitedCells[0, columnIndex] = true;
                }
            }

            int[] rowDirections = { 1, -1, 0, 0 };
            int[] columnDirections = { 0, 0, 1, -1 };

            while(traversalQueue.Count > 0)
            {
                var (currentRow, currentColumn) = traversalQueue.Dequeue();

                if(currentRow == totalRows - 1)
                {
                    return true;
                }

                for(int directionIndex = 0; directionIndex < 4; directionIndex++)
                {
                    int nextRow = currentRow + rowDirections[directionIndex];
                    int nextColumn = currentColumn + columnDirections[directionIndex];

                    if(nextRow >= 0 && nextRow < totalRows && nextColumn >= 0 && nextColumn < totalColumns &&
                        !visitedCells[nextRow, nextColumn] && grid[nextRow, nextColumn] == 0)
                    {
                        visitedCells[nextRow, nextColumn] = true;
                        traversalQueue.Enqueue((nextRow, nextColumn));
                    }
                }
            }

            return false;
        }
    }
}