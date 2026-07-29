namespace DailyQuestion
{
    public class SmallestPalindromicRearrangementII
    {
        public string SmallestPalindrome(string palindrome, int targetPermutationIndex)
        {
            int[] leftHalfCharacterFrequencies = new int[26];

            for (int characterPosition = 0; characterPosition < palindrome.Length / 2; characterPosition++)
            {
                leftHalfCharacterFrequencies[palindrome[characterPosition] - 'a']++;
            }

            int processedCharacterCount = 0;
            int currentPermutationCount = 1;
            int remainingOccurrencesOfPivotCharacter = 0;
            int pivotCharacterAlphabetIndex;

            for (pivotCharacterAlphabetIndex = leftHalfCharacterFrequencies.Length - 1; pivotCharacterAlphabetIndex >= 0; pivotCharacterAlphabetIndex--)
            {
                for (int processedOccurrenceCount = 1; processedOccurrenceCount <= leftHalfCharacterFrequencies[pivotCharacterAlphabetIndex]; processedOccurrenceCount++)
                {
                    processedCharacterCount++;

                    currentPermutationCount = currentPermutationCount * processedCharacterCount / processedOccurrenceCount;

                    if (currentPermutationCount >= targetPermutationIndex)
                    {
                        remainingOccurrencesOfPivotCharacter = leftHalfCharacterFrequencies[pivotCharacterAlphabetIndex] - processedOccurrenceCount;

                        break;
                    }
                }

                if (currentPermutationCount >= targetPermutationIndex)
                {
                    break;
                }
            }

            if (currentPermutationCount < targetPermutationIndex)
            {
                return string.Empty;
            }

            char[] smallestPalindromeCharacters = new char[palindrome.Length];

            int nextInsertionIndex = 0;

            for (int alphabetIndex = 0; alphabetIndex <= pivotCharacterAlphabetIndex; alphabetIndex++)
            {
                char currentAlphabetCharacter = (char)('a' + alphabetIndex);

                int occurrencesToPlace = alphabetIndex != pivotCharacterAlphabetIndex ? leftHalfCharacterFrequencies[alphabetIndex] : remainingOccurrencesOfPivotCharacter;

                for (int occurrenceIndex = 0; occurrenceIndex < occurrencesToPlace; occurrenceIndex++)
                {
                    leftHalfCharacterFrequencies[alphabetIndex]--;

                    smallestPalindromeCharacters[nextInsertionIndex++] = currentAlphabetCharacter;
                }
            }

            while (processedCharacterCount > 0)
            {
                for (int alphabetIndex = pivotCharacterAlphabetIndex; alphabetIndex < leftHalfCharacterFrequencies.Length; alphabetIndex++)
                {
                    if (leftHalfCharacterFrequencies[alphabetIndex] == 0)
                    {
                        continue;
                    }

                    long permutationCountIfCharacterChosen = (long)currentPermutationCount * leftHalfCharacterFrequencies[alphabetIndex] / processedCharacterCount;

                    if (permutationCountIfCharacterChosen < targetPermutationIndex)
                    {
                        targetPermutationIndex -= (int)permutationCountIfCharacterChosen;
                        continue;
                    }

                    currentPermutationCount = (int)permutationCountIfCharacterChosen;

                    leftHalfCharacterFrequencies[alphabetIndex]--;
                    processedCharacterCount--;

                    smallestPalindromeCharacters[nextInsertionIndex++] = (char)('a' + alphabetIndex);

                    break;
                }
            }

            if ((palindrome.Length & 1) == 1)
            {
                smallestPalindromeCharacters[nextInsertionIndex++] = palindrome[palindrome.Length / 2];
            }

            for (int mirrorSourceIndex = nextInsertionIndex - 1 - (palindrome.Length & 1); mirrorSourceIndex >= 0; mirrorSourceIndex--)
            {
                smallestPalindromeCharacters[nextInsertionIndex++] = smallestPalindromeCharacters[mirrorSourceIndex];
            }

            return new string(smallestPalindromeCharacters);
        }
    }
}