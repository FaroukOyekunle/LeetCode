namespace DailyQuestion
{
    public class MaximumAmountofMoneyRobotCanEarn
    {
        public int GetMaximumCollectableCoins(int[][] coinGrid)
        {
            int totalRows = coinGrid.Length;
            int totalColumns = coinGrid[0].Length;

            int[,,] maxCoinsAtState = new int[totalRows, totalColumns, 3];

            for (int row = 0; row < totalRows; row++)
            {
                for (int col = 0; col < totalColumns; col++)
                {
                    for (int skipsUsed = 0; skipsUsed < 3; skipsUsed++)
                    {
                        maxCoinsAtState[row, col, skipsUsed] = int.MinValue;
                    }
                }
            }

            int startingCellValue = coinGrid[0][0];

            if (startingCellValue >= 0)
            {
                maxCoinsAtState[0, 0, 0] = startingCellValue;
            }
            else
            {
                maxCoinsAtState[0, 0, 0] = startingCellValue;

                maxCoinsAtState[0, 0, 1] = 0;
            }

            for (int row = 0; row < totalRows; row++)
            {
                for (int col = 0; col < totalColumns; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        continue;
                    }

                    int currentCellValue = coinGrid[row][col];

                    for (int skipsUsed = 0; skipsUsed < 3; skipsUsed++)
                    {
                        if (row > 0)
                        {
                            if (maxCoinsAtState[row - 1, col, skipsUsed] != int.MinValue)
                            {
                                maxCoinsAtState[row, col, skipsUsed] = Math.Max(maxCoinsAtState[row, col, skipsUsed], maxCoinsAtState[row - 1, col, skipsUsed] + currentCellValue);
                            }

                            if (currentCellValue < 0 && skipsUsed > 0 && maxCoinsAtState[row - 1, col, skipsUsed - 1] != int.MinValue)
                            {
                                maxCoinsAtState[row, col, skipsUsed] = Math.Max(maxCoinsAtState[row, col, skipsUsed], maxCoinsAtState[row - 1, col, skipsUsed - 1]);
                            }
                        }

                        if (col > 0)
                        {
                            if (maxCoinsAtState[row, col - 1, skipsUsed] != int.MinValue)
                            {
                                maxCoinsAtState[row, col, skipsUsed] = Math.Max(maxCoinsAtState[row, col, skipsUsed], maxCoinsAtState[row, col - 1, skipsUsed] + currentCellValue);
                            }

                            if (currentCellValue < 0 && skipsUsed > 0 && maxCoinsAtState[row, col - 1, skipsUsed - 1] != int.MinValue)
                            {
                                maxCoinsAtState[row, col, skipsUsed] = Math.Max(maxCoinsAtState[row, col, skipsUsed], maxCoinsAtState[row, col - 1, skipsUsed - 1]);
                            }
                        }
                    }
                }
            }

            return Math.Max(maxCoinsAtState[totalRows - 1, totalColumns - 1, 0],
                Math.Max(maxCoinsAtState[totalRows - 1, totalColumns - 1, 1], maxCoinsAtState[totalRows - 1, totalColumns - 1, 2]));
        }
    }
}