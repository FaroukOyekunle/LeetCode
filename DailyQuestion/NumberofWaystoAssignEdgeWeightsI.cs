namespace DailyQuestion
{
    public class NumberofWaystoAssignEdgeWeightsI
    {
        private const int MODULO = 1_000_000_007;

        public int AssignEdgeWeights(int[][] treeEdges)
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

            Queue<(int nodeValue, int treeDepth)> breadthFirstTraversalQueue = new();

            bool[] hasNodeBeenVisited = new bool[totalNodeCount + 1];

            breadthFirstTraversalQueue.Enqueue((nodeValue: 1, treeDepth: 0));

            hasNodeBeenVisited[1] = true;

            int deepestTreeLevel = 0;

            while (breadthFirstTraversalQueue.Count > 0)
            {
                var (currentNodeValue, currentNodeDepth) = breadthFirstTraversalQueue.Dequeue();

                deepestTreeLevel = Math.Max(deepestTreeLevel, currentNodeDepth);

                foreach (int connectedNode in adjacentNodesByVertex[currentNodeValue])
                {
                    if (hasNodeBeenVisited[connectedNode])
                    {
                        continue;
                    }

                    hasNodeBeenVisited[connectedNode] = true;

                    breadthFirstTraversalQueue.Enqueue((connectedNode, currentNodeDepth + 1));
                }
            }

            int exponentForWeightAssignment = deepestTreeLevel - 1;

            return (int)CalculateModularPower(2, exponentForWeightAssignment);
        }

        private long CalculateModularPower(long baseNumber, int exponentValue)
        {
            long modularExponentiationResult = 1;

            while (exponentValue > 0)
            {
                bool isCurrentBitSet = (exponentValue & 1) == 1;

                if (isCurrentBitSet)
                {
                    modularExponentiationResult = (modularExponentiationResult * baseNumber) % MODULO;
                }

                baseNumber = (baseNumber * baseNumber) % MODULO;

                exponentValue >>= 1;
            }

            return modularExponentiationResult;
        }
    }
}