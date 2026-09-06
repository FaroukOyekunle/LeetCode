namespace DailyQuestion
{
    public class DistinctSubsequences
    {
        public int NumDistinct(string sourceString, string targetString)
        {
            int sourceStringLength = sourceString.Length;
            int targetStringLength = targetString.Length;

            long[] subsequenceCountByTargetLength = new long[targetStringLength + 1];

            subsequenceCountByTargetLength[0] = 1;

            for (int sourceCharacterIndex = 0; sourceCharacterIndex < sourceStringLength; sourceCharacterIndex++)
            {
                for (int targetCharacterIndex = targetStringLength; targetCharacterIndex >= 1; targetCharacterIndex--)
                {
                    if (sourceString[sourceCharacterIndex] == targetString[targetCharacterIndex - 1])
                    {
                        subsequenceCountByTargetLength[targetCharacterIndex] += subsequenceCountByTargetLength[targetCharacterIndex - 1];
                    }
                }
            }

            return (int)subsequenceCountByTargetLength[targetStringLength];
        }
    }
}