using System;

namespace DailyQuestion
{
    public class MinimumNumberofChangestoMakeBinaryStringBeautiful
    {

        public int MinChanges(string binaryString)
        {
            int minimumChangesRequired = 0;

            for (int pairStartIndex = 0; pairStartIndex < binaryString.Length; pairStartIndex += 2)
            {
                int firstCharacterIndex = pairStartIndex;
                int secondCharacterIndex = pairStartIndex + 1;

                if (binaryString[firstCharacterIndex] != binaryString[secondCharacterIndex])
                {
                    minimumChangesRequired++;
                }
            }

            return minimumChangesRequired;
        }
    }
}