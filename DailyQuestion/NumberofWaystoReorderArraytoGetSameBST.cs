using System.Collections.Generic;

namespace DailyQuestion
{
    public class NumberofWaystoReorderArraytoGetSameBST
    {
        private const long ModuloDivisor = 1_000_000_007;

        private long[,] binomialCoefficients;

        public int NumOfWays(int[] insertionSequence)
        {
            int totalNumberOfElements = insertionSequence.Length;

            binomialCoefficients =
                new long[totalNumberOfElements + 1, totalNumberOfElements + 1];

            for (int totalElementCount = 0; totalElementCount <= totalNumberOfElements; totalElementCount++)
            {
                binomialCoefficients[totalElementCount, 0] = 1;
                binomialCoefficients[totalElementCount, totalElementCount] = 1;

                for (int selectedElementCount = 1; selectedElementCount < totalElementCount; selectedElementCount++)
                {
                    binomialCoefficients[totalElementCount, selectedElementCount] = (binomialCoefficients[totalElementCount - 1, selectedElementCount - 1] + binomialCoefficients[totalElementCount - 1, selectedElementCount]) % ModuloDivisor;
                }
            }

            return (int)((CountEquivalentInsertionSequences(insertionSequence) - 1 + ModuloDivisor) % ModuloDivisor);
        }

        private long CountEquivalentInsertionSequences(int[] insertionSequence)
        {
            int currentSubtreeSize = insertionSequence.Length;

            if (currentSubtreeSize <= 2)
            {
                return 1;
            }

            int rootNodeValue = insertionSequence[0];

            List<int> leftSubtreeInsertionValues = new();
            List<int> rightSubtreeInsertionValues = new();

            for (int insertionValueIndex = 1; insertionValueIndex < currentSubtreeSize; insertionValueIndex++)
            {
                int currentNodeValue = insertionSequence[insertionValueIndex];

                if (currentNodeValue < rootNodeValue)
                {
                    leftSubtreeInsertionValues.Add(currentNodeValue);
                }
                else
                {
                    rightSubtreeInsertionValues.Add(currentNodeValue);
                }
            }

            int leftSubtreeNodeCount = leftSubtreeInsertionValues.Count;
            int rightSubtreeNodeCount = rightSubtreeInsertionValues.Count;

            long leftSubtreeReorderingCount = CountEquivalentInsertionSequences(leftSubtreeInsertionValues.ToArray());

            long rightSubtreeReorderingCount =  CountEquivalentInsertionSequences(rightSubtreeInsertionValues.ToArray());

            long subtreeInterleavingCount = binomialCoefficients[leftSubtreeNodeCount + rightSubtreeNodeCount, leftSubtreeNodeCount];

            return (((subtreeInterleavingCount * leftSubtreeReorderingCount) % ModuloDivisor) * rightSubtreeReorderingCount) % ModuloDivisor;
        }
    }
}