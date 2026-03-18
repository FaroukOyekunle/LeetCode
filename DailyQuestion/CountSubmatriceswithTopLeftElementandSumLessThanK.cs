namespace DailyQuestion
{
    public class CountSubmatriceswithTopLeftElementandSumLessThanK
    {
        public int CountSubmatricesWithSumLessThanOrEqualToTarget(int[][] matrix, int targetSum)
        {
            int totalRows = matrix.Length;
            int totalColumns = matrix[0].Length;

            int numberOfValidSubmatrices = 0;

            for (int currentRow = 0; currentRow < totalRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < totalColumns; currentColumn++)
                {
                    int prefixSumFromTop = currentRow > 0 ? matrix[currentRow - 1][currentColumn] : 0;

                    int prefixSumFromLeft = currentColumn > 0 ? matrix[currentRow][currentColumn - 1] : 0;

                    int prefixSumFromTopLeftDiagonal = (currentRow > 0 && currentColumn > 0) ? matrix[currentRow - 1][currentColumn - 1] : 0;

                    matrix[currentRow][currentColumn] = matrix[currentRow][currentColumn] + prefixSumFromTop + prefixSumFromLeft - prefixSumFromTopLeftDiagonal;

                    if (matrix[currentRow][currentColumn] <= targetSum)
                    {
                        numberOfValidSubmatrices++;
                    }
                }
            }

            return numberOfValidSubmatrices;
        }
    }
}