namespace DailyQuestion
{
    public class UniqueLength3PalindromicSubsequences
    {
        public int CountUniqueLength3PalindromicSubsequences(string text)
        {
            int length = text.Length;
            int totalCount = 0;

            int[] firstOccurrence = Enumerable.Repeat(-1, 26).ToArray();
            int[] lastOccurrence = Enumerable.Repeat(-1, 26).ToArray();

            for (int index = 0; index < length; index++)
            {
                int charIndex = text[index] - 'a';

                if(firstOccurrence[charIndex] == -1)
                {
                    firstOccurrence[charIndex] = index;
                }
                
                lastOccurrence[charIndex] = index;
            }

            for(int letter = 0; letter < 26; letter++)
            {
                if(firstOccurrence[letter] == -1 || firstOccurrence[letter] == lastOccurrence[letter])
                {
                    continue;
                }

                int leftIndex = firstOccurrence[letter];
                int rightIndex = lastOccurrence[letter];

                var middleChars = new HashSet<char>();

                for(int mid = leftIndex + 1; mid < rightIndex; mid++)
                {
                    middleChars.Add(text[mid]);
                }

                totalCount += middleChars.Count;
            }

            return totalCount;
        }
    }
}