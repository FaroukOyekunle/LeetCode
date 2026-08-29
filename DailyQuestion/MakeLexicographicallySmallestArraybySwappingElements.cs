namespace DailyQuestion
{
    public class MakeLexicographicallySmallestArraybySwappingElements
    {
        public int[] LexicographicallySmallestArray(int[] numbers, int maximumAllowedDifference)
        {
            int numberCount = numbers.Length;

            var sortedElements = new (int Value, int OriginalIndex)[numberCount];

            for (int elementIndex = 0; elementIndex < numberCount; elementIndex++)
            {
                sortedElements[elementIndex] = (numbers[elementIndex], elementIndex);
            }

            Array.Sort(xsortedElements,(firstElement, secondElement) => firstElement.Value.CompareTo(secondElement.Value));

            int currentGroupStartIndex = 0;

            while (currentGroupStartIndex < numberCount)
            {
                int currentGroupEndIndex = currentGroupStartIndex;

                while (currentGroupEndIndex + 1 < numberCount && (long)sortedElements[currentGroupEndIndex + 1].Value - sortedElements[currentGroupEndIndex].Value <= maximumAllowedDifference)
                {
                    currentGroupEndIndex++;
                }

                int groupElementCount = currentGroupEndIndex - currentGroupStartIndex + 1;

                int[] groupOriginalIndices = new int[groupElementCount];
                int[] groupValues = new int[groupElementCount];

                for (int sortedElementIndex = currentGroupStartIndex; sortedElementIndex <= currentGroupEndIndex; sortedElementIndex++)
                {
                    int groupElementIndex = sortedElementIndex - currentGroupStartIndex;

                    groupOriginalIndices[groupElementIndex] = sortedElements[sortedElementIndex].OriginalIndex;

                    groupValues[groupElementIndex] = sortedElements[sortedElementIndex].Value;
                }

                Array.Sort(groupOriginalIndices);

                for (int groupElementIndex = 0; groupElementIndex < groupValues.Length; groupElementIndex++)
                {
                    int originalArrayIndex = groupOriginalIndices[groupElementIndex];

                    numbers[originalArrayIndex] = groupValues[groupElementIndex];
                }

                currentGroupStartIndex = currentGroupEndIndex + 1;
            }

            return numbers;
        }
    }
}