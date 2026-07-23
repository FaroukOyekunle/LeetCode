namespace DailyQuestion
{
    public class MaximizeActiveSectionwithTradeII
    {
        public IList<int> MaxActiveSectionsAfterTrade(string binaryString, int[][] queries)
        {
            int stringLength = binaryString.Length;

            int[] zeroBlockIndexByPosition = new int[stringLength];

            List<int[]> zeroBlocks = new List<int[]>();

            int initialActiveSectionCount = 0;

            for (int currentPosition = 0; currentPosition < stringLength; currentPosition++)
            {
                if (binaryString[currentPosition] == '0')
                {
                    if (currentPosition > 0 && binaryString[currentPosition - 1] == '0')
                    {
                        zeroBlocks[zeroBlocks.Count - 1][1]++;
                    }
                    else
                    {
                        zeroBlocks.Add(new int[] { currentPosition, 1 });
                    }
                }
                else
                {
                    initialActiveSectionCount++;
                }

                zeroBlockIndexByPosition[currentPosition] = zeroBlocks.Count - 1;
            }

            if (zeroBlocks.Count == 0)
            {
                return Enumerable.Repeat(initialActiveSectionCount, queries.Length).ToList();
            }

            int[] adjacentZeroBlockCombinedLengths = new int[Math.Max(0, zeroBlocks.Count - 1)];

            for (int zeroBlockIndex = 0; zeroBlockIndex < zeroBlocks.Count - 1; zeroBlockIndex++)
            {
                adjacentZeroBlockCombinedLengths[zeroBlockIndex] = zeroBlocks[zeroBlockIndex][1] + zeroBlocks[zeroBlockIndex + 1][1];
            }

            SparseTable maximumAdjacentZeroBlockLookup = new SparseTable(adjacentZeroBlockCombinedLengths);

            int[] maximumActiveSectionsPerQuery = Enumerable.Repeat(initialActiveSectionCount, queries.Length).ToArray();

            for (int queryIndex = 0; queryIndex < queries.Length; queryIndex++)
            {
                int queryStartIndex = queries[queryIndex][0];
                int queryEndIndex = queries[queryIndex][1];

                int firstCompleteZeroBlockIndex = zeroBlockIndexByPosition[queryStartIndex] + 1;

                int lastCompleteZeroBlockIndex = zeroBlockIndexByPosition[queryEndIndex] - (binaryString[queryEndIndex] == '0' ? 1 : 0);

                int leftPartialZeroBlockLength = -1;

                if (zeroBlockIndexByPosition[queryStartIndex] != -1)
                {
                    leftPartialZeroBlockLength = zeroBlocks[zeroBlockIndexByPosition[queryStartIndex]][1] - (queryStartIndex - zeroBlocks[zeroBlockIndexByPosition[queryStartIndex]][0]);
                }

                int rightPartialZeroBlockLength = -1;

                if (zeroBlockIndexByPosition[queryEndIndex] != -1)
                {
                    rightPartialZeroBlockLength = queryEndIndex - zeroBlocks[zeroBlockIndexByPosition[queryEndIndex]][0] + 1;
                }

                if (firstCompleteZeroBlockIndex <= lastCompleteZeroBlockIndex - 1)
                {
                    maximumActiveSectionsPerQuery[queryIndex] = Math.Max(maximumActiveSectionsPerQuery[queryIndex],
                            initialActiveSectionCount + maximumAdjacentZeroBlockLookup.Query(firstCompleteZeroBlockIndex, lastCompleteZeroBlockIndex - 1));
                }

                if (binaryString[queryStartIndex] == '0' && binaryString[queryEndIndex] == '0' && zeroBlockIndexByPosition[queryStartIndex] + 1 == zeroBlockIndexByPosition[queryEndIndex])
                {
                    maximumActiveSectionsPerQuery[queryIndex] =
                        Math.Max(maximumActiveSectionsPerQuery[queryIndex], initialActiveSectionCount + leftPartialZeroBlockLength + rightPartialZeroBlockLength);
                }

                if (binaryString[queryStartIndex] == '0' && zeroBlockIndexByPosition[queryStartIndex] + 1 <= lastCompleteZeroBlockIndex)
                {
                    maximumActiveSectionsPerQuery[queryIndex] = Math.Max(maximumActiveSectionsPerQuery[queryIndex], initialActiveSectionCount +
                            leftPartialZeroBlockLength + zeroBlocks[zeroBlockIndexByPosition[queryStartIndex] + 1][1]);
                }

                if (binaryString[queryEndIndex] == '0' && firstCompleteZeroBlockIndex <= zeroBlockIndexByPosition[queryEndIndex] - 1)
                {
                    maximumActiveSectionsPerQuery[queryIndex] =  Math.Max(maximumActiveSectionsPerQuery[queryIndex], initialActiveSectionCount + rightPartialZeroBlockLength + 
                            zeroBlocks[zeroBlockIndexByPosition[queryEndIndex] - 1][1]);
                }
            }

            return maximumActiveSectionsPerQuery;
        }

        private class SparseTable
        {
            private readonly int[][] maximumValuesTable;
            private readonly int[] logarithmLookup;
            private readonly int totalLevels;

            public SparseTable(int[] values)
            {
                int valueCount = values.Length;

                if (valueCount == 0)
                {
                    maximumValuesTable = new int[0][];
                    logarithmLookup = new int[1];
                    totalLevels = 0;
                    return;
                }

                totalLevels = (int)Math.Log(valueCount, 2) + 1;

                logarithmLookup = new int[valueCount + 1];

                for (int length = 2; length <= valueCount; length++)
                {
                    logarithmLookup[length] = logarithmLookup[length / 2] + 1;
                }

                maximumValuesTable = new int[totalLevels][];

                maximumValuesTable[0] = new int[valueCount];
                Array.Copy(values, maximumValuesTable[0], valueCount);

                for (int level = 1; level < totalLevels; level++)
                {
                    int currentIntervalLength = 1 << level;
                    int halfIntervalLength = 1 << (level - 1);

                    maximumValuesTable[level] = new int[valueCount];

                    for (int intervalStartIndex = 0; intervalStartIndex + currentIntervalLength <= valueCount; intervalStartIndex++)
                    {
                        maximumValuesTable[level][intervalStartIndex] = Math.Max(maximumValuesTable[level - 1][intervalStartIndex], maximumValuesTable[level - 1][intervalStartIndex + halfIntervalLength]);
                    }
                }
            }

            public int Query(int queryLeftIndex, int queryRightIndex)
            {
                int intervalLevel = ogarithmLookup[queryRightIndex - queryLeftIndex + 1];

                return Math.Max(maximumValuesTable[intervalLevel][queryLeftIndex], maximumValuesTable[intervalLevel][queryRightIndex - (1 << intervalLevel) + 1]);
            }
        }
    }
}