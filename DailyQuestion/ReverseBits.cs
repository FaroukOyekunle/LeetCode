namespace DailyQuestion
{
    public class ReverseBits
    {
        public int ReverseBitsInInteger(int inputNumber)
        {
            int reversedBitsResult = 0;

            for (int bitPosition = 0; bitPosition < 32; bitPosition++)
            {
                reversedBitsResult <<= 1;

                reversedBitsResult |= (inputNumber & 1);

                inputNumber >>= 1;
            }

            return reversedBitsResult;
        }
    }
}