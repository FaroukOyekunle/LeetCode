namespace DailyQuestion
{
    public class NumberofPathswithMaxScore
    {
        public int[] PathsWithMaxScore(IList<string> board)
        {
            const int MOD = 1_000_000_007;

            int boardSize = board.Count;

            int[,] maximumScoreAtCell = new int[boardSize, boardSize];
            int[,] numberOfMaximumScorePaths = new int[boardSize, boardSize];

            for (int rowIndex = 0; rowIndex < boardSize; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < boardSize; columnIndex++)
                {
                    maximumScoreAtCell[rowIndex, columnIndex] = -1;
                }
            }

            maximumScoreAtCell[0, 0] = 0;
            numberOfMaximumScorePaths[0, 0] = 1;

            for (int rowIndex = 0; rowIndex < boardSize; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < boardSize; columnIndex++)
                {
                    if (board[rowIndex][columnIndex] == 'X')
                    {
                        continue;
                    }

                    if (rowIndex == 0 && columnIndex == 0)
                    {
                        continue;
                    }

                    int highestPreviousScore = -1;
                    int totalBestPathCount = 0;

                    int[,] previousCellCoordinates =
                    {
                        { rowIndex - 1, columnIndex },         
                        { rowIndex, columnIndex - 1 },         
                        { rowIndex - 1, columnIndex - 1 }      
                    };

                    for (int directionIndex = 0; directionIndex < 3; directionIndex++)
                    {
                        int previousRowIndex = previousCellCoordinates[directionIndex, 0];
                        int previousColumnIndex = previousCellCoordinates[directionIndex, 1];

                        if (previousRowIndex < 0 || previousColumnIndex < 0)
                        {
                            continue;
                        }

                        if (maximumScoreAtCell[previousRowIndex, previousColumnIndex] == -1)
                        {
                            continue;
                        }

                        if (maximumScoreAtCell[previousRowIndex, previousColumnIndex] > highestPreviousScore)
                        {
                            highestPreviousScore = maximumScoreAtCell[previousRowIndex, previousColumnIndex];

                            totalBestPathCount = numberOfMaximumScorePaths[previousRowIndex, previousColumnIndex];
                        }
                        else if (maximumScoreAtCell[previousRowIndex, previousColumnIndex] == highestPreviousScore)
                        {
                            totalBestPathCount = (totalBestPathCount + numberOfMaximumScorePaths[previousRowIndex, previousColumnIndex]) % MOD;
                        }
                    }

                    if (highestPreviousScore == -1)
                    {
                        continue;
                    }

                    int currentCellScore = 0;

                    char currentCellCharacter = board[rowIndex][columnIndex];

                    if (currentCellCharacter != 'S' && currentCellCharacter != 'E')
                    {
                        currentCellScore = currentCellCharacter - '0';
                    }

                    maximumScoreAtCell[rowIndex, columnIndex] = highestPreviousScore + currentCellScore;

                    numberOfMaximumScorePaths[rowIndex, columnIndex] = totalBestPathCount;
                }
            }

            if (maximumScoreAtCell[boardSize - 1, boardSize - 1] == -1)
            {
                return new[] { 0, 0 };
            }

            return new[]
            {
                maximumScoreAtCell[boardSize - 1, boardSize - 1],
                numberOfMaximumScorePaths[boardSize - 1, boardSize - 1]
            };
        }
    }
}