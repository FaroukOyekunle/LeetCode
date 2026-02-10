namespace DailyQuestion
{
    public class LongestBalancedSubarrayI
    {
        public int FindLongestBalancedSubarray(int[] inputArray)
        {
            int arrayLength = inputArray.Length;
            int maximumBalancedLength = 0;

            for (int startIndex = 0; startIndex < arrayLength; startIndex++)
            {
                HashSet<int> evenNumbersSet = new HashSet<int>();
                HashSet<int> oddNumbersSet = new HashSet<int>();

                for (int endIndex = startIndex; endIndex < arrayLength; endIndex++)
                {
                    int currentNumber = inputArray[endIndex];

                    if (currentNumber % 2 == 0)
                    {
                        evenNumbersSet.Add(currentNumber);
                    }
                    else
                    {
                        oddNumbersSet.Add(currentNumber);
                    }

                    if (evenNumbersSet.Count == oddNumbersSet.Count)
                    {
                        int currentSubarrayLength = endIndex - startIndex + 1;
                        maximumBalancedLength = Math.Max(maximumBalancedLength, currentSubarrayLength);
                    }
                }
            }

            return maximumBalancedLength;
        }
    }
}