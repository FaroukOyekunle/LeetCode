namespace DailyQuestion
{
    public class MinimumNumberofPushestoTypeWordI
    {
        public int MinimumPushes(string word)
        {
            int minimumPushCount = 0;

            for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
            {
                int pushesRequiredForCurrentLetter = (letterIndex / 8) + 1;
                minimumPushCount += pushesRequiredForCurrentLetter;
            }

            return minimumPushCount;
        }
    }
}