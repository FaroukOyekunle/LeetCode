namespace DailyQuestion
{
    public class MinimumNumberofPushestoTypeWordII
    {
        public int MinimumPushes(string word)
        {
            int[] letterFrequencyByAlphabet = new int[26];

            foreach (char currentCharacter in word)
            {
                letterFrequencyByAlphabet[currentCharacter - 'a']++;
            }

            Array.Sort(letterFrequencyByAlphabet);
            Array.Reverse(letterFrequencyByAlphabet);

            int minimumKeyPresses = 0;

            for (int letterFrequencyIndex = 0; letterFrequencyIndex < 26; letterFrequencyIndex++)
            {
                if (letterFrequencyByAlphabet[letterFrequencyIndex] == 0)
                {
                    break;
                }

                int keyPressCostForCurrentLetter = (letterFrequencyIndex / 8) + 1;

                minimumKeyPresses += letterFrequencyByAlphabet[letterFrequencyIndex] * keyPressCostForCurrentLetter;
            }

            return minimumKeyPresses;
        }
    }
}