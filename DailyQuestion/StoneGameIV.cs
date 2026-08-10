namespace DailyQuestion
{
    public class StoneGameIV
    {
        public bool WinnerSquareGame(int n)
        {
            bool[] isWinningPosition = new bool[n + 1];

            for (int remainingStoneCount = 1; remainingStoneCount <= n; remainingStoneCount++)
            {
                for (int squareRoot = 1; squareRoot * squareRoot <= remainingStoneCount; squareRoot++)
                {
                    int squareNumber = squareRoot * squareRoot;

                    int remainingStoneCountAfterMove = remainingStoneCount - squareNumber;

                    bool isOpponentInWinningPosition = isWinningPosition[remainingStoneCountAfterMove];

                    if (!isOpponentInWinningPosition)
                    {
                        isWinningPosition[remainingStoneCount] = true;
                        break;
                    }
                }
            }

            return isWinningPosition[n];
        }
    }
}