namespace DailyQuestion
{
    public class FindKthBitinNthBinaryString
    {
        public char FindKthBitInNthBinaryString(int binaryStringOrder, int targetIndex)
        {
            if (binaryStringOrder == 1)
            {
                return '0';
            }

            int middleIndex = 1 << (binaryStringOrder - 1); 

            if (targetIndex == middleIndex)
            {
                return '1';
            }

            if (targetIndex < middleIndex)
            {
                return FindKthBitInNthBinaryString(binaryStringOrder - 1, targetIndex);
            }

            int mirroredIndex = (1 << binaryStringOrder) - targetIndex;
            char mirroredBit = FindKthBitInNthBinaryString(binaryStringOrder - 1, mirroredIndex);

            return mirroredBit == '0' ? '1' : '0';
        }
    }
}