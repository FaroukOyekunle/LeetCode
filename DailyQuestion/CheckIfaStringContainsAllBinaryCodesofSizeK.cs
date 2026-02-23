namespace DailyQuestion
{
    public class CheckIfaStringContainsAllBinaryCodesofSizeK
    {
        public bool CheckIfStringContainsAllBinaryCodes(string inputString, int codeLength)
        {
            int stringLength = inputString.Length;

            if (stringLength < codeLength)
            {
                return false;
            }

            int totalBinaryCodes = 1 << codeLength;
            bool[] seenBinaryCodes = new bool[totalBinaryCodes];
            int uniqueCodeCount = 0;

            int currentBinaryMask = 0;
            int allOnesMask = totalBinaryCodes - 1;

            for (int currentIndex = 0; currentIndex < stringLength; currentIndex++)
            {
                currentBinaryMask = ((currentBinaryMask << 1) & allOnesMask) | (inputString[currentIndex] - '0');

                if (currentIndex >= codeLength - 1)
                {
                    if (!seenBinaryCodes[currentBinaryMask])
                    {
                        seenBinaryCodes[currentBinaryMask] = true;
                        uniqueCodeCount++;

                        if (uniqueCodeCount == totalBinaryCodes)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}