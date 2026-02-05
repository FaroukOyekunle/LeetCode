namespace DailyQuestion
{
    public class TransformedArray
    {
        public int[] ConstructTransformedArray(int[] inputArray)
        {
            int arrayLength = inputArray.Length;
            int[] transformedArray = new int[arrayLength];

            for (int currentIndex = 0; currentIndex < arrayLength; currentIndex++)
            {
                if (inputArray[currentIndex] == 0)
                {
                    transformedArray[currentIndex] = 0;
                    continue;
                }

                int targetIndex = (currentIndex + inputArray[currentIndex]) % arrayLength;

                if (targetIndex < 0)
                {
                    targetIndex += arrayLength;
                }

                transformedArray[currentIndex] = inputArray[targetIndex];
            }

            return transformedArray;
        }
    }
}