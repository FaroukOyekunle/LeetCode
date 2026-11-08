using System;

namespace DailyQuestion
{
    public class CountServersthatCommunicate
    {
        public int CountServers(int[][] serverGrid)
        {
            int totalRowCount = serverGrid.Length;
            int totalColumnCount = serverGrid[0].Length;

            int[] serverCountByRow = new int[totalRowCount];
            int[] serverCountByColumn = new int[totalColumnCount];

            for (int currentRowIndex = 0; currentRowIndex < totalRowCount; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < totalColumnCount; currentColumnIndex++)
                {
                    if (serverGrid[currentRowIndex][currentColumnIndex] == 1)
                    {
                        serverCountByRow[currentRowIndex]++;
                        serverCountByColumn[currentColumnIndex]++;
                    }
                }
            }

            int totalCommunicatingServerCount = 0;

            for (int currentRowIndex = 0; currentRowIndex < totalRowCount; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < totalColumnCount; currentColumnIndex++)
                {
                    if (serverGrid[currentRowIndex][currentColumnIndex] == 1 && (serverCountByRow[currentRowIndex] > 1 || serverCountByColumn[currentColumnIndex] > 1))
                    {
                        totalCommunicatingServerCount++;
                    }
                }
            }

            return totalCommunicatingServerCount;
        }
    }
}