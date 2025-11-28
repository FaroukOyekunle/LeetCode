namespace DailyQuestion
{
    public class MaximumNumberofKDivisibleComponents
    {
        public int MaxKDivisibleComponents(int nodeCount, int[][] edges, int[] nodeValues, int k)
        {
            List<int>[] adjacencyList = new List<int>[nodeCount];
            for(int idx = 0; idx < nodeCount; idx++)
            {
                adjacencyList[idx] = new List<int>();
            }

            foreach(var edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }

            int kDivisibleComponents = 0;

            int ComputeSubtreeRemainder(int current, int parent)
            {
                long subtreeSum = nodeValues[current];

                foreach(var neighbor in adjacencyList[current])
                {
                    if(neighbor == parent)
                    {
                        continue;
                    }

                    long childRemainder = ComputeSubtreeRemainder(neighbor, current);
                    subtreeSum += childRemainder;
                }

                if (subtreeSum % k == 0)
                {
                    kDivisibleComponents++;
                    return 0;
                }

                return (int)(subtreeSum % k);
            }

            ComputeSubtreeRemainder(0, -1);

            return kDivisibleComponents;
        }
    }
}