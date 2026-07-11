namespace DailyQuestion
{
    public class CounttheNumberofCompleteComponents
    {
        public int CountCompleteComponents(int totalVertices, int[][] edges)
        {
            List<int>[] adjacencyList = new List<int>[totalVertices];

            for (int vertexIndex = 0; vertexIndex < totalVertices; vertexIndex++)
            {
                adjacencyList[vertexIndex] = new List<int>();
            }

            foreach (int[] edge in edges)
            {
                int firstVertex = edge[0];
                int secondVertex = edge[1];

                adjacencyList[firstVertex].Add(secondVertex);
                adjacencyList[secondVertex].Add(firstVertex);
            }

            bool[] visitedVertices = new bool[totalVertices];

            int completeConnectedComponentCount = 0;

            for (int startingVertex = 0; startingVertex < totalVertices; startingVertex++)
            {
                if (visitedVertices[startingVertex])
                {
                    continue;
                }

                int connectedComponentVertexCount = 0;
                int connectedComponentDegreeSum = 0;

                DepthFirstSearch(startingVertex, adjacencyList, visitedVertices, ref connectedComponentVertexCount, ref connectedComponentDegreeSum);

                int actualEdgeCount = connectedComponentDegreeSum / 2;

                int expectedEdgeCountForCompleteGraph = connectedComponentVertexCount * (connectedComponentVertexCount - 1) / 2;

                if (actualEdgeCount == expectedEdgeCountForCompleteGraph)
                {
                    completeConnectedComponentCount++;
                }
            }

            return completeConnectedComponentCount;
        }

        private void DepthFirstSearch(int currentVertex, List<int>[] adjacencyList, bool[] visitedVertices, ref int connectedComponentVertexCount, ref int connectedComponentDegreeSum)
        {
            visitedVertices[currentVertex] = true;

            connectedComponentVertexCount++;

            connectedComponentDegreeSum += adjacencyList[currentVertex].Count;

            foreach (int adjacentVertex in adjacencyList[currentVertex])
            {
                if (!visitedVertices[adjacentVertex])
                {
                    DepthFirstSearch(adjacentVertex, adjacencyList, visitedVertices, ref connectedComponentVertexCount, ref connectedComponentDegreeSum);
                }
            }
        }
    }
}