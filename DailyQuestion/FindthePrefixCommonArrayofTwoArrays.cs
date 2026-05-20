namespace DailyQuestion
{
    public class FindthePrefixCommonArrayofTwoArrays
    {
        public int[] FindThePrefixCommonArray(int[] firstPermutationArray, int[] secondPermutationArray)
        {
            int totalElements = firstPermutationArray.Length;

            int[] prefixCommonElementCounts = new int[totalElements];

            bool[] hasAppearedInFirstArray = new bool[totalElements + 1];

            bool[] hasAppearedInSecondArray =  new bool[totalElements + 1];

            int totalCommonElementsSoFar = 0;

            for (int currentIndex = 0; currentIndex < totalElements; currentIndex++)
            {
                int currentValueFromFirstArray = firstPermutationArray[currentIndex];

                int currentValueFromSecondArray = secondPermutationArray[currentIndex];

                hasAppearedInFirstArray[currentValueFromFirstArray] = true;

                hasAppearedInSecondArray[currentValueFromSecondArray] = true;

                bool currentFirstArrayValueAlreadyExistsInSecondArray =  hasAppearedInSecondArray[currentValueFromFirstArray];

                if (currentFirstArrayValueAlreadyExistsInSecondArray)
                {
                    totalCommonElementsSoFar++;
                }

                bool valuesAtCurrentIndexAreDifferent = currentValueFromFirstArray != currentValueFromSecondArray;

                bool currentSecondArrayValueAlreadyExistsInFirstArray = hasAppearedInFirstArray[currentValueFromSecondArray];

                if (valuesAtCurrentIndexAreDifferent && currentSecondArrayValueAlreadyExistsInFirstArray)
                {
                    totalCommonElementsSoFar++;
                }

                prefixCommonElementCounts[currentIndex] = totalCommonElementsSoFar;
            }

            return prefixCommonElementCounts;
        }
    }
}