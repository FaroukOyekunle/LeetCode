namespace DailyQuestion
{
    public class RotateImage
    {
        public void RotateMatrix90DegreesClockwise(int[][] matrix)
        {
            int matrixSize = matrix.Length;

            for (int currentRow = 0; currentRow < matrixSize; currentRow++)
            {
                for (int currentColumn = currentRow; currentColumn < matrixSize; currentColumn++)
                {
                    int temporaryValue = matrix[currentRow][currentColumn];

                    matrix[currentRow][currentColumn] = matrix[currentColumn][currentRow];
                    matrix[currentColumn][currentRow] = temporaryValue;
                }
            }

            for (int currentRow = 0; currentRow < matrixSize; currentRow++)
            {
                int leftColumnIndex = 0;
                int rightColumnIndex = matrixSize - 1;

                while (leftColumnIndex < rightColumnIndex)
                {
                    int temporaryValue = matrix[currentRow][leftColumnIndex];

                    matrix[currentRow][leftColumnIndex] = matrix[currentRow][rightColumnIndex];
                    matrix[currentRow][rightColumnIndex] = temporaryValue;

                    leftColumnIndex++;
                    rightColumnIndex--;
                }
            }
        }
    }
}