namespace DailyQuestion
{
    public class SpecialBinaryString
    {
        public string GenerateLargestSpecialBinaryString(string binaryString)
        {
            if (binaryString.Length <= 2)
            {
                return binaryString;
            }

            List<string> specialBinarySubstrings = new List<string>();

            int balanceCounter = 0;
            int substringStartIndex = 0;

            for (int currentIndex = 0; currentIndex < binaryString.Length; currentIndex++)
            {
                if (binaryString[currentIndex] == '1')
                {
                    balanceCounter++;
                }
                else
                {
                    balanceCounter--;
                }

                if (balanceCounter == 0)
                {
                    string innerSubstring = binaryString.Substring(substringStartIndex + 1, currentIndex - substringStartIndex - 1);
                    string processedInnerSubstring = GenerateLargestSpecialBinaryString(innerSubstring);

                    specialBinarySubstrings.Add("1" + processedInnerSubstring + "0");

                    substringStartIndex = currentIndex + 1;
                }
            }

            specialBinarySubstrings.Sort((firstSubstring, secondSubstring) => string.Compare(secondSubstring, firstSubstring));

            return string.Concat(specialBinarySubstrings);
        }
    }
}