namespace StudyPlan.Problem.LeetCode75.GraphsDFS
{
    public class ReorderRoutestoMakeAllPathsLeadtotheCityZero
    {
        public int MinReorder(int n, int[][] connections) 
        {
    
            List<(int, int)>[] graph = new List<(int, int)>[n];
            for(int i = 0; i < n; i++) 
            {
                graph[i] = new List<(int, int)>();
            }
            
            foreach(var conn in connections) 
            {
                int u = conn[0], v = conn[1];
                graph[u].Add((v, 1));
                graph[v].Add((u, 0)); 
            }

            bool[] visited = new bool[n];
            int changes = 0;

            void DFS(int node) 
            {
                visited[node] = true;
                foreach(var (neighbor, needsReversal) in graph[node]) 
                {
                    if(!visited[neighbor]) 
                    {
                        changes += needsReversal; 
                        DFS(neighbor);
                    }
                }
            }

            DFS(0);

            return changes;
        }
    }
}