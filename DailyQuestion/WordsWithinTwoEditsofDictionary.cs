namespace DailyQuestion
{
    public class WordsWithinTwoEditsofDictionary
    {
        public IList<string> FindWordsWithinTwoEdits(string[] queryWords, string[] dictionaryWords)
        {
            var matchingQueryWords = new List<string>();

            foreach (string currentQueryWord in queryWords)
            {
                foreach (string currentDictionaryWord in dictionaryWords)
                {
                    int characterDifferenceCount = 0;

                    for (int characterIndex = 0; characterIndex < currentQueryWord.Length; characterIndex++)
                    {
                        if (currentQueryWord[characterIndex] != currentDictionaryWord[characterIndex])
                        {
                            characterDifferenceCount++;

                            if (characterDifferenceCount > 2)
                            {
                                break;
                            }
                        }
                    }

                    if (characterDifferenceCount <= 2)
                    {
                        matchingQueryWords.Add(currentQueryWord);
                        break; 
                    }
                }
            }

            return matchingQueryWords;
        }
    }
}