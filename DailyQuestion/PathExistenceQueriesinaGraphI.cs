namespace DailyQuestion
{
    public class PathExistenceQueriesinaGraphI
    {
        public bool[] PathExistenceQueries(int nodeCount, int[] sortedNodeValues, int maximumAllowedDifference, int[][] queries)
        {
            int[] connectedComponentIds = new int[nodeCount];

            int currentConnectedComponentId = 0;

            connectedComponentIds[0] = currentConnectedComponentId;

            for (int currentNodeIndex = 1; currentNodeIndex < nodeCount; currentNodeIndex++)
            {
                int differenceFromPreviousNode = sortedNodeValues[currentNodeIndex] - sortedNodeValues[currentNodeIndex - 1];

                if (differenceFromPreviousNode > maximumAllowedDifference)
                {
                    currentConnectedComponentId++;
                }

                connectedComponentIds[currentNodeIndex] = currentConnectedComponentId;
            }

            bool[] queryResults = new bool[queries.Length];

            for (int queryIndex = 0; queryIndex < queries.Length; queryIndex++)
            {
                int sourceNodeIndex = queries[queryIndex][0];
                int destinationNodeIndex = queries[queryIndex][1];

                queryResults[queryIndex] = connectedComponentIds[sourceNodeIndex] == connectedComponentIds[destinationNodeIndex];
            }

            return queryResults;
        }
    }
}