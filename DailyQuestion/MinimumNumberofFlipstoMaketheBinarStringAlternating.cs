namespace DailyQuestion
{
    public class MinimumNumberofFlipstoMaketheBinarStringAlternating
    {
        public int MinFlips(string binaryString)
        {
            int originalLength = binaryString.Length;
            string extendedBinaryString = binaryString + binaryString;

            int mismatchCountPattern1 = 0; 
            int mismatchCountPattern2 = 0; 

            int minimumFlips = int.MaxValue;

            for (int currentIndex = 0; currentIndex < extendedBinaryString.Length; currentIndex++)
            {
                char expectedCharPattern1 = (currentIndex % 2 == 0) ? '0' : '1';
                char expectedCharPattern2 = (currentIndex % 2 == 0) ? '1' : '0';

                if (extendedBinaryString[currentIndex] != expectedCharPattern1)
                {
                    mismatchCountPattern1++;
                }

                if (extendedBinaryString[currentIndex] != expectedCharPattern2)
                {
                    mismatchCountPattern2++;
                }

                if (currentIndex >= originalLength)
                {
                    char previousExpectedCharPattern1 = ((currentIndex - originalLength) % 2 == 0) ? '0' : '1';
                    char previousExpectedCharPattern2 = ((currentIndex - originalLength) % 2 == 0) ? '1' : '0';

                    if (extendedBinaryString[currentIndex - originalLength] != previousExpectedCharPattern1)
                    {
                        mismatchCountPattern1--;
                    }

                    if (extendedBinaryString[currentIndex - originalLength] != previousExpectedCharPattern2)
                    {
                        mismatchCountPattern2--;
                    }
                }

                if (currentIndex >= originalLength - 1)
                {
                    minimumFlips = Math.Min(minimumFlips, Math.Min(mismatchCountPattern1, mismatchCountPattern2));
                }
            }

            return minimumFlips;
        }
    }
}