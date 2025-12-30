namespace DailyQuestion
{
    public class MagicSquaresInGrid
    {
        public int NumMagicSquaresInside(int[][] grid)
        {
            int totalRows = grid.Length;
            int totalColumns = grid[0].Length;
            int magicSquareCount = 0;

            for(int rowIndex = 0; rowIndex <= totalRows - 3; rowIndex++)
            {
                for(int columnIndex = 0; columnIndex <= totalColumns - 3; columnIndex++)
                {
                    if(grid[rowIndex + 1][columnIndex + 1] == 5 && IsMagicSquare(grid, rowIndex, columnIndex))
                    {
                        magicSquareCount++;
                    }
                }
            }

            return magicSquareCount;
        }

        private bool IsMagicSquare(int[][] grid, int startRow, int startColumn)
        {
            bool[] seenNumbers = new bool[10];

            for(int rowOffset = 0; rowOffset < 3; rowOffset++)
            {
                for(int columnOffset = 0; columnOffset < 3; columnOffset++)
                {
                    int currentValue = grid[startRow + rowOffset][startColumn + columnOffset];
                    if(currentValue < 1 || currentValue > 9 || seenNumbers[currentValue])
                    {
                        return false;
                    }
                    seenNumbers[currentValue] = true;
                }
            }

            int targetSum = grid[startRow][startColumn] + grid[startRow][startColumn + 1] + grid[startRow][startColumn + 2];

            for(int rowOffset = 0; rowOffset < 3; rowOffset++)
            {
                if(grid[startRow + rowOffset][startColumn] + grid[startRow + rowOffset][startColumn + 1] + grid[startRow + rowOffset][startColumn + 2] != targetSum)
                {
                    return false;
                }
            }

            for(int columnOffset = 0; columnOffset < 3; columnOffset++)
            {
                if(grid[startRow][startColumn + columnOffset] + grid[startRow + 1][startColumn + columnOffset] + grid[startRow + 2][startColumn + columnOffset] != targetSum)
                {
                    return false;
                }
            }

            if(grid[startRow][startColumn] + grid[startRow + 1][startColumn + 1] + grid[startRow + 2][startColumn + 2] != targetSum)
            {
                return false;
            }

            if(grid[startRow][startColumn + 2] + grid[startRow + 1][startColumn + 1] + grid[startRow + 2][startColumn] != targetSum)
            {
                return false;
            }

            return true;
        }
    }
}