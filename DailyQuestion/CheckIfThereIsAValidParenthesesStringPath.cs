namespace DailyQuestion
{
    public class CheckIfThereIsAValidParenthesesStringPath
    {
        public bool HasValidPath(char[][] grid)
        {
            int gridRowCount = grid.Length;
            int gridColumnCount = grid[0].Length;

            int totalPathCellCount =
                gridRowCount + gridColumnCount - 1;

            if (totalPathCellCount % 2 != 0)
            {
                return false;
            }

            if (grid[0][0] == ')' ||
                grid[gridRowCount - 1][gridColumnCount - 1] == '(')
            {
                return false;
            }

            bool[,,] reachableBalanceStates =
                new bool[
                    gridRowCount,
                    gridColumnCount,
                    totalPathCellCount + 1];

            reachableBalanceStates[0, 0, 1] = true;

            for (int currentRowIndex = 0;
                 currentRowIndex < gridRowCount;
                 currentRowIndex++)
            {
                for (int currentColumnIndex = 0;
                     currentColumnIndex < gridColumnCount;
                     currentColumnIndex++)
                {
                    if (currentRowIndex == 0 &&
                        currentColumnIndex == 0)
                    {
                        continue;
                    }

                    int currentParenthesesBalanceChange =
                        grid[currentRowIndex][currentColumnIndex] == '('
                            ? 1
                            : -1;

                    int maximumReachableBalance =
                        currentRowIndex + currentColumnIndex + 1;

                    for (int currentBalance = 0;
                         currentBalance <= maximumReachableBalance;
                         currentBalance++)
                    {
                        int previousParenthesesBalance =
                            currentBalance - currentParenthesesBalanceChange;

                        if (previousParenthesesBalance < 0 ||
                            previousParenthesesBalance > totalPathCellCount)
                        {
                            continue;
                        }

                        bool canReachCurrentCellFromAbove =
                            currentRowIndex > 0 &&
                            reachableBalanceStates[
                                currentRowIndex - 1,
                                currentColumnIndex,
                                previousParenthesesBalance];

                        bool canReachCurrentCellFromLeft =
                            currentColumnIndex > 0 &&
                            reachableBalanceStates[
                                currentRowIndex,
                                currentColumnIndex - 1,
                                previousParenthesesBalance];

                        if (canReachCurrentCellFromAbove ||
                            canReachCurrentCellFromLeft)
                        {
                            reachableBalanceStates[
                                currentRowIndex,
                                currentColumnIndex,
                                currentBalance] = true;
                        }
                    }
                }
            }

            return reachableBalanceStates[gridRowCount - 1, gridColumnCount - 1, 0];
        }
    }
}