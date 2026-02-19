namespace DailyQuestion
{
    public class CountBinarySubstrings
    {
        public int CountBinarySubstringsWithBalancedGroups(string binaryString)
        {
            int balancedSubstringCount = 0;

            int previousGroupLength = 0;
            int currentGroupLength = 1; 

            for (int currentIndex = 1; currentIndex < binaryString.Length; currentIndex++)
            {
                if (binaryString[currentIndex] == binaryString[currentIndex - 1])
                {
                    currentGroupLength++;
                }
                else
                {
                    balancedSubstringCount += Math.Min(previousGroupLength, currentGroupLength);

                    previousGroupLength = currentGroupLength;
                    currentGroupLength = 1;
                }
            }

            balancedSubstringCount += Math.Min(previousGroupLength, currentGroupLength);

            return balancedSubstringCount;
        }
    }
}