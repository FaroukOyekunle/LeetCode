namespace DailyQuestion
{
    public class SpecialPositionsinaBinaryMatrix
    {
        public int CountSpecialPositionsInBinaryMatrix(int[][] binaryMatrix)
        {
            int rowCount = binaryMatrix.Length;
            int columnCount = binaryMatrix[0].Length;

            int[] rowOnesCount = new int[rowCount];
            int[] columnOnesCount = new int[columnCount];

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    if (binaryMatrix[rowIndex][columnIndex] == 1)
                    {
                        rowOnesCount[rowIndex]++;
                        columnOnesCount[columnIndex]++;
                    }
                }
            }

            int specialPositionCount = 0;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    if (binaryMatrix[rowIndex][columnIndex] == 1 && rowOnesCount[rowIndex] == 1 && columnOnesCount[columnIndex] == 1)
                    {
                        specialPositionCount++;
                    }
                }
            }

            return specialPositionCount;
        }
    }
}