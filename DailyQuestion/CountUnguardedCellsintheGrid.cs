namespace DailyQuestion
{
    public class CountUnguardedCellsintheGrid
    {
        public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
        {
            int[,] grid = new int[m, n];

            foreach(var g in guards)
            {
                grid[g[0], g[1]] = 1;
            }

            foreach(var w in walls)
            {
                grid[w[0], w[1]] = 2;
            }

            int[][] dirs = new int[][]
            {
            new int[]{-1, 0},
            new int[]{1, 0},
            new int[]{0, -1},
            new int[]{0, 1}
            };

            foreach(var g in guards)
            {
                foreach(var d in dirs)
                {
                    int r = g[0] + d[0];
                    int c = g[1] + d[1];

                    while(r >= 0 && r < m && c >= 0 && c < n && grid[r, c] != 1 && grid[r, c] != 2)
                    {
                        if(grid[r, c] == 0)
                        {
                            grid[r, c] = 3;
                        }

                        r += d[0];
                        c += d[1];
                    }
                }
            }

            int count = 0;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(grid[i, j] == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}