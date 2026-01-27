namespace DailyQuestion
{
    public class MinimumCostPathwithEdgeReversals
    {
        public int FindMinimumCostPath(int nodeCount, int[][] edgeList)
        {
            var adjacencyList = new List<(int destinationNode, int edgeCost)>[nodeCount];
            
            for(int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
            {
                adjacencyList[nodeIndex] = new List<(int, int)>();
            }

            foreach(var edge in edgeList)
            {
                int startNode = edge[0], endNode = edge[1], forwardCost = edge[2];
                adjacencyList[startNode].Add((endNode, forwardCost));        
                adjacencyList[endNode].Add((startNode, 2 * forwardCost));     
            }

            const long Infinity = long.MaxValue;
            long[] minimumDistances = new long[nodeCount];

            Array.Fill(minimumDistances, Infinity);

            var priorityQueue = new PriorityQueue<int, long>();
            minimumDistances[0] = 0;
            priorityQueue.Enqueue(0, 0);

            while(priorityQueue.Count > 0)
            {
                int currentNode = priorityQueue.Dequeue();
                long currentDistance = minimumDistances[currentNode];

                if(currentNode == nodeCount - 1)
                {
                    return (int)currentDistance;
                }

                foreach(var (neighborNode, edgeCost) in adjacencyList[currentNode])
                {
                    long newDistance = currentDistance + edgeCost;
                    
                    if(newDistance < minimumDistances[neighborNode])
                    {
                        minimumDistances[neighborNode] = newDistance;
                        priorityQueue.Enqueue(neighborNode, newDistance);
                    }
                }
            }

            return -1;
        }
    }
}