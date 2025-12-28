namespace DailyQuestion
{
    public class CountNegativeNumbersinaSortedMatrix
    {
        public int CountNegatives(int[][] matrix)
        {
            int totalRows = matrix.Length;
            int totalColumns = matrix[0].Length;

            int currentRow = 0;
            int currentColumn = totalColumns - 1;
            int negativeCount = 0;

            while(currentRow < totalRows && currentColumn >= 0)
            {
                if(matrix[currentRow][currentColumn] < 0)
                {
                    negativeCount += (totalRows - currentRow);
                    currentColumn--;
                }
                
                else
                {
                    currentRow++;
                }
            }

            return negativeCount;
        }
    }
}