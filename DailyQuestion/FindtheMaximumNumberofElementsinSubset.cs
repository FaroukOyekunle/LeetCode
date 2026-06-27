namespace DailyQuestion
{
    public class FindtheMaximumNumberofElementsinSubset
    {
        public int MaximumLength(int[] numbers)
        {
            Dictionary<long, int> valueOccurrenceCount = new Dictionary<long, int>();

            foreach (int currentNumber in numbers)
            {
                valueOccurrenceCount[currentNumber] = valueOccurrenceCount.GetValueOrDefault(currentNumber) + 1;
            }

            int longestValidSubsetLength = 1;

            if (valueOccurrenceCount.TryGetValue(1, out int countOfOnes))
            {
                int usableOneChainLength = countOfOnes % 2 == 0 ? countOfOnes - 1 : countOfOnes;

                longestValidSubsetLength = Math.Max(longestValidSubsetLength, usableOneChainLength);
            }

            foreach (KeyValuePair<long, int> valueFrequencyEntry in valueOccurrenceCount)
            {
                long currentChainValue = valueFrequencyEntry.Key;

                if (currentChainValue == 1)
                {
                    continue;
                }

                int currentSubsetLength = 0;

                while (valueOccurrenceCount.TryGetValue(currentChainValue, out int currentValueCount) && currentValueCount >= 2)
                {
                    currentSubsetLength += 2;

                    bool squaringWouldOverflow = currentChainValue > Math.Sqrt(long.MaxValue);

                    if (squaringWouldOverflow)
                    {
                        break;
                    }

                    currentChainValue *= currentChainValue;
                }

                bool finalCenterValueExists = valueOccurrenceCount.ContainsKey(currentChainValue);

                if (
                    finalCenterValueExists
                )
                {
                    currentSubsetLength += 1;
                }
                else
                {
                    currentSubsetLength -= 1;
                }

                longestValidSubsetLength = Math.Max(longestValidSubsetLength, currentSubsetLength);
            }

            return longestValidSubsetLength;
        }
    }
}