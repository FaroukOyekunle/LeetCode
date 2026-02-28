namespace DailyQuestion
{
    public class ConcatenationofConsecutiveBinaryNumbers
    {
        public int CalculateConcatenatedBinaryRepresentation(int upperLimit)
        {
            const int MODULO = 1_000_000_007;
            long concatenatedResult = 0;
            int currentBitLength = 0;

            for (int currentNumber = 1; currentNumber <= upperLimit; currentNumber++)
            {
                if ((currentNumber & (currentNumber - 1)) == 0)
                {
                    currentBitLength++;
                }

                concatenatedResult = ((concatenatedResult << currentBitLength) | currentNumber) % MODULO;
            }

            return (int)concatenatedResult;
        }
    }
}