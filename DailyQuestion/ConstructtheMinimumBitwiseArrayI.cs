namespace DailyQuestion
{
    public class ConstructtheMinimumBitwiseArrayI
    {
        public int[] ConstructMinimumBitwiseArray(IList<int> inputNumbers)
        {
            int[] resultArray = new int[inputNumbers.Count];

            for (int index = 0; index < inputNumbers.Count; index++)
            {
                int targetNumber = inputNumbers[index];
                int optimalValue = -1;

                for (int candidate = 0; candidate < targetNumber; candidate++)
                {
                    if ((candidate | (candidate + 1)) == targetNumber)
                    {
                        optimalValue = candidate;
                        break; 
                    }
                }

                resultArray[index] = optimalValue;
            }

            return resultArray;
        }
    }
}