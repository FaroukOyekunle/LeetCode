namespace DailyQuestion
{
    public class SwiminRisingWater
    {
        public int SwimInWater(int[][] grid)
        {
            int n = grid.Length;
            bool[,] visited = new bool[n, n];

            var priorityQueue = new PriorityQueue<(int time, int r, int c), int>();
            priorityQueue.Enqueue((grid[0][0], 0, 0), grid[0][0]);

            int result = 0;

            while(priorityQueue.Count > 0)
            {
                var (time, r, c) = priorityQueue.Dequeue();
                if(visited[r, c]) 
                {
                    continue;
                }

                visited[r, c] = true;

                result = Math.Max(result, time);

                if(r == n - 1 && c == n - 1)
                {
                    return result;
                }

                foreach(var direction in directions)
                {
                    int newR = r + direction[0];
                    int newC = c + direction[1];

                    if (newR < 0 || newC < 0 || newR >= n || newC >= n || visited[newR, newC])
                    {
                        continue;
                    }

                    priorityQueue.Enqueue((grid[newR][newC], newR, newC), grid[newR][newC]);
                }
            }

            return -1;
        }

        private int[][] directions = new int[][]
        {
            new int[] {1, 0},  
            new int[] {-1, 0}, 
            new int[] {0, 1},  
            new int[] {0, -1}  
        };
    }
}