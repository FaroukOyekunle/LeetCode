namespace DailyQuestion
{
    public class ReverseDegreeofAString
    {
        public int ReverseDegree(string inputString)
        {
            int totalReverseDegree = 0;

            for (int characterIndex = 0; characterIndex < inputString.Length; characterIndex++)
            {
                int currentCharacterAlphabetPosition = inputString[characterIndex] - 'a' + 1;

                int currentCharacterReverseAlphabetPosition = 26 - currentCharacterAlphabetPosition + 1;

                int currentCharacterStringPosition = characterIndex + 1;

                totalReverseDegree += currentCharacterReverseAlphabetPosition * currentCharacterStringPosition;
            }

            return totalReverseDegree;
        }
    }
}