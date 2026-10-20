namespace DailyQuestion
{
    public class SumofSortableIntegers
    {
        public int SortableIntegers(int[] numbers)
        {
            int totalNumberOfElements = numbers.Length;
            int sumOfSortableSubarrayLengths = 0;

            for (int candidateSubarrayLength = 1; candidateSubarrayLength <= totalNumberOfElements; candidateSubarrayLength++)
            {
                if (totalNumberOfElements % candidateSubarrayLength != 0)
                {
                    continue;
                }

                bool canSortUsingCurrentSubarrayLength = true;
                int previousSubarrayMaximumValue = int.MinValue;

                for (int currentSubarrayStartIndex = 0; currentSubarrayStartIndex < totalNumberOfElements; currentSubarrayStartIndex += candidateSubarrayLength)
                {
                    int currentSubarrayEndIndex = currentSubarrayStartIndex + candidateSubarrayLength - 1;

                    int currentSubarrayMinimumValue = int.MaxValue;
                    int currentSubarrayMaximumValue = int.MinValue;
                    int circularDescendingPairCount = 0;

                    for (int currentElementIndex = currentSubarrayStartIndex; currentElementIndex <= currentSubarrayEndIndex; currentElementIndex++)
                    {
                        currentSubarrayMinimumValue = Math.Min(currentSubarrayMinimumValue, numbers[currentElementIndex]);

                        currentSubarrayMaximumValue = Math.Max(currentSubarrayMaximumValue, numbers[currentElementIndex]);

                        if (currentElementIndex < currentSubarrayEndIndex && numbers[currentElementIndex] > numbers[currentElementIndex + 1])
                        {
                            circularDescendingPairCount++;
                        }
                    }

                    if (numbers[currentSubarrayEndIndex] > numbers[currentSubarrayStartIndex])
                    {
                        circularDescendingPairCount++;
                    }

                    if (circularDescendingPairCount > 1)
                    {
                        canSortUsingCurrentSubarrayLength = false;
                        break;
                    }

                    if (previousSubarrayMaximumValue > currentSubarrayMinimumValue)
                    {
                        canSortUsingCurrentSubarrayLength = false;
                        break;
                    }

                    previousSubarrayMaximumValue = currentSubarrayMaximumValue;
                }

                if (canSortUsingCurrentSubarrayLength)
                {
                    sumOfSortableSubarrayLengths += candidateSubarrayLength;
                }
            }

            return sumOfSortableSubarrayLengths;
        }
    }
}