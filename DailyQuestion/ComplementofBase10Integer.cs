namespace DailyQuestion
{
    public class ComplementofBase10Integer
    {
        public int CalculateBitwiseComplement(int inputNumber)
        {
            if (inputNumber == 0)
            {
                return 1;
            }

            int bitMaskWithAllOnes = 0;

            int remainingBitsOfNumber = inputNumber;

            while (remainingBitsOfNumber > 0)
            {
                bitMaskWithAllOnes = (bitMaskWithAllOnes << 1) | 1;

                remainingBitsOfNumber >>= 1;
            }

            return inputNumber ^ bitMaskWithAllOnes;
        }
    }
}