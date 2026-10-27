using System;

namespace DailyQuestion
{
    public class CreateGridWithExactlyOnePath
    {
        public string[] CreateGrid(int rowCount, int columnCount)
        {
            string[] gridRows = new string[rowCount];

            for (int currentRowIndex = 0; currentRowIndex < rowCount; currentRowIndex++)
            {
                char[] rowCells = new char[columnCount];
                Array.Fill(rowCells, '#');

                gridRows[currentRowIndex] = new string(rowCells);
            }

            char[] topRowCells = gridRows[0].ToCharArray();
            Array.Fill(topRowCells, '.', 0, columnCount);
            gridRows[0] = new string(topRowCells);

            for (int currentRowIndex = 1; currentRowIndex < rowCount; currentRowIndex++)
            {
                char[] currentRowCells = gridRows[currentRowIndex].ToCharArray();
                currentRowCells[columnCount - 1] = '.';
                gridRows[currentRowIndex] = new string(currentRowCells);
            }

            return gridRows;
        }
    }
}