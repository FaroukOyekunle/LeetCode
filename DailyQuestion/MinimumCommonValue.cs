namespace DailyQuestion
{
    public class MinimumCommonValue
    {
        public int GetCommon(int[] firstSortedArray, int[] secondSortedArray)
        {
            int firstArrayPointer = 0;

            int secondArrayPointer = 0;

            while (firstArrayPointer < firstSortedArray.Length && secondArrayPointer < secondSortedArray.Length)
            {
                int currentFirstArrayValue = firstSortedArray[firstArrayPointer];

                int currentSecondArrayValue = secondSortedArray[secondArrayPointer];

                if (currentFirstArrayValue == currentSecondArrayValue)
                {
                    return currentFirstArrayValue;
                }

                bool firstArrayValueIsSmaller = currentFirstArrayValue < currentSecondArrayValue;

                if (firstArrayValueIsSmaller)
                {
                    firstArrayPointer++;
                }
                else
                {
                    secondArrayPointer++;
                }
            }

            return -1;
        }
    }
}