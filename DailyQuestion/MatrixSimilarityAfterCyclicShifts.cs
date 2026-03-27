namespace DailyQuestion
{
    public class MatrixSimilarityAfterCyclicShifts
    {
        public bool AreRowsInvariantUnderAlternatingShifts(int[][] inputMatrix, int shiftDistance)
        {
            int totalRowCount = inputMatrix.Length;
            int totalColumnCount = inputMatrix[0].Length;

            int normalizedShiftDistance = shiftDistance % totalColumnCount;

            for (int currentRowIndex = 0; currentRowIndex < totalRowCount; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < totalColumnCount; currentColumnIndex++)
                {
                    int correspondingShiftedColumnIndex;

                    if (currentRowIndex % 2 == 0)
                    {
                        correspondingShiftedColumnIndex = (currentColumnIndex + normalizedShiftDistance) % totalColumnCount;
                    }

                    else
                    {
                        correspondingShiftedColumnIndex = (currentColumnIndex - normalizedShiftDistance + totalColumnCount) % totalColumnCount;
                    }

                    if (inputMatrix[currentRowIndex][currentColumnIndex] != inputMatrix[currentRowIndex][correspondingShiftedColumnIndex])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}