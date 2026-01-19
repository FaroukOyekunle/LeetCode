namespace DailyQuestion
{
    public class MaximumSideLengthofaSquarewithSumLessthanorEqualtoThreshold
    {
        public int MaxSideLength(int[][] matrix, int maxSumThreshold)
        {
            int rowCount = matrix.Length;
            int columnCount = matrix[0].Length;

            int[,] prefixSum = new int[rowCount + 1, columnCount + 1];

            for(int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
            {
                for(int columnIndex = 1; columnIndex <= columnCount; columnIndex++)
                {
                    prefixSum[rowIndex, columnIndex] = matrix[rowIndex - 1][columnIndex - 1]
                                                    + prefixSum[rowIndex - 1, columnIndex]
                                                    + prefixSum[rowIndex, columnIndex - 1]
                                                    - prefixSum[rowIndex - 1, columnIndex - 1];
                }
            }

            int minimumSideLength = 0, maximumSideLength = Math.Min(rowCount, columnCount), largestValidSideLength = 0;

            while(minimumSideLength <= maximumSideLength)
            {
                int midSideLength = minimumSideLength + (maximumSideLength - minimumSideLength) / 2;

                if(IsSquareWithSideLengthValid(prefixSum, rowCount, columnCount, midSideLength, maxSumThreshold))
                {
                    largestValidSideLength = midSideLength;
                    minimumSideLength = midSideLength + 1;
                }

                else
                {
                    maximumSideLength = midSideLength - 1;
                }
            }

            return largestValidSideLength;
        }

        private bool IsSquareWithSideLengthValid(int[,] prefixSum, int rowCount, int columnCount, int sideLength, int maxSumThreshold)
        {
            for(int bottomRow = sideLength; bottomRow <= rowCount; bottomRow++)
            {
                for(int rightColumn = sideLength; rightColumn <= columnCount; rightColumn++)
                {
                    int squareSum = prefixSum[bottomRow, rightColumn]
                                  - prefixSum[bottomRow - sideLength, rightColumn]
                                  - prefixSum[bottomRow, rightColumn - sideLength]
                                  + prefixSum[bottomRow - sideLength, rightColumn - sideLength];

                    if(squareSum <= maxSumThreshold)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}