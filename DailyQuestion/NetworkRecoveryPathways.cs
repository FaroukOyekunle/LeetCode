namespace DailyQuestion
{
    public class NetworkRecoveryPathways
    {
        public int FindMaxPathScore(int[][] edges, bool[] isNodeOnline, long maximumAllowedPathCost)
        {
            int totalNodeCount = isNodeOnline.Length;

            if (totalNodeCount == 1)
            {
                return 0;
            }

            int highestEdgeCost = 0;

            foreach (int[] edge in edges)
            {
                highestEdgeCost = Math.Max(highestEdgeCost, edge[2]);
            }

            int minimumCandidateScore = 0;
            int maximumCandidateScore = highestEdgeCost;
            int bestValidPathScore = -1;

            while (minimumCandidateScore <= maximumCandidateScore)
            {
                int candidateMinimumEdgeCost = minimumCandidateScore + (maximumCandidateScore - minimumCandidateScore) / 2;

                if (CanReachDestinationWithinCostLimit(edges, isNodeOnline, maximumAllowedPathCost, candidateMinimumEdgeCost))
                {
                    bestValidPathScore = candidateMinimumEdgeCost;
                    minimumCandidateScore = candidateMinimumEdgeCost + 1;
                }
                else
                {
                    maximumCandidateScore = candidateMinimumEdgeCost - 1;
                }
            }

            return bestValidPathScore;
        }

        private bool CanReachDestinationWithinCostLimit(int[][] edges, bool[] isNodeOnline, long maximumAllowedPathCost, int minimumAllowedEdgeCost)
        {
            int totalNodeCount = isNodeOnline.Length;

            List<(int DestinationNode, int EdgeCost)>[] adjacencyList = new List<(int, int)>[totalNodeCount];

            for (int nodeIndex = 0; nodeIndex < totalNodeCount; nodeIndex++)
            {
                adjacencyList[nodeIndex] = new List<(int, int)>();
            }

            int[] incomingEdgeCount = new int[totalNodeCount];

            foreach (int[] edge in edges)
            {
                int sourceNode = edge[0];
                int destinationNode = edge[1];
                int edgeCost = edge[2];

                if (edgeCost < minimumAllowedEdgeCost)
                {
                    continue;
                }

                bool sourceNodeIsOffline = sourceNode != 0 && sourceNode != totalNodeCount - 1 && !isNodeOnline[sourceNode];

                if (sourceNodeIsOffline)
                {
                    continue;
                }

                bool destinationNodeIsOffline = destinationNode != 0 && destinationNode != totalNodeCount - 1 && !isNodeOnline[destinationNode];

                if (destinationNodeIsOffline)
                {
                    continue;
                }

                adjacencyList[sourceNode].Add((destinationNode, edgeCost));

                incomingEdgeCount[destinationNode]++;
            }

            Queue<int> topologicalProcessingQueue = new Queue<int>();

            for (int nodeIndex = 0; nodeIndex < totalNodeCount; nodeIndex++)
            {
                if (incomingEdgeCount[nodeIndex] == 0)
                {
                    topologicalProcessingQueue.Enqueue(nodeIndex);
                }
            }

            long[] minimumPathCostToNode = new long[totalNodeCount];

            for (int nodeIndex = 0; nodeIndex < totalNodeCount; nodeIndex++)
            {
                minimumPathCostToNode[nodeIndex] = long.MaxValue;
            }

            minimumPathCostToNode[0] = 0;

            while (topologicalProcessingQueue.Count > 0)
            {
                int currentNode = topologicalProcessingQueue.Dequeue();

                if (minimumPathCostToNode[currentNode] != long.MaxValue)
                {
                    foreach ((int destinationNode, int edgeCost) in adjacencyList[currentNode])
                    {
                        long candidatePathCost = minimumPathCostToNode[currentNode] + edgeCost;

                        if (candidatePathCost < minimumPathCostToNode[destinationNode])
                        {
                            minimumPathCostToNode[destinationNode] = candidatePathCost;
                        }
                    }
                }

                foreach ((int destinationNode, _) in adjacencyList[currentNode])
                {
                    incomingEdgeCount[destinationNode]--;

                    if (incomingEdgeCount[destinationNode] == 0)
                    {
                        topologicalProcessingQueue.Enqueue(destinationNode);
                    }
                }
            }

            return minimumPathCostToNode[totalNodeCount - 1] <= maximumAllowedPathCost;
        }
    }
}