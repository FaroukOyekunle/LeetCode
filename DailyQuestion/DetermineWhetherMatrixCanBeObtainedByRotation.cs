namespace DailyQuestion
{
    public class DetermineWhetherMatrixCanBeObtainedByRotation
    {
        public bool CanTransformMatrixByRotation(int[][] sourceMatrix, int[][] targetMatrix)
        {
            for (int rotationAttempt = 0; rotationAttempt < 4; rotationAttempt++)
            {
                if (AreMatricesEqual(sourceMatrix, targetMatrix))
                {
                    return true;
                }

                sourceMatrix = RotateMatrix90DegreesClockwise(sourceMatrix);
            }

            return false;
        }

        private bool AreMatricesEqual(int[][] firstMatrix, int[][] secondMatrix)
        {
            int matrixSize = firstMatrix.Length;

            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++)
                {
                    if (firstMatrix[rowIndex][columnIndex] != secondMatrix[rowIndex][columnIndex])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int[][] RotateMatrix90DegreesClockwise(int[][] originalMatrix)
        {
            int matrixSize = originalMatrix.Length;

            int[][] rotatedMatrix = new int[matrixSize][];

            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                rotatedMatrix[rowIndex] = new int[matrixSize];
            }

            for (int originalRow = 0; originalRow < matrixSize; originalRow++)
            {
                for (int originalColumn = 0; originalColumn < matrixSize; originalColumn++)
                {
                    int newRow = originalColumn;
                    int newColumn = matrixSize - originalRow - 1;

                    rotatedMatrix[newRow][newColumn] = originalMatrix[originalRow][originalColumn];
                }
            }

            return rotatedMatrix;
        }
    }
}