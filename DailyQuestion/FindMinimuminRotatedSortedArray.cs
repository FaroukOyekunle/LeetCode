namespace DailyQuestion
{
    public class FindMinimuminRotatedSortedArray
    {
        public int FindMin(int[] rotatedSortedNumbers)
        {
            int leftBoundaryIndex = 0;

            int rightBoundaryIndex = rotatedSortedNumbers.Length - 1;

            while (leftBoundaryIndex < rightBoundaryIndex)
            {
                int middleIndex = leftBoundaryIndex + (rightBoundaryIndex - leftBoundaryIndex) / 2;

                bool minimumValueExistsInRightHalf = rotatedSortedNumbers[middleIndex] > rotatedSortedNumbers[rightBoundaryIndex];

                if (minimumValueExistsInRightHalf)
                {
                    leftBoundaryIndex = middleIndex + 1;
                }
                else
                {
                    rightBoundaryIndex = middleIndex;
                }
            }

            return rotatedSortedNumbers[leftBoundaryIndex];
        }
    }
}