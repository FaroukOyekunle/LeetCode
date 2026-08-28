namespace DailyQuestion
{
    public class LexicographicallySmallestPalindromicPermutationGreaterThanTarget
    {
        public string LexPalindromicPermutation(string sourceString, string targetString)
        {
            int sourceStringLength = sourceString.Length;
            int palindromeHalfLength = sourceStringLength / 2;

            int[] characterFrequency = new int[26];

            foreach (char currentCharacter in sourceString)
            {
                characterFrequency[currentCharacter - 'a']++;
            }

            int oddFrequencyCharacterCount = 0;
            int middleCharacterIndex = -1;

            for (int characterIndex = 0; characterIndex < 26; characterIndex++)
            {
                if (characterFrequency[characterIndex] % 2 != 0)
                {
                    oddFrequencyCharacterCount++;
                    middleCharacterIndex = characterIndex;
                }
            }

            if (oddFrequencyCharacterCount > 1)
            {
                return string.Empty;
            }

            int[] halfPalindromeCharacterFrequency = new int[26];

            for (int characterIndex = 0; characterIndex < 26; characterIndex++)
            {
                halfPalindromeCharacterFrequency[characterIndex] = characterFrequency[characterIndex] / 2;
            }

            string targetPalindromeHalf = targetString.Substring(0, palindromeHalfLength);

            if (CanBuild(targetPalindromeHalf, halfPalindromeCharacterFrequency))
            {
                string targetPalindrome = BuildPalindrome(targetPalindromeHalf, middleCharacterIndex);

                if (string.CompareOrdinal(targetPalindrome, targetString) > 0)
                {
                    return targetPalindrome;
                }
            }

            string nextGreaterPalindromeHalf = FindNextHalf(targetPalindromeHalf, halfPalindromeCharacterFrequency);

            if (nextGreaterPalindromeHalf == string.Empty)
            {
                return string.Empty;
            }

            return BuildPalindrome(nextGreaterPalindromeHalf, middleCharacterIndex);
        }

        private bool CanBuild(string candidateHalf, int[] availableCharacterFrequency)
        {
            int[] candidateCharacterFrequency = new int[26];

            foreach (char candidateCharacter in candidateHalf)
            {
                candidateCharacterFrequency[candidateCharacter - 'a']++;
            }

            for (int characterIndex = 0; characterIndex < 26; characterIndex++)
            {
                if (candidateCharacterFrequency[characterIndex] != availableCharacterFrequency[characterIndex])
                {
                    return false;
                }
            }

            return true;
        }

        private string FindNextHalf(string targetPalindromeHalf, int[] halfPalindromeCharacterFrequency)
        {
            int palindromeHalfLength = targetPalindromeHalf.Length;

            for (int pivotPosition = palindromeHalfLength - 1; pivotPosition >= 0; pivotPosition--)
            {
                int[] remainingCharacterFrequency = (int[])halfPalindromeCharacterFrequency.Clone();

                bool canBuildTargetPrefix = true;

                for (int prefixPosition = 0; prefixPosition < pivotPosition; prefixPosition++)
                {
                    int targetCharacterIndex = targetPalindromeHalf[prefixPosition] - 'a';

                    if (remainingCharacterFrequency[targetCharacterIndex] == 0)
                    {
                        canBuildTargetPrefix = false;
                        break;
                    }

                    remainingCharacterFrequency[targetCharacterIndex]--;
                }

                if (!canBuildTargetPrefix)
                {
                    continue;
                }

                int pivotCharacterIndex = targetPalindromeHalf[pivotPosition] - 'a';

                for (int replacementCharacterIndex = pivotCharacterIndex + 1; replacementCharacterIndex < 26; replacementCharacterIndex++)
                {
                    if (remainingCharacterFrequency[replacementCharacterIndex] == 0)
                    {
                        continue;
                    }

                    StringBuilder nextPalindromeHalf = new StringBuilder(palindromeHalfLength);

                    for (int prefixPosition = 0; prefixPosition < pivotPosition; prefixPosition++)
                    {
                        nextPalindromeHalf.Append(targetPalindromeHalf[prefixPosition]);
                    }

                    nextPalindromeHalf.Append((char)('a' + replacementCharacterIndex));

                    remainingCharacterFrequency[replacementCharacterIndex]--;

                    for (int characterIndex = 0; characterIndex < 26; characterIndex++)
                    {
                        while (remainingCharacterFrequency[characterIndex] > 0)
                        {
                            nextPalindromeHalf.Append((char)('a' + characterIndex));

                            remainingCharacterFrequency[characterIndex]--;
                        }
                    }

                    return nextPalindromeHalf.ToString();
                }
            }

            return string.Empty;
        }

        private string BuildPalindrome(string palindromeFirstHalf, int middleCharacterIndex)
        {
            int palindromeLength = palindromeFirstHalf.Length * 2 + (middleCharacterIndex == -1 ? 0 : 1);

            StringBuilder palindromeBuilder = new StringBuilder(palindromeLength);

            palindromeBuilder.Append(palindromeFirstHalf);

            if (middleCharacterIndex != -1)
            {
                palindromeBuilder.Append((char)('a' + middleCharacterIndex));
            }

            for (int characterPosition = palindromeFirstHalf.Length - 1; characterPosition >= 0; characterPosition--)
            {
                palindromeBuilder.Append(palindromeFirstHalf[characterPosition]);
            }

            return palindromeBuilder.ToString();
        }
    }
}