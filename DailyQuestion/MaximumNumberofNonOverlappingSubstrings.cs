namespace DailyQuestion
{
    public class MaximumNumberofNonOverlappingSubstrings
    {
        public IList<string> MaxNumOfSubstrings(string inputString)
        {
            int inputStringLength = inputString.Length;

            int[] firstOccurrenceIndexByCharacter = new int[26];
            int[] lastOccurrenceIndexByCharacter = new int[26];

            Array.Fill(firstOccurrenceIndexByCharacter, inputStringLength);
            Array.Fill(lastOccurrenceIndexByCharacter, -1);

            for (int currentIndex = 0; currentIndex < inputStringLength; currentIndex++)
            {
                int currentCharacterIndex = inputString[currentIndex] - 'a';

                firstOccurrenceIndexByCharacter[currentCharacterIndex] = Math.Min(firstOccurrenceIndexByCharacter[currentCharacterIndex], currentIndex);

                lastOccurrenceIndexByCharacter[currentCharacterIndex] = currentIndex;
            }

            var validSubstringIntervals = new List<(int startIndex, int endIndex)>();

            for (int characterIndex = 0; characterIndex < 26; characterIndex++)
            {
                if (lastOccurrenceIndexByCharacter[characterIndex] == -1)
                {
                    continue;
                }

                int substringStartIndex = firstOccurrenceIndexByCharacter[characterIndex];

                int substringEndIndex = lastOccurrenceIndexByCharacter[characterIndex];

                bool isValidSubstringInterval = true;

                for (int currentIndex = substringStartIndex; currentIndex <= substringEndIndex; currentIndex++)
                {
                    int currentCharacterIndex = inputString[currentIndex] - 'a';

                    if (firstOccurrenceIndexByCharacter[currentCharacterIndex] < substringStartIndex)
                    {
                        isValidSubstringInterval = false;
                        break;
                    }

                    substringEndIndex = Math.Max(substringEndIndex, lastOccurrenceIndexByCharacter[currentCharacterIndex]);
                }

                if (isValidSubstringInterval)
                {
                    validSubstringIntervals.Add((substringStartIndex, substringEndIndex));
                }
            }

            validSubstringIntervals.Sort(
                (firstInterval, secondInterval) =>
                {
                    if (firstInterval.endIndex != secondInterval.endIndex)
                    {
                        return firstInterval.endIndex.CompareTo(secondInterval.endIndex);
                    }

                    return firstInterval.startIndex.CompareTo(secondInterval.startIndex);
                });

            var selectedSubstrings = new List<string>();

            int previousSelectedSubstringEndIndex = -1;

            foreach (var (substringStartIndex, substringEndIndex) in validSubstringIntervals)
            {
                if (substringStartIndex > previousSelectedSubstringEndIndex)
                {
                    selectedSubstrings.Add(inputString.Substring(substringStartIndex, substringEndIndex - substringStartIndex + 1));

                    previousSelectedSubstringEndIndex = substringEndIndex;
                }
            }

            return selectedSubstrings;
        }
    }
}