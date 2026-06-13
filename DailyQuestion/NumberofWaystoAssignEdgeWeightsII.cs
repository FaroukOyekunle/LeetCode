namespace DailyQuestion
{
    public class NumberofWaystoAssignEdgeWeightsII
    {
        private const int MODULO = 1_000_000_007;

        public int[] AssignEdgeWeights(int[][] treeEdges, int[][] pathQueries)
        {
            int totalNodeCount = treeEdges.Length + 1;

            List<int>[] adjacentNodesByVertex = new List<int>[totalNodeCount + 1];

            for (int nodeValue = 1; nodeValue <= totalNodeCount; nodeValue++)
            {
                adjacentNodesByVertex[nodeValue] = new List<int>();
            }

            foreach (int[] currentEdge in treeEdges)
            {
                int sourceNode = currentEdge[0];
                int destinationNode = currentEdge[1];

                adjacentNodesByVertex[sourceNode].Add(destinationNode);

                adjacentNodesByVertex[destinationNode].Add(sourceNode);
            }

            int maximumBinaryLiftingPower = 0;

            while ((1 << maximumBinaryLiftingPower) <= totalNodeCount)
            {
                maximumBinaryLiftingPower++;
            }

            int[,] kthAncestorTable = new int[totalNodeCount + 1, maximumBinaryLiftingPower];

            int[] nodeDepths = new int[totalNodeCount + 1];

            Queue<int> breadthFirstTraversalQueue = new Queue<int>();

            breadthFirstTraversalQueue.Enqueue(1);

            bool[] hasNodeBeenVisited = new bool[totalNodeCount + 1];

            hasNodeBeenVisited[1] = true;

            while (breadthFirstTraversalQueue.Count > 0)
            {
                int currentNode = breadthFirstTraversalQueue.Dequeue();

                foreach (int adjacentNode in adjacentNodesByVertex[currentNode])
                {
                    if (hasNodeBeenVisited[adjacentNode])
                    {
                        continue;
                    }

                    hasNodeBeenVisited[adjacentNode] = true;

                    nodeDepths[adjacentNode] = nodeDepths[currentNode] + 1;

                    kthAncestorTable[adjacentNode, 0] = currentNode;

                    breadthFirstTraversalQueue.Enqueue(adjacentNode);
                }
            }

            for (int ancestorPower = 1; ancestorPower < maximumBinaryLiftingPower; ancestorPower++)
            {
                for (int currentNode = 1; currentNode <= totalNodeCount; currentNode++)
                {
                    int immediateAncestor = kthAncestorTable[currentNode, ancestorPower - 1];

                    if (immediateAncestor != 0)
                    {
                        kthAncestorTable[currentNode, ancestorPower] = kthAncestorTable[immediateAncestor, ancestorPower - 1];
                    }
                }
            }

            long[] powersOfTwoModulo = new long[totalNodeCount];

            powersOfTwoModulo[0] = 1;

            for (int exponentValue = 1; exponentValue < totalNodeCount; exponentValue++)
            {
                powersOfTwoModulo[exponentValue] = (powersOfTwoModulo[exponentValue - 1] * 2) % MODULO;
            }

            int[] queryResults = new int[pathQueries.Length];

            for (int queryIndex = 0;  queryIndex < pathQueries.Length; queryIndex++)
            {
                int pathStartNode = pathQueries[queryIndex][0];

                int pathEndNode = pathQueries[queryIndex][1];

                int lowestCommonAncestorNode = FindLowestCommonAncestor(pathStartNode, pathEndNode, nodeDepths, kthAncestorTable, maximumBinaryLiftingPower);

                int numberOfEdgesOnPath = nodeDepths[pathStartNode] + nodeDepths[pathEndNode] - (2 * nodeDepths[lowestCommonAncestorNode]);

                if (numberOfEdgesOnPath == 0)
                {
                    queryResults[queryIndex] = 0;
                }
                else
                {
                    queryResults[queryIndex] = (int)powersOfTwoModulo[numberOfEdgesOnPath - 1];
                }
            }

            return queryResults;
        }

        private int FindLowestCommonAncestor(int deeperNode, int shallowerNode, int[] nodeDepths, int[,] kthAncestorTable, int maximumBinaryLiftingPower)
        {
            if (nodeDepths[deeperNode] < nodeDepths[shallowerNode])
            {
                (deeperNode, shallowerNode) = (shallowerNode, deeperNode);
            }

            int depthDifference = nodeDepths[deeperNode] - nodeDepths[shallowerNode];

            for (int ancestorPower = 0; ancestorPower < maximumBinaryLiftingPower; ancestorPower++)
            {
                bool shouldLiftNode = ((depthDifference >> ancestorPower) & 1)== 1;

                if (shouldLiftNode)
                {
                    deeperNode = kthAncestorTable[deeperNode, ancestorPower];
                }
            }

            if (deeperNode == shallowerNode)
            {
                return deeperNode;
            }

            for (int ancestorPower = maximumBinaryLiftingPower - 1; ancestorPower >= 0; ancestorPower--)
            {
                if (kthAncestorTable[deeperNode, ancestorPower] != kthAncestorTable[shallowerNode, ancestorPower])
                {
                    deeperNode = kthAncestorTable[deeperNode, ancestorPower];

                    shallowerNode = kthAncestorTable[shallowerNode, ancestorPower];
                }
            }

            return kthAncestorTable[deeperNode, 0];
        }
    }
}