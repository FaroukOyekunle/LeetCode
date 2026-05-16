namespace DailyQuestion
{
    public class FindMinimuminRotatedSortedArrayII
    {
        public int FindMin(int[] rotatedSortedArrayWithDuplicates)
        {
            int leftSearchBoundary = 0;

            int rightSearchBoundary = rotatedSortedArrayWithDuplicates.Length - 1;

            while (leftSearchBoundary < rightSearchBoundary)
            {
                int middleIndex = leftSearchBoundary + (rightSearchBoundary - leftSearchBoundary) / 2;

                int middleValue = rotatedSortedArrayWithDuplicates[middleIndex];

                int rightBoundaryValue = rotatedSortedArrayWithDuplicates[rightSearchBoundary];

                if (middleValue > rightBoundaryValue)
                {
                    leftSearchBoundary = middleIndex + 1;
                }
                else if (middleValue < rightBoundaryValue)
                {
                    rightSearchBoundary = middleIndex;
                }
                else
                {
                    rightSearchBoundary--;
                }
            }

            return rotatedSortedArrayWithDuplicates[leftSearchBoundary];
        }
    }
}