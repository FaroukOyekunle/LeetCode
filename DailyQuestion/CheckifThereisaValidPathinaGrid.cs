namespace DailyQuestion
{
    public class CheckifThereisaValidPathinaGrid
    {
        public bool HasValidPath(int[][] streetGrid)
        {
            int totalRows = streetGrid.Length;
            int totalColumns = streetGrid[0].Length;

            int[][] movementDirections = new int[][]
            {
                new int[] { 0, -1 },  
                new int[] { 0, 1 },   
                new int[] { -1, 0 },  
                new int[] { 1, 0 }   
            };

            Dictionary<int, int[]> streetTypeToAllowedDirections = new Dictionary<int, int[]>
            {
                { 1, new int[] { 0, 1 } }, 
                { 2, new int[] { 2, 3 } }, 
                { 3, new int[] { 0, 3 } }, 
                { 4, new int[] { 1, 3 } }, 
                { 5, new int[] { 0, 2 } }, 
                { 6, new int[] { 1, 2 } }  
            };

            bool[,] visitedCells = new bool[totalRows, totalColumns];

            Queue<(int rowIndex, int columnIndex)> bfsQueue = new Queue<(int, int)>();

            bfsQueue.Enqueue((0, 0));
            visitedCells[0, 0] = true;

            while (bfsQueue.Count > 0)
            {
                var (currentRowIndex, currentColumnIndex) = bfsQueue.Dequeue();

                bool reachedDestination = currentRowIndex == totalRows - 1 && currentColumnIndex == totalColumns - 1;

                if (reachedDestination)
                {
                    return true;
                }

                int currentStreetType = streetGrid[currentRowIndex][currentColumnIndex];

                foreach (int allowedDirectionIndex in streetTypeToAllowedDirections[currentStreetType])
                {
                    int nextRowIndex = currentRowIndex + movementDirections[allowedDirectionIndex][0];
                    int nextColumnIndex = currentColumnIndex + movementDirections[allowedDirectionIndex][1];

                    bool isOutOfBounds = nextRowIndex < 0 || nextColumnIndex < 0 || nextRowIndex >= totalRows || nextColumnIndex >= totalColumns;

                    if (isOutOfBounds || visitedCells[nextRowIndex, nextColumnIndex])
                    {
                        continue;
                    }

                    int nextStreetType = streetGrid[nextRowIndex][nextColumnIndex];

                    foreach (int reverseDirectionIndex in streetTypeToAllowedDirections[nextStreetType])
                    {
                        int reverseRowIndex = nextRowIndex + movementDirections[reverseDirectionIndex][0];
                        int reverseColumnIndex = nextColumnIndex + movementDirections[reverseDirectionIndex][1];

                        bool connectsBackToCurrent = reverseRowIndex == currentRowIndex && reverseColumnIndex == currentColumnIndex;

                        if (connectsBackToCurrent)
                        {
                            visitedCells[nextRowIndex, nextColumnIndex] = true;
                            bfsQueue.Enqueue((nextRowIndex, nextColumnIndex));
                            break;
                        }
                    }
                }
            }

            return false;
        }
    }
}