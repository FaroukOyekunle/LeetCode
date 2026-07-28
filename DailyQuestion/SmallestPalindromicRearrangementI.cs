namespace DailyQuestion
{
    public class SmallestPalindromicRearrangementI
    {
        public string SmallestPalindrome(string inputString)
        {
            int[] characterFrequency = new int[26];

            foreach (char currentCharacter in inputString)
            {
                characterFrequency[currentCharacter - 'a']++;
            }

            StringBuilder leftHalfOfPalindrome = new StringBuilder();
            char palindromeCenterCharacter = '\0';

            for (int alphabetIndex = 0; alphabetIndex < 26; alphabetIndex++)
            {
                int characterOccurrenceCount = characterFrequency[alphabetIndex];

                for (int occurrenceIndex = 0; occurrenceIndex < characterOccurrenceCount / 2; occurrenceIndex++)
                {
                    leftHalfOfPalindrome.Append((char)('a' + alphabetIndex));
                }

                if (characterOccurrenceCount % 2 == 1)
                {
                    palindromeCenterCharacter = (char)('a' + alphabetIndex);
                }
            }

            char[] rightHalfOfPalindromeCharacters = leftHalfOfPalindrome.ToString().ToCharArray();

            Array.Reverse(rightHalfOfPalindromeCharacters);

            StringBuilder lexicographicallySmallestPalindrome = new StringBuilder();

            lexicographicallySmallestPalindrome.Append(leftHalfOfPalindrome);

            if (palindromeCenterCharacter != '\0')
            {
                lexicographicallySmallestPalindrome.Append(palindromeCenterCharacter);
            }

            lexicographicallySmallestPalindrome.Append(rightHalfOfPalindromeCharacters);

            return lexicographicallySmallestPalindrome.ToString();
        }
    }
}