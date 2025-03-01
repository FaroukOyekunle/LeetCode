namespace StudyPlan.Problem.LeetCode75.HashMapSet
{
    public class EqualRowandColumnPairs
    {
        public int EqualPairs(int[][] grid)
        {
            int numberOfPairs = grid.Length;

            Dictionary<string, int> rowMap = new Dictionary<string, int>();

            for(int i = 0; i < numberOfPairs; i++)
            {
                StringBuilder sb = new StringBuilder();

                for(int j = 0; j < numberOfPairs; j++)
                {
                    sb.Append(grid[i][j]).Append(",");
                }

                string rowKey = sb.ToString();

                if (rowMap.ContainsKey(rowKey))
                {
                    rowMap[rowKey]++;
                }
                    
                else
                {
                    rowMap[rowKey] = 1;
                }
            }

            int result = 0;

            for(int j = 0; j < numberOfPairs; j++)
            {
                StringBuilder sb = new StringBuilder();

                for(int i = 0; i < numberOfPairs; i++)
                {
                    sb.Append(grid[i][j]).Append(",");
                }

                string colKey = sb.ToString();

                if (rowMap.ContainsKey(colKey))
                {
                    result += rowMap[colKey];
                }
            }

            return result;
        }
    }
}