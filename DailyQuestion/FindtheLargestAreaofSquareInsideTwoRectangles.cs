namespace DailyQuestion
{
    public class FindtheLargestAreaofSquareInsideTwoRectangles
    {
        public long LargestSquareArea(int[][] bottomLeftCorners, int[][] topRightCorners)
        {
            int rectangleCount = bottomLeftCorners.Length;
            long maximumSquareSideLength = 0;

            for(int firstRectangleIndex = 0; firstRectangleIndex < rectangleCount; firstRectangleIndex++)
            {
                for(int secondRectangleIndex = firstRectangleIndex + 1; secondRectangleIndex < rectangleCount; secondRectangleIndex++)
                {
                    int overlappingLeftBoundary = Math.Max(bottomLeftCorners[firstRectangleIndex][0], bottomLeftCorners[secondRectangleIndex][0]);
                    int overlappingBottomBoundary = Math.Max(bottomLeftCorners[firstRectangleIndex][1], bottomLeftCorners[secondRectangleIndex][1]);
                    int overlappingRightBoundary = Math.Min(topRightCorners[firstRectangleIndex][0], topRightCorners[secondRectangleIndex][0]);
                    int overlappingTopBoundary = Math.Min(topRightCorners[firstRectangleIndex][1], topRightCorners[secondRectangleIndex][1]);

                    int overlappingWidth = overlappingRightBoundary - overlappingLeftBoundary;
                    int overlappingHeight = overlappingTopBoundary - overlappingBottomBoundary;

                    if (overlappingWidth > 0 && overlappingHeight > 0)
                    {
                        long squareSideLength = Math.Min(overlappingWidth, overlappingHeight);
                        maximumSquareSideLength = Math.Max(maximumSquareSideLength, squareSideLength);
                    }
                }
            }

            return maximumSquareSideLength * maximumSquareSideLength;
        }
    }
}