namespace DailyQuestion
{
    public class NumberofStringsThatAppearasSubstringsinWord
    {
        public int NumOfStrings(string[] candidatePatterns, string targetWord)
        {
            int totalMatchingPatternCount = 0;

            foreach (string currentPattern in candidatePatterns)
            {
                bool doesPatternExistInTargetWord = targetWord.Contains(currentPattern);

                if (doesPatternExistInTargetWord)
                {
                    totalMatchingPatternCount++;
                }
            }

            return totalMatchingPatternCount;
        }
    }
}