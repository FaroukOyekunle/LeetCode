namespace DailyQuestion
{
    public class FlipSquareSubmatrixVertically
    {
        public int[][] ReverseSquareSubmatrixVertically(int[][] inputMatrix, int submatrixTopRowIndex, int submatrixLeftColumnIndex, int submatrixSize)
        {
            int currentTopRow = submatrixTopRowIndex;
            int currentBottomRow = submatrixTopRowIndex + submatrixSize - 1;

            while (currentTopRow < currentBottomRow)
            {
                for (int currentColumn = submatrixLeftColumnIndex; currentColumn < submatrixLeftColumnIndex + submatrixSize; currentColumn++)
                {
                    int temporaryValue = inputMatrix[currentTopRow][currentColumn];

                    inputMatrix[currentTopRow][currentColumn] = inputMatrix[currentBottomRow][currentColumn];

                    inputMatrix[currentBottomRow][currentColumn] = temporaryValue;
                }

                currentTopRow++;
                currentBottomRow--;
            }

            return inputMatrix;
        }
    }
}