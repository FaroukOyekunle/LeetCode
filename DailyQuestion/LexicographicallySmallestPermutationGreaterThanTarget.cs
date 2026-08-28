namespace DailyQuestion
{
    public class LexicographicallySmallestPermutationGreaterThanTarget
    {
        public string LexGreaterPermutation(string sourceString, string targetString)
        {
            char FindNextGreaterCharacter(int[] characterFrequency, char currentCharacter)
            {
                int firstGreaterCharacterIndex = (currentCharacter - 'a') + 1;

                for (int characterIndex = firstGreaterCharacterIndex; characterIndex < characterFrequency.Length; characterIndex++)
                {
                    if (characterFrequency[characterIndex] == 0)
                    {
                        continue;
                    }

                    return (char)('a' + characterIndex);
                }

                return ' ';
            }

            int[] sourceCharacterFrequency = new int[26];

            foreach (char sourceCharacter in sourceString)
            {
                sourceCharacterFrequency[sourceCharacter - 'a']++;
            }

            int[] remainingCharacterFrequency = (int[])sourceCharacterFrequency.Clone();

            int lastPossibleGreaterPosition = -1;

            for (int targetPosition = 0; targetPosition < targetString.Length; targetPosition++)
            {
                char nextGreaterCharacter = FindNextGreaterCharacter(remainingCharacterFrequency, targetString[targetPosition]);

                if (nextGreaterCharacter != ' ')
                {
                    lastPossibleGreaterPosition = targetPosition;
                }

                int targetCharacterIndex = targetString[targetPosition] - 'a';

                if (remainingCharacterFrequency[targetCharacterIndex] == 0)
                {
                    break;
                }

                remainingCharacterFrequency[targetCharacterIndex]--;
            }

            if (lastPossibleGreaterPosition == -1)
            {
                return string.Empty;
            }

            string resultString = string.Empty;

            for (int targetPosition = 0; targetPosition < lastPossibleGreaterPosition; targetPosition++)
            {
                char targetCharacter = targetString[targetPosition];

                resultString += targetCharacter;
                sourceCharacterFrequency[targetCharacter - 'a']--;
            }

            char replacementCharacter = FindNextGreaterCharacter(sourceCharacterFrequency, targetString[lastPossibleGreaterPosition]);

            resultString += replacementCharacter;
            sourceCharacterFrequency[replacementCharacter - 'a']--;

            for (int characterIndex = 0; characterIndex < sourceCharacterFrequency.Length; characterIndex++)
            {
                while (sourceCharacterFrequency[characterIndex] > 0)
                {
                    char remainingCharacter = (char)('a' + characterIndex);

                    resultString += remainingCharacter;
                    sourceCharacterFrequency[characterIndex]--;
                }
            }

            return resultString;
        }
    }
}