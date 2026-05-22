namespace DailyQuestion
{
    public class SearchinRotatedSortedArray
    {
        public int Search(int[] rotatedSortedArray, int targetValue)
        {
            int leftSearchBoundary = 0;

            int rightSearchBoundary = rotatedSortedArray.Length - 1;

            while (leftSearchBoundary <= rightSearchBoundary)
            {
                int middleIndex = leftSearchBoundary + (rightSearchBoundary - leftSearchBoundary) / 2;

                int middleValue = rotatedSortedArray[middleIndex];

                if (middleValue == targetValue)
                {
                    return middleIndex;
                }

                bool leftHalfIsSorted = rotatedSortedArray[leftSearchBoundary] <= middleValue;

                if (leftHalfIsSorted)
                {
                    bool targetExistsInLeftHalf = targetValue >= rotatedSortedArray[leftSearchBoundary] && targetValue < middleValue;

                    if (targetExistsInLeftHalf)
                    {
                        rightSearchBoundary = middleIndex - 1;
                    }
                    else
                    {
                        leftSearchBoundary = middleIndex + 1;
                    }
                }
                else
                {
                    bool targetExistsInRightHalf = targetValue > middleValue && targetValue <= rotatedSortedArray[rightSearchBoundary];

                    if (targetExistsInRightHalf)
                    {
                        leftSearchBoundary = middleIndex + 1;
                    }
                    else
                    {
                        rightSearchBoundary = middleIndex - 1;
                    }
                }
            }

            return -1;
        }
    }
}