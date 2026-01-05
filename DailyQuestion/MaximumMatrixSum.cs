namespace DailyQuestion
{
    public class MaximumMatrixSum
    {
        public long MaxMatrixSum(int[][] matrix)
        {
            long totalAbsoluteSum = 0;
            int negativeValueCount = 0;
            int smallestAbsoluteValue = int.MaxValue;

            for(int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for(int columnIndex = 0; columnIndex < matrix[rowIndex].Length; columnIndex++)
                {
                    int currentValue = matrix[rowIndex][columnIndex];
                    if(currentValue < 0) 
                    {
                        negativeValueCount++;
                    }

                    int absoluteValue = Math.Abs(currentValue);
                    totalAbsoluteSum += absoluteValue;
                    smallestAbsoluteValue = Math.Min(smallestAbsoluteValue, absoluteValue);
                }
            }

            if(negativeValueCount % 2 != 0)
            {
                totalAbsoluteSum -= 2L * smallestAbsoluteValue;
            }

            return totalAbsoluteSum;
        }
    }
}