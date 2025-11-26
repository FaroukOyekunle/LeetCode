namespace DailyQuestion
{
    public class PathsinMatrixWhoseSumIsDivisiblebyK
    {
        public int NumberOfPaths(int[][] grid, int k)
        {
            int rowCount = grid.Length;
            int columnCount = grid[0].Length;

            const int ModuloValue = 1_000_000_007;

            int[][] dpPreviousRow = new int[columnCount][];
            int[][] dpCurrentRow = new int[columnCount][];

            for(int col = 0; col < columnCount; col++)
            {
                dpPreviousRow[col] = new int[k];
                dpCurrentRow[col] = new int[k];
            }

            dpPreviousRow[0][grid[0][0] % k] = 1;

            for(int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    Array.Fill(dpCurrentRow[column], 0);

                    int cellValueMod = grid[row][column] % k;

                    if (row > 0)
                    {
                        for (int remainder = 0; remainder < k; remainder++)
                        {
                            int updatedMod = (remainder + cellValueMod) % k;
                            dpCurrentRow[column][updatedMod] = (dpCurrentRow[column][updatedMod] + dpPreviousRow[column][remainder]) % ModuloValue;
                        }
                    }

                    if (column > 0)
                    {
                        for(int remainder = 0; remainder < k; remainder++)
                        {
                            int updatedMod = (remainder + cellValueMod) % k;
                            dpCurrentRow[column][updatedMod] = (dpCurrentRow[column][updatedMod] + dpCurrentRow[column - 1][remainder]) % ModuloValue;
                        }
                    }

                    if(row == 0 && column == 0)
                    {
                        dpCurrentRow[column][grid[0][0] % k] = 1;
                    }
                }

                var dpTemp = dpPreviousRow;
                dpPreviousRow = dpCurrentRow;
                dpCurrentRow = dpTemp;
            }

            return dpPreviousRow[columnCount - 1][0];
        }
    }
}