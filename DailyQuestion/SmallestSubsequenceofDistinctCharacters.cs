namespace DailyQuestion
{
    public class SmallestSubsequenceofDistinctCharacters
    {
        public string SmallestSubsequence(string inputString)
        {
            int[] remainingCharacterFrequency = new int[26];

            foreach (char currentCharacter in inputString)
            {
                remainingCharacterFrequency[currentCharacter - 'a']++;
            }

            Stack<char> subsequenceCharacterStack = new Stack<char>();

            bool[] characterAlreadyIncluded = new bool[26];

            foreach (char currentCharacter in inputString)
            {
                int currentCharacterAlphabetIndex = currentCharacter - 'a';

                remainingCharacterFrequency[currentCharacterAlphabetIndex]--;

                if (characterAlreadyIncluded[currentCharacterAlphabetIndex])
                {
                    continue;
                }

                while (subsequenceCharacterStack.Count > 0 && currentCharacter < subsequenceCharacterStack.Peek() && remainingCharacterFrequency[subsequenceCharacterStack.Peek() - 'a'] > 0)
                {
                    char removedCharacter = subsequenceCharacterStack.Pop();

                    characterAlreadyIncluded[removedCharacter - 'a'] = false;
                }

                subsequenceCharacterStack.Push(currentCharacter);

                characterAlreadyIncluded[currentCharacterAlphabetIndex] = true;
            }

            char[] smallestSubsequenceCharacters = subsequenceCharacterStack.ToArray();

            Array.Reverse(smallestSubsequenceCharacters);

            return new string(smallestSubsequenceCharacters);
        }
    }
}