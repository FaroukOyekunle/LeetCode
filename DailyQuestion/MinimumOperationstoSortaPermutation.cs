namespace DailyQuestion
{
    public class MinimumOperationstoSortaPermutation
    {
        public int MinOperations(int[] numbers)
        {
            int totalNumberOfElements = numbers.Length;
            int indexOfZero = Array.IndexOf(numbers, 0);
            int minimumRequiredOperations = int.MaxValue;

            bool isAscendingOrderAfterRotation = true;
            bool isDescendingOrderAfterRotation = true;

            for (int rotationOffset = 0; rotationOffset < totalNumberOfElements; rotationOffset++)
            {
                int currentElement = numbers[(indexOfZero + rotationOffset) % totalNumberOfElements];

                if (currentElement != rotationOffset)
                {
                    isAscendingOrderAfterRotation = false;
                }

                int expectedElementInDescendingOrder = (totalNumberOfElements - rotationOffset) % totalNumberOfElements;

                if (currentElement != expectedElementInDescendingOrder)
                {
                    isDescendingOrderAfterRotation = false;
                }
            }

            if (isAscendingOrderAfterRotation)
            {
                int leftRotationOperationCount = indexOfZero;

                int reverseRotateReverseOperationCount = totalNumberOfElements - indexOfZero + 2;

                minimumRequiredOperations = Math.Min(minimumRequiredOperations, Math.Min(leftRotationOperationCount, reverseRotateReverseOperationCount));
            }

            if (isDescendingOrderAfterRotation)
            {
                int reverseFirstOperationCount = totalNumberOfElements - indexOfZero;

                int rotateThenReverseOperationCount = indexOfZero + 2;

                minimumRequiredOperations = Math.Min(minimumRequiredOperations, Math.Min(reverseFirstOperationCount, rotateThenReverseOperationCount));
            }

            return minimumRequiredOperations == int.MaxValue ? -1 : minimumRequiredOperations;
        }
    }
}