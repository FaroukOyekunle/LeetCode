namespace DailyQuestion
{
    public class IncrementSubmatricesByOne
    {
        public int[][] ApplyRangeAddQueries(int size, int[][] queries)
        {
            int[,] differenceGrid = new int[size + 1, size + 1];

            foreach(var query in queries)
            {
                int r1 = query[0], c1 = query[1], r2 = query[2], c2 = query[3];
                differenceGrid[r1, c1] += 1;
                differenceGrid[r1, c2 + 1] -= 1;
                differenceGrid[r2 + 1, c1] -= 1;
                differenceGrid[r2 + 1, c2 + 1] += 1;
            }

            int[][] result = new int[size][];
            for(int row = 0; row < size; row++)
            {
                result[row] = new int[size];
            }

            for(int row = 0; row < size; row++)
            {
                for(int col = 0; col < size; col++)
                {
                    int top = (row > 0) ? differenceGrid[row - 1, col] : 0;
                    int left = (col > 0) ? differenceGrid[row, col - 1] : 0;
                    int diag = (row > 0 && col > 0) ? differenceGrid[row - 1, col - 1] : 0;

                    differenceGrid[row, col] = differenceGrid[row, col] + top + left - diag;
                    result[row][col] = differenceGrid[row, col];
                }
            }

            return result;
        }
    }
}