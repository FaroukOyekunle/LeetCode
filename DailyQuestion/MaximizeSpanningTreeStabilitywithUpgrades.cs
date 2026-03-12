namespace DailyQuestion
{
    public class MaximizeSpanningTreeStabilitywithUpgrades
    {
        public int FindMaximumStability(int totalNodes, int[][] edgeList, int maxAllowedUpgrades)
        {
            int minimumPossibleStrength = 1;
            int maximumPossibleStrength = 200000;

            int bestAchievableStability = -1;

            while (minimumPossibleStrength <= maximumPossibleStrength)
            {
                int candidateStability = minimumPossibleStrength + (maximumPossibleStrength - minimumPossibleStrength) / 2;

                if (CanConstructSpanningTree(totalNodes, edgeList, maxAllowedUpgrades, candidateStability))
                {
                    bestAchievableStability = candidateStability;
                    minimumPossibleStrength = candidateStability + 1;
                }

                else
                {
                    maximumPossibleStrength = candidateStability - 1;
                }
            }

            return bestAchievableStability;
        }

        private bool CanConstructSpanningTree(int totalNodes, int[][] edgeList, int maxAllowedUpgrades, int requiredStrength)
        {
            DisjointSetUnion disjointSet = new DisjointSetUnion(totalNodes);

            int edgesUsedInTree = 0;
            int upgradesUsed = 0;

            List<int[]> optionalEdges = new List<int[]>();

            foreach (var edge in edgeList)
            {
                int sourceNode = edge[0];
                int destinationNode = edge[1];
                int edgeStrength = edge[2];
                int isMandatoryEdge = edge[3];

                if (isMandatoryEdge == 1)
                {
                    if (edgeStrength < requiredStrength)
                    {
                        return false;
                    }

                    if (!disjointSet.Union(sourceNode, destinationNode))
                    {
                        return false;
                    }

                    edgesUsedInTree++;
                }
                else
                {
                    optionalEdges.Add(edge);
                }
            }

            List<int[]> edgesMeetingStrength = new List<int[]>();
            List<int[]> edgesEligibleForUpgrade = new List<int[]>();

            foreach (var edge in optionalEdges)
            {
                int edgeStrength = edge[2];

                if (edgeStrength >= requiredStrength)
                {
                    edgesMeetingStrength.Add(edge);
                }
                else if (edgeStrength * 2 >= requiredStrength)
                {
                    edgesEligibleForUpgrade.Add(edge);
                }
            }

            foreach (var edge in edgesMeetingStrength)
            {
                int sourceNode = edge[0];
                int destinationNode = edge[1];

                if (disjointSet.Union(sourceNode, destinationNode))
                {
                    edgesUsedInTree++;
                }
            }

            foreach (var edge in edgesEligibleForUpgrade)
            {
                if (edgesUsedInTree == totalNodes - 1)
                {
                    break;
                }

                int sourceNode = edge[0];
                int destinationNode = edge[1];

                if (disjointSet.Union(sourceNode, destinationNode))
                {
                    edgesUsedInTree++;
                    upgradesUsed++;

                    if (upgradesUsed > maxAllowedUpgrades)
                    {
                        return false;
                    }
                }
            }

            return edgesUsedInTree == totalNodes - 1;
        }

        class DisjointSetUnion
        {
            private int[] parent;
            private int[] rank;

            public DisjointSetUnion(int totalNodes)
            {
                parent = new int[totalNodes];
                rank = new int[totalNodes];

                for (int node = 0; node < totalNodes; node++)
                {
                    parent[node] = node;
                }
            }

            public int Find(int node)
            {
                if (parent[node] != node)
                {
                    parent[node] = Find(parent[node]);
                }

                return parent[node];
            }

            public bool Union(int nodeA, int nodeB)
            {
                int rootA = Find(nodeA);
                int rootB = Find(nodeB);

                if (rootA == rootB)
                {
                    return false;
                }

                if (rank[rootA] < rank[rootB])
                {
                    parent[rootA] = rootB;
                }
                else if (rank[rootA] > rank[rootB])
                {
                    parent[rootB] = rootA;
                }
                else
                {
                    parent[rootB] = rootA;
                    rank[rootA]++;
                }

                return true;
            }
        }
    }
}