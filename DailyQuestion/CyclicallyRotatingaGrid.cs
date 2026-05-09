namespace DailyQuestion
{
    public class CyclicallyRotatingaGrid
    {
        public int[][] RotateMatrixLayers(int[][] matrix, int rotationStepCount)
        {
            int totalRowCount = matrix.Length;
            int totalColumnCount = matrix[0].Length;

            int totalLayerCount = Math.Min(totalRowCount, totalColumnCount) / 2;

            for (int currentLayerIndex = 0; currentLayerIndex < totalLayerCount; currentLayerIndex++)
            {
                List<int> currentLayerElements = new List<int>();

                int topBoundaryRow = currentLayerIndex;
                int leftBoundaryColumn = currentLayerIndex;

                int bottomBoundaryRow = totalRowCount - currentLayerIndex - 1;

                int rightBoundaryColumn = totalColumnCount - currentLayerIndex - 1;

                for (int currentColumn = leftBoundaryColumn; currentColumn <= rightBoundaryColumn; currentColumn++)
                {
                    currentLayerElements.Add(matrix[topBoundaryRow][currentColumn]);
                }

                for (int currentRow = topBoundaryRow + 1; currentRow <= bottomBoundaryRow - 1; currentRow++)
                {
                    currentLayerElements.Add(matrix[currentRow][rightBoundaryColumn]);
                }

                for (int currentColumn = rightBoundaryColumn; currentColumn >= leftBoundaryColumn; currentColumn--)
                {
                    currentLayerElements.Add(matrix[bottomBoundaryRow][currentColumn]);
                }

                for (int currentRow = bottomBoundaryRow - 1; currentRow >= topBoundaryRow + 1; currentRow--)
                {
                    currentLayerElements.Add(matrix[currentRow][leftBoundaryColumn]);
                }

                int currentLayerElementCount = currentLayerElements.Count;

                int effectiveRotationCount = rotationStepCount % currentLayerElementCount;

                List<int> rotatedLayerElements = new List<int>(new int[currentLayerElementCount]);

                for (int currentElementIndex = 0; currentElementIndex < currentLayerElementCount; currentElementIndex++)
                {
                    int rotatedPositionIndex = ( currentElementIndex + currentLayerElementCount - effectiveRotationCount) % currentLayerElementCount;

                    rotatedLayerElements[rotatedPositionIndex] = currentLayerElements[currentElementIndex];
                }

                int rotatedElementReadIndex = 0;

                for (int currentColumn = leftBoundaryColumn; currentColumn <= rightBoundaryColumn; currentColumn++)
                {
                    matrix[topBoundaryRow][currentColumn] = rotatedLayerElements[rotatedElementReadIndex++];
                }

                for (int currentRow = topBoundaryRow + 1; currentRow <= bottomBoundaryRow - 1; currentRow++)
                {
                    matrix[currentRow][rightBoundaryColumn] = rotatedLayerElements[rotatedElementReadIndex++];
                }

                for (int currentColumn = rightBoundaryColumn; currentColumn >= leftBoundaryColumn; currentColumn--)
                {
                    matrix[bottomBoundaryRow][currentColumn] = rotatedLayerElements[rotatedElementReadIndex++];
                }

                for (int currentRow = bottomBoundaryRow - 1; currentRow >= topBoundaryRow + 1; currentRow--)
                {
                    matrix[currentRow][leftBoundaryColumn] = rotatedLayerElements[rotatedElementReadIndex++];
                }
            }

            return matrix;
        }
    }
}