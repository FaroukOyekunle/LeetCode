namespace DailyQuestion
{
    public class SortIntegersbyTheNumberof1Bits
    {
        public int[] SortIntegersByNumberOfSetBits(int[] inputArray)
        {
            return inputArray
                .OrderBy(number => CalculateSetBitCount(number))  
                .ThenBy(number => number)                 
                .ToArray();
        }

        private int CalculateSetBitCount(int inputNumber)
        {
            int setBitCount = 0;

            while (inputNumber > 0)
            {
                setBitCount += inputNumber & 1; 
                inputNumber >>= 1;         
            }

            return setBitCount;
        }
    }
}