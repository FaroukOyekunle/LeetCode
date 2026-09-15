namespace DailyQuestion
{
    public class MaximumNumberofNonOverlappingPalindromeSubstrings
    {
        public int MaxPalindromes(string inputString, int minimumPalindromeLength)
        {
            int inputStringLength = inputString.Length;

            bool[,] isPalindromeByStartAndEnd = new bool[inputStringLength, inputStringLength];

            for (int palindromeLength = 1; palindromeLength <= inputStringLength; palindromeLength++)
            {
                for (int palindromeStartIndex = 0; palindromeStartIndex + palindromeLength <= inputStringLength; palindromeStartIndex++)
                {
                    int palindromeEndIndex = palindromeStartIndex + palindromeLength - 1;

                    if (palindromeLength == 1)
                    {
                        isPalindromeByStartAndEnd[palindromeStartIndex, palindromeEndIndex] = true;
                    }
                    else if (palindromeLength == 2)
                    {
                        isPalindromeByStartAndEnd[palindromeStartIndex, palindromeEndIndex] = inputString[palindromeStartIndex] == inputString[palindromeEndIndex];
                    }
                    else
                    {
                        isPalindromeByStartAndEnd[palindromeStartIndex, palindromeEndIndex] = inputString[palindromeStartIndex] == inputString[palindromeEndIndex] 
                            && isPalindromeByStartAndEnd[palindromeStartIndex + 1, palindromeEndIndex - 1];
                    }
                }
            }

            int[] maximumPalindromeCountByPrefixLength = new int[inputStringLength + 1];

            for (int currentPrefixEndIndex = 1; currentPrefixEndIndex <= inputStringLength; currentPrefixEndIndex++)
            {
                maximumPalindromeCountByPrefixLength[currentPrefixEndIndex] = maximumPalindromeCountByPrefixLength[currentPrefixEndIndex - 1];

                for (int palindromeStartIndex = 0; palindromeStartIndex < currentPrefixEndIndex; palindromeStartIndex++)
                {
                    int currentPalindromeLength = currentPrefixEndIndex - palindromeStartIndex;

                    if (currentPalindromeLength >= minimumPalindromeLength && isPalindromeByStartAndEnd[palindromeStartIndex, currentPrefixEndIndex - 1])
                    {
                        maximumPalindromeCountByPrefixLength[currentPrefixEndIndex] =
                            Math.Max(maximumPalindromeCountByPrefixLength[currentPrefixEndIndex], maximumPalindromeCountByPrefixLength[palindromeStartIndex] + 1);
                    }
                }
            }

            return maximumPalindromeCountByPrefixLength[inputStringLength];
        }
    }
}