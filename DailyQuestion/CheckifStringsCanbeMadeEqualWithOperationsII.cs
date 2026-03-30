namespace DailyQuestion
{
    public class CheckifStringsCanbeMadeEqualWithOperationsII
    {
        public bool AreStringsEquivalentUnderEvenOddIndexSwaps(string firstString, string secondString)
        {
            int stringLength = firstString.Length;

            int[] firstStringEvenIndexFrequencies = new int[26];
            int[] secondStringEvenIndexFrequencies = new int[26];

            int[] firstStringOddIndexFrequencies = new int[26];
            int[] secondStringOddIndexFrequencies = new int[26];

            for (int currentIndex = 0; currentIndex < stringLength; currentIndex++)
            {
                int firstStringCharacterIndex = firstString[currentIndex] - 'a';
                int secondStringCharacterIndex = secondString[currentIndex] - 'a';

                bool isEvenIndex = currentIndex % 2 == 0;

                if (isEvenIndex)
                {
                    firstStringEvenIndexFrequencies[firstStringCharacterIndex]++;
                    secondStringEvenIndexFrequencies[secondStringCharacterIndex]++;
                }
                else
                {
                    firstStringOddIndexFrequencies[firstStringCharacterIndex]++;
                    secondStringOddIndexFrequencies[secondStringCharacterIndex]++;
                }
            }

            for (int alphabetIndex = 0; alphabetIndex < 26; alphabetIndex++)
            {
                bool isEvenFrequencyMismatch =
                    firstStringEvenIndexFrequencies[alphabetIndex] !=
                    secondStringEvenIndexFrequencies[alphabetIndex];

                bool isOddFrequencyMismatch =
                    firstStringOddIndexFrequencies[alphabetIndex] !=
                    secondStringOddIndexFrequencies[alphabetIndex];

                if (isEvenFrequencyMismatch || isOddFrequencyMismatch)
                {
                    return false;
                }
            }

            return true;
        }
    }
}