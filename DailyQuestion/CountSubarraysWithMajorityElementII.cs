namespace DailyQuestion
{
    public class CountSubarraysWithMajorityElementII
    {
        public long CountMajoritySubarrays(int[] numbers, int targetValue)
        {
            int totalElementCount = numbers.Length;

            int prefixSumOffset = totalElementCount + 2;

            FenwickTree prefixFrequencyTree = new FenwickTree((2 * totalElementCount) + 5);

            long totalMajoritySubarrayCount = 0;

            int currentPrefixBalance = 0;

            prefixFrequencyTree.Update(prefixSumOffset, 1);

            foreach (int currentNumber in numbers)
            {
                int currentContribution = currentNumber == targetValue ? 1 : -1;

                currentPrefixBalance += currentContribution;

                int shiftedPrefixIndex = currentPrefixBalance + prefixSumOffset;

                totalMajoritySubarrayCount += prefixFrequencyTree.Query(shiftedPrefixIndex - 1);

                prefixFrequencyTree.Update(shiftedPrefixIndex, 1);
            }

            return totalMajoritySubarrayCount;
        }

        private class FenwickTree
        {
            private readonly long[] prefixFrequencyStorage;

            public FenwickTree(int maximumIndexCount)
            {
                prefixFrequencyStorage = new long[maximumIndexCount + 1];
            }

            public void Update(int treeIndex, long frequencyIncrease)
            {
                while (treeIndex < prefixFrequencyStorage.Length)
                {
                    prefixFrequencyStorage[treeIndex] += frequencyIncrease;

                    treeIndex += treeIndex & (-treeIndex);
                }
            }

            public long Query(int treeIndex)
            {
                long accumulatedFrequency = 0;

                while (treeIndex > 0)
                {
                    accumulatedFrequency += prefixFrequencyStorage[treeIndex];

                    treeIndex -= treeIndex & (-treeIndex);
                }

                return accumulatedFrequency;
            }
        }
    }
}