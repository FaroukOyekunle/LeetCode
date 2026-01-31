namespace DailyQuestion
{
    public class MinimumPairRemovaltoSortArrayII
    {
        public int CalculateMinimumPairRemoval(int[] inputArray)
        {
            int arrayLength = inputArray.Length;
            if (arrayLength <= 1)
            {
                return 0;
            }

            long[] elementValues = new long[arrayLength];
            for (int index = 0; index < arrayLength; index++)
            {
                elementValues[index] = inputArray[index];
            }

            int[] nextIndices = new int[arrayLength];
            int[] previousIndices = new int[arrayLength];
            bool[] isRemoved = new bool[arrayLength];

            for (int index = 0; index < arrayLength; index++)
            {
                nextIndices[index] = (index + 1 < arrayLength) ? index + 1 : -1;
                previousIndices[index] = index - 1;
                
                isRemoved[index] = false;
            }

            var priorityQueue = new PriorityQueue<(int leftIndex, long pairSum), (long pairSum, int leftIndex)>();

            for (int index = 0; index < arrayLength - 1; index++)
            {
                priorityQueue.Enqueue((index, elementValues[index] + elementValues[index + 1]),
                                      (elementValues[index] + elementValues[index + 1], index));
            }

            int decreasingPairCount = 0;
            for (int index = 0; index < arrayLength - 1; index++)
            {
                if (elementValues[index] > elementValues[index + 1])
                {
                    decreasingPairCount++;
                }
            }

            int operationCount = 0;

            while (decreasingPairCount > 0)
            {
                int leftIndex;
                long pairSum;

                while (true)
                {
                    var currentItem = priorityQueue.Dequeue();

                    leftIndex = currentItem.leftIndex;
                    pairSum = currentItem.pairSum;

                    if (isRemoved[leftIndex])
                    {
                        continue;
                    }

                    int rightIndex = nextIndices[leftIndex];
                    if (rightIndex == -1 || isRemoved[rightIndex])
                    {
                        continue;
                    }

                    if (elementValues[leftIndex] + elementValues[rightIndex] != pairSum)
                    {
                        continue;
                    }

                    break;
                }

                int rightIndex = nextIndices[leftIndex];
                int leftNeighborIndex = previousIndices[leftIndex];
                int rightNeighborIndex = nextIndices[rightIndex];

                if (leftNeighborIndex != -1 && elementValues[leftNeighborIndex] > elementValues[leftIndex])
                {
                    decreasingPairCount--;
                }

                if (elementValues[leftIndex] > elementValues[rightIndex])
                {
                    decreasingPairCount--;
                }

                if (rightNeighborIndex != -1 && elementValues[rightIndex] > elementValues[rightNeighborIndex])
                {
                    decreasingPairCount--;
                }

                elementValues[leftIndex] += elementValues[rightIndex];
                isRemoved[rightIndex] = true;

                nextIndices[leftIndex] = rightNeighborIndex;
                if (rightNeighborIndex != -1)
                {
                    previousIndices[rightNeighborIndex] = leftIndex;
                }

                if (leftNeighborIndex != -1 && elementValues[leftNeighborIndex] > elementValues[leftIndex])
                {
                    decreasingPairCount++;
                }
                if (rightNeighborIndex != -1 && elementValues[leftIndex] > elementValues[rightNeighborIndex])
                {
                    decreasingPairCount++;
                }

                if (leftNeighborIndex != -1)
                {
                    priorityQueue.Enqueue((leftNeighborIndex, elementValues[leftNeighborIndex] + elementValues[leftIndex]),
                                          (elementValues[leftNeighborIndex] + elementValues[leftIndex], leftNeighborIndex));
                }

                if (rightNeighborIndex != -1)
                {
                    priorityQueue.Enqueue((leftIndex, elementValues[leftIndex] + elementValues[rightNeighborIndex]),
                                          (elementValues[leftIndex] + elementValues[rightNeighborIndex], leftIndex));
                }

                operationCount++;
            }

            return operationCount;
        }
    }
}