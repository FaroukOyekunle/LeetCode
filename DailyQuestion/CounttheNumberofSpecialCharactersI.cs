namespace DailyQuestion
{
    public class CounttheNumberofSpecialCharactersI
    {
        public int NumberOfSpecialCharacters(string inputWord)
        {
            HashSet<char> discoveredLowercaseCharacters = new HashSet<char>();

            HashSet<char> discoveredUppercaseCharacters = new HashSet<char>();

            foreach (char currentCharacter in inputWord)
            {
                if (char.IsLower(currentCharacter))
                {
                    discoveredLowercaseCharacters.Add(currentCharacter);
                }
                else
                {
                    char normalizedLowercaseCharacter = char.ToLower(currentCharacter);

                    discoveredUppercaseCharacters.Add(normalizedLowercaseCharacter);
                }
            }

            int totalSpecialCharacterCount = 0;

            foreach (char lowercaseCharacter in discoveredLowercaseCharacters)
            {
                bool characterExistsInUppercaseForm = discoveredUppercaseCharacters.Contains(lowercaseCharacter);

                if (characterExistsInUppercaseForm)
                {
                    totalSpecialCharacterCount++;
                }
            }

            return totalSpecialCharacterCount;
        }
    }
}