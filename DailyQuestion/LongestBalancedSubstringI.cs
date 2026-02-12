namespace DailyQuestion
{
    public class LongestBalancedSubstringI
    {
        public int CalculateLongestBalancedSubstringLength(string inputString)
        {
            int totalCharacterCount = inputString.Length;

            int longestBalancedSubstringLength = 0;

            for (int substringStartIndex = 0; substringStartIndex < totalCharacterCount; substringStartIndex++)
            {
                int[] characterFrequencyByAlphabetIndex = new int[26];

                for (int substringEndIndex = substringStartIndex; substringEndIndex < totalCharacterCount; substringEndIndex++)
                {
                    int alphabetIndex = inputString[substringEndIndex] - 'a';

                    characterFrequencyByAlphabetIndex[alphabetIndex]++;

                    if (HasBalancedCharacterFrequencies(characterFrequencyByAlphabetIndex))
                    {
                        int currentSubstringLength = substringEndIndex - substringStartIndex + 1;

                        longestBalancedSubstringLength = Math.Max(longestBalancedSubstringLength, currentSubstringLength);
                    }
                }
            }

            return longestBalancedSubstringLength;
        }


        private bool HasBalancedCharacterFrequencies(int[] characterFrequencyByAlphabetIndex)
        {
            int expectedFrequencyForAllCharacters = 0;

            foreach (int characterCount in characterFrequencyByAlphabetIndex)
            {
                if (characterCount == 0)
                {
                    continue;
                }

                if (expectedFrequencyForAllCharacters == 0)
                {
                    expectedFrequencyForAllCharacters = characterCount;
                }
                else if (characterCount != expectedFrequencyForAllCharacters)
                {
                    return false;
                }
            }

            return expectedFrequencyForAllCharacters > 0;
        }
    }
}