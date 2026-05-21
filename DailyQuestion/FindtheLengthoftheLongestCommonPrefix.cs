namespace DailyQuestion
{
    public class FindtheLengthoftheLongestCommonPrefix
    {
        public int LongestCommonPrefix(int[] firstArray, int[] secondArray)
        {
            HashSet<int> allPrefixValuesFromFirstArray = new HashSet<int>();

            foreach (int currentNumberFromFirstArray in firstArray)
            {
                int currentPrefixValue = 0;

                string numberAsString = currentNumberFromFirstArray.ToString();

                foreach (char digitCharacter in numberAsString)
                {
                    int digitValue = digitCharacter - '0';

                    currentPrefixValue = currentPrefixValue * 10 + digitValue;

                    allPrefixValuesFromFirstArray.Add(currentPrefixValue);
                }
            }

            int longestCommonPrefixLength = 0;

            foreach (int currentNumberFromSecondArray in secondArray)
            {
                int currentPrefixValue = 0;

                string numberAsString = currentNumberFromSecondArray.ToString();

                for (int digitIndex = 0; digitIndex < numberAsString.Length; digitIndex++)
                {
                    int digitValue = numberAsString[digitIndex] - '0';

                    currentPrefixValue = currentPrefixValue * 10 + digitValue;

                    bool prefixExistsInFirstArray = allPrefixValuesFromFirstArray.Contains(currentPrefixValue);

                    if (prefixExistsInFirstArray)
                    {
                        longestCommonPrefixLength = Math.Max(longestCommonPrefixLength, digitIndex + 1);
                    }
                }
            }

            return longestCommonPrefixLength;
        }
    }
}