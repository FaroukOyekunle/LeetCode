namespace DailyQuestion
{
    public class MinimizeHammingDistanceAfterSwapOperations
    {
        public int CalculateMinimumHammingDistance( int[] sourceArray, int[] targetArray, int[][] allowedIndexSwaps)
        {
            int totalLength = sourceArray.Length;

            var disjointSet = new DisjointSetUnion(totalLength);

            foreach (var swapPair in allowedIndexSwaps)
            {
                int firstIndex = swapPair[0];
                int secondIndex = swapPair[1];

                disjointSet.Union(firstIndex, secondIndex);
            }

            var rootToIndicesMap = new Dictionary<int, List<int>>();

            for (int currentIndex = 0; currentIndex < totalLength; currentIndex++)
            {
                int rootParent = disjointSet.Find(currentIndex);

                if (!rootToIndicesMap.ContainsKey(rootParent))
                {
                    rootToIndicesMap[rootParent] = new List<int>();
                }

                rootToIndicesMap[rootParent].Add(currentIndex);
            }

            int totalHammingDistance = 0;

            foreach (var indicesInComponent in rootToIndicesMap.Values)
            {
                var valueFrequencyInSource = new Dictionary<int, int>();

                foreach (int index in indicesInComponent)
                {
                    int sourceValue = sourceArray[index];

                    if (!valueFrequencyInSource.ContainsKey(sourceValue))
                    {
                        valueFrequencyInSource[sourceValue] = 0;
                    }

                    valueFrequencyInSource[sourceValue]++;
                }

                foreach (int index in indicesInComponent)
                {
                    int targetValue = targetArray[index];

                    if (valueFrequencyInSource.ContainsKey(targetValue) &&
                        valueFrequencyInSource[targetValue] > 0)
                    {
                        valueFrequencyInSource[targetValue]--;
                    }
                    else
                    {
                        totalHammingDistance++;
                    }
                }
            }

            return totalHammingDistance;
        }

        public class DisjointSetUnion
        {
            private int[] parentOfNode;
            private int[] rankOfTree;

            public DisjointSetUnion(int totalNodes)
            {
                parentOfNode = new int[totalNodes];
                rankOfTree = new int[totalNodes];

                for (int nodeIndex = 0; nodeIndex < totalNodes; nodeIndex++)
                {
                    parentOfNode[nodeIndex] = nodeIndex;
                }
            }

            public int Find(int node)
            {
                if (parentOfNode[node] != node)
                {
                    parentOfNode[node] = Find(parentOfNode[node]); 
                }

                return parentOfNode[node];
            }

            public void Union(int firstNode, int secondNode)
            {
                int rootOfFirstNode = Find(firstNode);
                int rootOfSecondNode = Find(secondNode);

                if (rootOfFirstNode == rootOfSecondNode)
                {
                    return;
                }

                if (rankOfTree[rootOfFirstNode] > rankOfTree[rootOfSecondNode])
                {
                    parentOfNode[rootOfSecondNode] = rootOfFirstNode;
                }
                else if (rankOfTree[rootOfFirstNode] < rankOfTree[rootOfSecondNode])
                {
                    parentOfNode[rootOfFirstNode] = rootOfSecondNode;
                }
                else
                {
                    parentOfNode[rootOfSecondNode] = rootOfFirstNode;
                    rankOfTree[rootOfFirstNode]++;
                }
            }
        }
    }
}