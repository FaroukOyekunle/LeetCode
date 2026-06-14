namespace DailyQuestion
{
    public class WeightedWordMapping
    {
        public string MapWordWeights(string[] inputWords, int[] alphabetCharacterWeights)
        {
            StringBuilder encodedWordSequence =  new StringBuilder();

            foreach (string currentWord in inputWords)
            {
                int totalWeightForCurrentWord = 0;

                foreach (char currentCharacter in currentWord)
                {
                    int characterPositionInAlphabet = currentCharacter - 'a';

                    totalWeightForCurrentWord += alphabetCharacterWeights[characterPositionInAlphabet];
                }

                int normalizedWeightWithinAlphabetRange = totalWeightForCurrentWord % 26;

                char mappedOutputCharacter = (char)('z' - normalizedWeightWithinAlphabetRange);

                encodedWordSequence.Append(mappedOutputCharacter);
            }

            return encodedWordSequence.ToString();
        }
    }
}