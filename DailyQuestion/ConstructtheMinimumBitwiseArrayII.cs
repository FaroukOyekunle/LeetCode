namespace DailyQuestion
{
    public class ConstructtheMinimumBitwiseArrayII
    {
        public int[] ConstructMinimumBitwiseArray(IList<int> inputNumbers)
        {
            int inputCount = inputNumbers.Count;
            int[] resultArray = new int[inputCount];

            for(int index = 0; index < inputCount; index++)
            {
                int currentNumber = inputNumbers[index];

                if(currentNumber == 2)
                {
                    resultArray[index] = -1;
                    continue;
                }

                int trailingOnesCount = 0;
                int tempNumber = currentNumber;

                while((tempNumber & 1) == 1)
                {
                    trailingOnesCount++;
                    tempNumber >>= 1;
                }

                resultArray[index] = currentNumber ^ (1 << (trailingOnesCount - 1));
            }

            return resultArray;
        }
    }
}