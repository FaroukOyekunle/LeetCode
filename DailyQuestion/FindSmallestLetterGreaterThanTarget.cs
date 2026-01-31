namespace DailyQuestion
{
    public class FindSmallestLetterGreaterThanTarget
    {
        public char FindNextGreatestLetter(char[] sortedLetters, char targetLetter)
        {
            int lowerBound = 0;
            int upperBound = sortedLetters.Length - 1;

            while (lowerBound <= upperBound) 
            {
                int middleIndex = lowerBound + (upperBound - lowerBound) / 2;

                if (sortedLetters[middleIndex] <= targetLetter) 
                {
                    lowerBound = middleIndex + 1;
                } 
                else 
                {
                    upperBound = middleIndex - 1;
                }
            }

            return sortedLetters[lowerBound % sortedLetters.Length];
        }
    }
}