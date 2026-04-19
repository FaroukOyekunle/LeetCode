namespace DailyQuestion
{
    public class MaximumDistanceBetweenaPairofValues
    {
        public int FindMaximumValidPairDistance(int[] firstArray, int[] secondArray)
        {
            int pointerInFirstArray = 0;
            int pointerInSecondArray = 0;

            int maximumDistanceFound = 0;

            while (pointerInFirstArray < firstArray.Length && pointerInSecondArray < secondArray.Length)
            {
                int valueFromFirstArray = firstArray[pointerInFirstArray];
                int valueFromSecondArray = secondArray[pointerInSecondArray];

                if (valueFromFirstArray <= valueFromSecondArray)
                {
                    int currentDistance = pointerInSecondArray - pointerInFirstArray;

                    maximumDistanceFound = Math.Max( maximumDistanceFound, currentDistance);

                    pointerInSecondArray++;
                }
                else
                {
                    pointerInFirstArray++;
                }

                if (pointerInFirstArray > pointerInSecondArray)
                {
                    pointerInSecondArray = pointerInFirstArray;
                }
            }

            return maximumDistanceFound;
        }
    }
}