namespace DailyQuestion
{
    public class ShortestandLexicographicallySmallestBeautifulString
    {
        public string ShortestBeautifulSubstring(string binaryString, int requiredOneCount)
        {
            int windowStartIndex = 0;
            int currentOneCount = 0;
            int shortestBeautifulLength = int.MaxValue;
            string lexicographicallySmallestResult = string.Empty;

            for (int windowEndIndex = 0; windowEndIndex < binaryString.Length; windowEndIndex++)
            {
                if (binaryString[windowEndIndex] == '1')
                {
                    currentOneCount++;
                }

                while (currentOneCount >= requiredOneCount)
                {
                    if (currentOneCount == requiredOneCount)
                    {
                        int currentWindowLength = windowEndIndex - windowStartIndex + 1;

                        string currentBeautifulSubstring = binaryString.Substring(windowStartIndex, currentWindowLength);

                        if (currentWindowLength < shortestBeautifulLength || (currentWindowLength == shortestBeautifulLength &&
                             string.CompareOrdinal( currentBeautifulSubstring, lexicographicallySmallestResult) < 0))
                        {
                            shortestBeautifulLength = currentWindowLength;
                            lexicographicallySmallestResult = currentBeautifulSubstring;
                        }
                    }

                    if (binaryString[windowStartIndex] == '1')
                    {
                        currentOneCount--;
                    }

                    windowStartIndex++;
                }
            }

            return lexicographicallySmallestResult;
        }
    }
}