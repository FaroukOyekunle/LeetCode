namespace DailyQuestion
{
    public class PacificAtlanticWaterFlow
    {
        private int[][] directions = new int[][]
        {
            new int[] {1, 0},  
            new int[] {-1, 0}, 
            new int[] {0, 1},  
            new int[] {0, -1}  
        };

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int morning = heights.Length;
            int night = heights[0].Length;

            bool[,] pacific = new bool[morning, night];
            bool[,] atlantic = new bool[morning, night];
            var result = new List<IList<int>>();

            for(int i = 0; i < morning; i++)
            {
                CalculateVisitDirection(heights, pacific, i, 0);
            }

            for(int j = 0; j < night; j++)
            {
                CalculateVisitDirection(heights, pacific, 0, j);
            }

            for (int i = 0; i < morning; i++)
            {
                Dfs(heights, atlantic, i, night - 1);
            }

            for(int j = 0; j < night; j++)
            {
                Dfs(heights, atlantic, morning - 1, j);
            }

            for(int i = 0; i < morning; i++)
            {
                for(int j = 0; j < night; j++)
                {
                    if(pacific[i, j] && atlantic[i, j])
                    {
                        result.Add(new List<int> { i, j });
                    }
                }
            }

            return result;
        }

        private void CalculateVisitDirection(int[][] heights, bool[,] visited, int r, int c)
        {
            int m = heights.Length;
            int n = heights[0].Length;

            visited[r, c] = true;

            foreach(var dir in directions)
            {
                int newR = r + dir[0];
                int newC = c + dir[1];

                if(newR < 0 || newC < 0 || newR >= m || newC >= n)
                {
                    continue;
                }

                if(!visited[newR, newC] && heights[newR][newC] >= heights[r][c])
                {
                    CalculateVisitDirection(heights, visited, newR, newC);
                }
            }
        }
    }
}