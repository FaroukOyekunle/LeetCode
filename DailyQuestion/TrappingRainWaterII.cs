namespace DailyQuestion
{
    public class TrappingRainWaterII
    {
        public int TrapRainWater(int[][] heightMap)
        {
            int m = heightMap.Length;

            if(m == 0) 
            {
                return 0;
            }

            int n = heightMap[0].Length;

            if(n == 0) 
            {
                return 0;
            }

            var pq = new PriorityQueue<(int row, int col, int height), int>();
            bool[,] visited = new bool[m, n];

            for(int i = 0; i < m; i++) 
            {
                pq.Enqueue((i, 0, heightMap[i][0]), heightMap[i][0]);
                pq.Enqueue((i, n - 1, heightMap[i][n - 1]), heightMap[i][n - 1]);

                visited[i, 0] = true;
                visited[i, n - 1] = true;
            }

            for(int j = 0; j < n; j++) 
            {
                pq.Enqueue((0, j, heightMap[0][j]), heightMap[0][j]);
                pq.Enqueue((m - 1, j, heightMap[m - 1][j]), heightMap[m - 1][j]);

                visited[0, j] = true;
                visited[m - 1, j] = true;
            }

            int[,] dirs = new int[,] { {1,0}, {-1,0}, {0,1}, {0,-1} };
            int trappedWater = 0;

            while(pq.Count > 0) 
            {
                var cell = pq.Dequeue();

                for(int d = 0; d < 4; d++) 
                {
                    int newRow = cell.row + dirs[d, 0];
                    int newColumn = cell.col + dirs[d, 1];

                    if(newRow >= 0 && newRow < m && newColumn >= 0 && newColumn < n && !visited[newRow, newColumn]) 
                    {
                        visited[newRow, newColumn] = true;

                        trappedWater += Math.Max(0, cell.height - heightMap[newRow][newColumn]);

                        pq.Enqueue((newRow, newColumn, Math.Max(cell.height, heightMap[newRow][newColumn])), Math.Max(cell.height, heightMap[newRow][newColumn]));
                    }
                }
            }

            return trappedWater;
        }
    }
}