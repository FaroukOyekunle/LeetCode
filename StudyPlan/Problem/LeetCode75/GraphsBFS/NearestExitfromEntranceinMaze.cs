namespace StudyPlan.Problem.LeetCode75.GraphsBFS
{
    public class NearestExitfromEntranceinMaze
    {
        public int NearestExit(char[][] maze, int[] entrance) 
        {
            int m = maze.Length, n = maze[0].Length;
            int startR = entrance[0], startC = entrance[1];
            
            Queue<(int r, int c, int steps)> queue = new Queue<(int, int, int)>();
            queue.Enqueue((startR, startC, 0));
            
            bool[,] visited = new bool[m, n];
            visited[startR, startC] = true;
            
            int[][] dirs = new int[][] 
            {
                new int[] {1, 0},
                new int[] {-1, 0},
                new int[] {0, 1},
                new int[] {0, -1}
            };
            
            while(queue.Count > 0) 
            {
                var (r, c, steps) = queue.Dequeue();
                
                if(steps > 0 && (r == 0 || r == m - 1 || c == 0 || c == n - 1)) 
                {
                    return steps;
                }
                
                foreach(var d in dirs) 
                {
                    int nr = r + d[0], nc = c + d[1];
                    if(nr < 0 || nr >= m || nc < 0 || nc >= n)
                    {
                        continue;
                    } 
                    
                    if (visited[nr, nc])
                    {
                        continue;
                    } 

                    if (maze[nr][nc] == '+')
                    {
                        continue;
                    } 
                    
                    visited[nr, nc] = true;
                    queue.Enqueue((nr, nc, steps + 1));
                }
            }
            
            return -1;
        }
    }
}