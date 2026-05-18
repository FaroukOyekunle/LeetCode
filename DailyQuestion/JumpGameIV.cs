namespace DailyQuestion
{
    public class JumpGameIV
    {
        public int MinJumps(int[] numbers)
        {
            int totalNumberOfElements = numbers.Length;

            if (totalNumberOfElements == 1)
            {
                return 0;
            }

            Dictionary<int, List<int>> valueToAllMatchingIndicesMap = new Dictionary<int, List<int>>();

            for (int currentArrayIndex = 0; currentArrayIndex < totalNumberOfElements; currentArrayIndex++)
            {
                int currentNumber = numbers[currentArrayIndex];

                if (!valueToAllMatchingIndicesMap.ContainsKey(currentNumber))
                {
                    valueToAllMatchingIndicesMap[currentNumber] = new List<int>();
                }

                valueToAllMatchingIndicesMap[currentNumber].Add(currentArrayIndex);
            }

            bool[] hasVisitedIndex = new bool[totalNumberOfElements];

            hasVisitedIndex[0] = true;

            Queue<int> breadthFirstSearchQueue = new Queue<int>();

            breadthFirstSearchQueue.Enqueue(0);

            int minimumJumpCount = 0;

            while (breadthFirstSearchQueue.Count > 0)
            {
                int totalIndicesInCurrentLevel = breadthFirstSearchQueue.Count;

                for (int currentLevelIndex = 0; currentLevelIndex < totalIndicesInCurrentLevel; currentLevelIndex++)
                {
                    int currentIndex = breadthFirstSearchQueue.Dequeue();

                    if (currentIndex == totalNumberOfElements - 1)
                    {
                        return minimumJumpCount;
                    }

                    List<int> reachableIndices = new List<int>();

                    int currentValue = numbers[currentIndex];

                    if (valueToAllMatchingIndicesMap.ContainsKey(currentValue))
                    {
                        reachableIndices.AddRange(valueToAllMatchingIndicesMap[currentValue]);
                    }

                    int leftAdjacentIndex = currentIndex - 1;

                    int rightAdjacentIndex = currentIndex + 1;

                    reachableIndices.Add(leftAdjacentIndex);

                    reachableIndices.Add(rightAdjacentIndex);

                    foreach (int nextReachableIndex in reachableIndices)
                    {
                        bool isIndexWithinArrayBounds = nextReachableIndex >= 0 && nextReachableIndex < totalNumberOfElements;

                        if (isIndexWithinArrayBounds && !hasVisitedIndex[nextReachableIndex])
                        {
                            hasVisitedIndex[nextReachableIndex] = true;

                            breadthFirstSearchQueue.Enqueue(nextReachableIndex);
                        }
                    }

                    valueToAllMatchingIndicesMap[currentValue].Clear();
                }

                minimumJumpCount++;
            }

            return -1;
        }
    }
}