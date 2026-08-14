namespace DailyQuestion
{
    public class MaximumLengthSubstringWithTwoOccurrences
    {
        public int MaximumLengthSubstring(string inputString)
        {
            int[] characterFrequency = new int[26];

            int windowStartIndex = 0;
            int maximumValidSubstringLength = 0;

            for (int windowEndIndex = 0; windowEndIndex < inputString.Length; windowEndIndex++)
            {
                int currentCharacterIndex = inputString[windowEndIndex] - 'a';
                characterFrequency[currentCharacterIndex]++;

                while (characterFrequency[currentCharacterIndex] > 2)
                {
                    int leftmostCharacterIndex = inputString[windowStartIndex] - 'a';
                    characterFrequency[leftmostCharacterIndex]--;
                    windowStartIndex++;
                }

                int currentValidSubstringLength = windowEndIndex - windowStartIndex + 1;

                maximumValidSubstringLength = Math.Max(maximumValidSubstringLength, currentValidSubstringLength);
            }

            return maximumValidSubstringLength;
        }
    }
}