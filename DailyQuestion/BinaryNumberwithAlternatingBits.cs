namespace DailyQuestion
{
    public class BinaryNumberwithAlternatingBits
    {
        public bool CheckIfBinaryNumberHasAlternatingBits(int inputNumber)
        {
            int previousBit = inputNumber & 1;
            inputNumber >>= 1;

            while (inputNumber > 0)
            {
                int currentBit = inputNumber & 1;

                if (currentBit == previousBit)
                {
                    return false;
                }

                previousBit = currentBit;
                inputNumber >>= 1;
            }

            return true;
        }
    }
}