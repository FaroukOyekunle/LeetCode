namespace DailyQuestion
{
    public class MaximumPathScoreinaGrid
    {
        public int MaxPathScore(int[][] gridValues, int maxAllowedCost)
        {
            int totalRows = gridValues.Length;
            int totalColumns = gridValues[0].Length;

            int[,,] maxScoreAtState = new int[totalRows, totalColumns, maxAllowedCost + 1];

            for (int rowIndex = 0; rowIndex < totalRows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
                {
                    for (int costUsed = 0; costUsed <= maxAllowedCost; costUsed++)
                    {
                        maxScoreAtState[rowIndex, columnIndex, costUsed] = -1;
                    }
                }
            }

            maxScoreAtState[0, 0, 0] = 0;

            for (int rowIndex = 0; rowIndex < totalRows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
                {
                    for (int costUsedSoFar = 0; costUsedSoFar <= maxAllowedCost; costUsedSoFar++)
                    {
                        int currentScore = maxScoreAtState[rowIndex, columnIndex, costUsedSoFar];

                        if (currentScore == -1)
                        {
                            continue;
                        }

                        if (columnIndex + 1 < totalColumns)
                        {
                            int nextCellValue = gridValues[rowIndex][columnIndex + 1];

                            int additionalCost = (nextCellValue == 0) ? 0 : 1;
                            int newTotalCost = costUsedSoFar + additionalCost;

                            if (newTotalCost <= maxAllowedCost)
                            {
                                int newScore = currentScore + nextCellValue;

                                maxScoreAtState[rowIndex, columnIndex + 1, newTotalCost] = Math.Max(maxScoreAtState[rowIndex, columnIndex + 1, newTotalCost], newScore);
                            }
                        }

                        if (rowIndex + 1 < totalRows)
                        {
                            int nextCellValue = gridValues[rowIndex + 1][columnIndex];

                            int additionalCost = (nextCellValue == 0) ? 0 : 1;
                            int newTotalCost = costUsedSoFar + additionalCost;

                            if (newTotalCost <= maxAllowedCost)
                            {
                                int newScore = currentScore + nextCellValue;

                                maxScoreAtState[rowIndex + 1, columnIndex, newTotalCost] = Math.Max(maxScoreAtState[rowIndex + 1, columnIndex, newTotalCost],newScore);
                            }
                        }
                    }
                }
            }

            int bestAchievableScore = -1;

            for (int costUsed = 0; costUsed <= maxAllowedCost; costUsed++)
            {
                bestAchievableScore = Math.Max(bestAchievableScore, maxScoreAtState[totalRows - 1, totalColumns - 1, costUsed]);
            }

            return bestAchievableScore;
        }
    }
}