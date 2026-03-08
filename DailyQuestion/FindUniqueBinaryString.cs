namespace DailyQuestion
{
    public class FindUniqueBinaryString
    {
        public string FindDifferentBinaryString(string[] binaryStrings)
        {
            int binaryStringLength = binaryStrings.Length;
            char[] uniqueBinaryString = new char[binaryStringLength];

            for (int index = 0; index < binaryStringLength; index++)
            {
                uniqueBinaryString[index] = binaryStrings[index][index] == '0' ? '1' : '0';
            }

            return new string(uniqueBinaryString);
        }
    }
}