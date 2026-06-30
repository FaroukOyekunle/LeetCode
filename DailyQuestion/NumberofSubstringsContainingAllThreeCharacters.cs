namespace DailyQuestion
{
    public class NumberofSubstringsContainingAllThreeCharacters
    {
        public int NumberOfSubstrings(string inputString)
        {
            int[] characterFrequencyInWindow = new int[3];

            int windowStartIndex = 0;

            int totalValidSubstringCount = 0;

            for (int windowEndIndex = 0; windowEndIndex < inputString.Length; windowEndIndex++)
            {
                characterFrequencyInWindow[inputString[windowEndIndex] - 'a']++;

                while (characterFrequencyInWindow[0] > 0 && characterFrequencyInWindow[1] > 0 && characterFrequencyInWindow[2] > 0)
                {
                    totalValidSubstringCount += inputString.Length - windowEndIndex;

                    characterFrequencyInWindow[inputString[windowStartIndex] - 'a']--;

                    windowStartIndex++;
                }
            }

            return totalValidSubstringCount;
        }
    }
}