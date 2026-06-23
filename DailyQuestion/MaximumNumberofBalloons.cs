namespace DailyQuestion
{
    public class MaximumNumberofBalloons
    {
        public int MaxNumberOfBalloons(string inputText)
        {
            int[] letterOccurrenceCount = new int[26];

            foreach (char currentLetter in inputText)
            {
                letterOccurrenceCount[currentLetter - 'a']++;
            }

            int availableCountOfB = letterOccurrenceCount['b' - 'a'];

            int availableCountOfA = letterOccurrenceCount['a' - 'a'];

            int availableCountOfL = letterOccurrenceCount['l' - 'a'] / 2;

            int availableCountOfO = letterOccurrenceCount['o' - 'a'] / 2;

            int availableCountOfN = letterOccurrenceCount['n' - 'a'];

            int maximumBalloonWordCount = Math.Min(Math.Min(availableCountOfB, availableCountOfA), Math.Min(Math.Min(availableCountOfL, availableCountOfO), availableCountOfN));

            return maximumBalloonWordCount;
        }
    }
}