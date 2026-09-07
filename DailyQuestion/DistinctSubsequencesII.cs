namespace DailyQuestion
{
    public class DistinctSubsequencesII
    {
        public int DistinctSubseqII(string inputString)
        {
            const int modulo = 1_000_000_007;

            long totalDistinctSubsequenceCount = 1;

            long[] distinctSubsequenceCountByCharacter = new long[26];

            foreach (char currentCharacter in inputString)
            {
                int currentCharacterIndex = currentCharacter - 'a';

                long previousDistinctSubsequenceCountForCharacter = distinctSubsequenceCountByCharacter[currentCharacterIndex];

                long updatedTotalDistinctSubsequenceCount = (2 * totalDistinctSubsequenceCount - previousDistinctSubsequenceCountForCharacter + modulo) % modulo;

                distinctSubsequenceCountByCharacter[currentCharacterIndex] = totalDistinctSubsequenceCount;

                totalDistinctSubsequenceCount = updatedTotalDistinctSubsequenceCount;
            }

            return (int)((totalDistinctSubsequenceCount - 1 + modulo) % modulo);
        }
    }
}