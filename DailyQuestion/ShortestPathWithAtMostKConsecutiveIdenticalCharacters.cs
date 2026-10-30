using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class ShortestPathWithAtMostKConsecutiveIdenticalCharacters
    {
        public int ShortestPath(int nodeCount, int[][] edges, string nodeLabels, int maximumConsecutiveMatchingLabels)
        {
            var adjacencyList = new List<(int DestinationNode, int EdgeWeight)>[nodeCount];

            for (int currentNode = 0; currentNode < nodeCount; currentNode++)
            {
                adjacencyList[currentNode] = new List<(int DestinationNode, int EdgeWeight)>();
            }

            foreach (int[] currentEdge in edges)
            {
                int sourceNode = currentEdge[0];
                int destinationNode = currentEdge[1];
                int edgeWeight = currentEdge[2];

                adjacencyList[sourceNode].Add((destinationNode, edgeWeight));
            }

            var minimumDistanceByNodeAndConsecutiveLabelCount = new long[nodeCount, maximumConsecutiveMatchingLabels + 1];

            for (int currentNode = 0; currentNode < nodeCount; currentNode++)
            {
                for (int consecutiveLabelCount = 0; consecutiveLabelCount <= maximumConsecutiveMatchingLabels; consecutiveLabelCount++)
                {
                    minimumDistanceByNodeAndConsecutiveLabelCount[currentNode, consecutiveLabelCount] = long.MaxValue;
                }
            }

            var priorityQueue = new PriorityQueue<(int CurrentNode, int ConsecutiveMatchingLabelCount), long>();

            minimumDistanceByNodeAndConsecutiveLabelCount[0, 1] = 0;

            priorityQueue.Enqueue((0, 1), 0);

            while (priorityQueue.Count > 0)
            {
                var currentSearchState = priorityQueue.Dequeue();

                int currentNode = currentSearchState.CurrentNode;
                int currentConsecutiveMatchingLabelCount = currentSearchState.ConsecutiveMatchingLabelCount;

                long currentPathDistance = minimumDistanceByNodeAndConsecutiveLabelCount[currentNode, currentConsecutiveMatchingLabelCount];

                if (currentNode == nodeCount - 1)
                {
                    return (int)currentPathDistance;
                }

                foreach (var (neighborNode, connectingEdgeWeight) in adjacencyList[currentNode])
                {
                    int nextConsecutiveMatchingLabelCount;

                    if (nodeLabels[currentNode] == nodeLabels[neighborNode])
                    {
                        nextConsecutiveMatchingLabelCount = currentConsecutiveMatchingLabelCount + 1;
                    }
                    else
                    {
                        nextConsecutiveMatchingLabelCount = 1;
                    }

                    if (nextConsecutiveMatchingLabelCount > maximumConsecutiveMatchingLabels)
                    {
                        continue;
                    }

                    long newPathDistance = currentPathDistance + connectingEdgeWeight;

                    if (newPathDistance < minimumDistanceByNodeAndConsecutiveLabelCount[neighborNode, nextConsecutiveMatchingLabelCount])
                    {
                        minimumDistanceByNodeAndConsecutiveLabelCount[neighborNode, nextConsecutiveMatchingLabelCount] = newPathDistance;

                        priorityQueue.Enqueue((neighborNode, nextConsecutiveMatchingLabelCount), newPathDistance);
                    }
                }
            }

            return -1;
        }
    }
}