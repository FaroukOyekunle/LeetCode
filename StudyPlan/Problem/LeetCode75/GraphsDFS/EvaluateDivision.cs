namespace StudyPlan.Problem.LeetCode75.GraphsDFS
{
    public class EvaluateDivision
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) 
        {
    
            Dictionary<string, List<(string, double)>> graph = new Dictionary<string, List<(string, double)>>();

            for(int i = 0; i < equations.Count; i++) 
            {
                string u = equations[i][0];
                string v = equations[i][1];
                double val = values[i];
                
                if(!graph.ContainsKey(u))
                {
                    graph[u] = new List<(string, double)>();
                }
                    
                if (!graph.ContainsKey(v))
                {
                    graph[v] = new List<(string, double)>();
                }
                
                graph[u].Add((v, val));
                graph[v].Add((u, 1.0 / val));
            }
            
            double[] result = new double[queries.Count];

            for(int i = 0; i < queries.Count; i++) 
            {
                string src = queries[i][0];
                string dest = queries[i][1];
                
                if(!graph.ContainsKey(src) || !graph.ContainsKey(dest)) 
                {
                    result[i] = -1.0;
                } 
                
                else 
                {
                    HashSet<string> visited = new HashSet<string>();
                    result[i] = DFS(graph, src, dest, 1.0, visited);
                }
            }
            
            return result;
        }

        private double DFS(Dictionary<string, List<(string, double)>> graph, string current, string target, double accum, HashSet<string> visited) 
        {
            if (current == target)
            {
                return accum;
            }
            
            visited.Add(current);

            foreach(var (neighbor, weight) in graph[current]) 
            {
                if(!visited.Contains(neighbor)) 
                {
                    double res = DFS(graph, neighbor, target, accum * weight, visited);

                    if(res != -1.0)
                    {
                        return res;
                    }
                }
            }
            return -1.0;
        }
    }
}