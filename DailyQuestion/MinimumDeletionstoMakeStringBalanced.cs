namespace DailyQuestion
{
    public class MinimumDeletionstoMakeStringBalanced
    {
        public int CalculateMinimumDeletionsToMakeStringBalanced(string inputString)
        {
            int totalBCharactersEncountered = 0;

            int minimumDeletionCount = 0;

            foreach (char currentCharacter in inputString)
            {
                if (currentCharacter == 'b')
                {
                    totalBCharactersEncountered++;
                }

                else
                {
                    minimumDeletionCount = Math.Min(minimumDeletionCount + 1, totalBCharactersEncountered);
                }
            }

            return minimumDeletionCount;
        }

    }
}