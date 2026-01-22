namespace DailyQuestion
{
    public class MinimumPairRemovaltoSortArrayI
    {
        public int MinimumPairRemoval(int[] inputArray)
        {
            var numberList = new List<int>(inputArray);
            int removalOperations = 0;

            while (!IsNonDecreasingOrder(numberList))
            {
                int minimumSum = int.MaxValue;
                int minimumSumIndex = 0;

                for (int currentIndex = 0; currentIndex < numberList.Count - 1; currentIndex++)
                {
                    int adjacentSum = numberList[currentIndex] + numberList[currentIndex + 1];
                    if (adjacentSum < minimumSum)
                    {
                        minimumSum = adjacentSum;
                        minimumSumIndex = currentIndex;
                    }
                }

                numberList[minimumSumIndex] = numberList[minimumSumIndex] + numberList[minimumSumIndex + 1];
                numberList.RemoveAt(minimumSumIndex + 1);

                removalOperations++;
            }

            return removalOperations;
        }

        private bool IsNonDecreasingOrder(List<int> numberList)
        {
            for (int currentIndex = 1; currentIndex < numberList.Count; currentIndex++)
            {
                if (numberList[currentIndex] < numberList[currentIndex - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}