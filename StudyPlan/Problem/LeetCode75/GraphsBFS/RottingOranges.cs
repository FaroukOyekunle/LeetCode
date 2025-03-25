namespace StudyPlan.Problem.LeetCode75.GraphsBFS
{
    public class RottingOranges
    {
        public int OrangesRotting(int[][] grid) 
        {
            int m = grid.Length, n = grid[0].Length;
            
            Queue<(int, int)> queue = new Queue<(int, int)>();

            int freshOranges = 0;
            
            for(int i = 0; i < m; i++) 
            {
                for(int j = 0; j < n; j++) 
                {
                    if(grid[i][j] == 2) 
                    {
                        queue.Enqueue((i, j));
                    } 
                    
                    else if(grid[i][j] == 1) 
                    {
                        freshOranges++;
                    }
                }
            }
            
            if(freshOranges == 0)
            {
                return 0;
            } 
            
            int minutes = 0;
            int[][] directions = { new int[] {0,1}, new int[] {0,-1}, new int[] {1,0}, new int[] {-1,0} };
            
            while(queue.Count > 0) 
            {
                int size = queue.Count;
                bool rotted = false;

                for(int i = 0; i < size; i++) 
                {
                    var (x, y) = queue.Dequeue();

                    foreach(var dir in directions) 
                    {
                        int nx = x + dir[0], ny = y + dir[1];
                        
                        if(nx >= 0 && ny >= 0 && nx < m && ny < n && grid[nx][ny] == 1) 
                        {
                            grid[nx][ny] = 2;
                            queue.Enqueue((nx, ny));
                            freshOranges--;
                            rotted = true;
                        }
                    }
                }

                if(rotted)
                {
                    minutes++;
                } 
            }
            
            return freshOranges == 0 ? minutes : -1;
        }
    }
}