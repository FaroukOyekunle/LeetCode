namespace DailyQuestion
{
    public class CountSubmatricesWithEqualFrequencyofXandY
    {
        public int CountSubmatricesWithEqualXAndYAndAtLeastOneX(char[][] characterGrid)
        {
            int totalRows = characterGrid.Length;
            int totalColumns = characterGrid[0].Length;

            int[,] prefixBalanceSum = new int[totalRows, totalColumns];

            int[,] prefixCountOfX = new int[totalRows, totalColumns];

            int numberOfValidSubmatrices = 0;

            for (int currentRow = 0; currentRow < totalRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < totalColumns; currentColumn++)
                {
                    int balanceContribution = 0;

                    if (characterGrid[currentRow][currentColumn] == 'X')
                    {
                        balanceContribution = +1;
                    }
                    else if (characterGrid[currentRow][currentColumn] == 'Y')
                    {
                        balanceContribution = -1;
                    }

                    int xCharacterContribution = (characterGrid[currentRow][currentColumn] == 'X') ? 1 : 0;

                    prefixBalanceSum[currentRow, currentColumn] = balanceContribution;
                    prefixCountOfX[currentRow, currentColumn] = xCharacterContribution;

                    if (currentRow > 0)
                    {
                        prefixBalanceSum[currentRow, currentColumn] += prefixBalanceSum[currentRow - 1, currentColumn];

                        prefixCountOfX[currentRow, currentColumn] += prefixCountOfX[currentRow - 1, currentColumn];
                    }

                    if (currentColumn > 0)
                    {
                        prefixBalanceSum[currentRow, currentColumn] += prefixBalanceSum[currentRow, currentColumn - 1];

                        prefixCountOfX[currentRow, currentColumn] += prefixCountOfX[currentRow, currentColumn - 1];
                    }

                    if (currentRow > 0 && currentColumn > 0)
                    {
                        prefixBalanceSum[currentRow, currentColumn] -= prefixBalanceSum[currentRow - 1, currentColumn - 1];

                        prefixCountOfX[currentRow, currentColumn] -= prefixCountOfX[currentRow - 1, currentColumn - 1];
                    }

                    if (prefixBalanceSum[currentRow, currentColumn] == 0 && prefixCountOfX[currentRow, currentColumn] > 0)
                    {
                        numberOfValidSubmatrices++;
                    }
                }
            }

            return numberOfValidSubmatrices;
        }
    }
}