namespace DailyQuestion
{
    public class PrimeNumberofSetBitsinBinaryRepresentation
    {
        public int CountNumbersWithPrimeSetBits(int rangeStart, int rangeEnd)
        {
            int primeSetBitCount = 0;

            HashSet<int> primeNumbersSet = new HashSet<int> { 2, 3, 5, 7, 11, 13, 17, 19 };

            for (int currentNumber = rangeStart; currentNumber <= rangeEnd; currentNumber++)
            {
                int setBitCount = CalculateSetBits(currentNumber);

                if (primeNumbersSet.Contains(setBitCount))
                {
                    primeSetBitCount++;
                }
            }

            return primeSetBitCount;
        }

        private int CalculateSetBits(int inputNumber)
        {
            int totalSetBits = 0;

            while (inputNumber > 0)
            {
                totalSetBits += inputNumber & 1;   
                inputNumber >>= 1;         
            }

            return totalSetBits;
        }
    }
}