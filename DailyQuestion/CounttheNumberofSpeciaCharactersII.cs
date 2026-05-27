namespace DailyQuestion
{
    public class CounttheNumberofSpeciaCharactersII
    {
        public int NumberOfSpecialCharacters(string inputWord)
        {
            Dictionary<char, int> lowercaseCharacterLastIndexMap = new Dictionary<char, int>();

            Dictionary<char, int> uppercaseCharacterFirstIndexMap = new Dictionary<char, int>();

            for (int currentIndex = 0; currentIndex < inputWord.Length; currentIndex++)
            {
                char currentCharacter = inputWord[currentIndex];

                if (char.IsLower(currentCharacter))
                {
                    lowercaseCharacterLastIndexMap[currentCharacter] = currentIndex;
                }
                else
                {
                    char normalizedLowercaseCharacter = char.ToLower(currentCharacter);

                    if (!uppercaseCharacterFirstIndexMap.ContainsKey(normalizedLowercaseCharacter))
                    {
                        uppercaseCharacterFirstIndexMap[normalizedLowercaseCharacter] = currentIndex;
                    }
                }
            }

            int totalSpecialCharacterCount = 0;

            foreach (KeyValuePair<char, int> lowercaseCharacterEntry in lowercaseCharacterLastIndexMap)
            {
                char currentLetter = lowercaseCharacterEntry.Key;

                int lastLowercaseOccurrenceIndex = lowercaseCharacterEntry.Value;

                bool uppercaseVersionExists = uppercaseCharacterFirstIndexMap.ContainsKey(currentLetter);

                if (uppercaseVersionExists)
                {
                    int firstUppercaseOccurrenceIndex = uppercaseCharacterFirstIndexMap[currentLetter];

                    bool lowercaseAppearsBeforeUppercase = lastLowercaseOccurrenceIndex < firstUppercaseOccurrenceIndex;

                    if (lowercaseAppearsBeforeUppercase)
                    {
                        totalSpecialCharacterCount++;
                    }
                }
            }

            return totalSpecialCharacterCount;
        }
    }
}