namespace DailyQuestion
{
    public class RotatingtheBox
    {
        public char[][] RotateBoxAfterApplyingGravity(char[][] boxMatrix)
        {
            int totalRows = boxMatrix.Length;
            int totalColumns = boxMatrix[0].Length;

            for (int currentRowIndex = 0; currentRowIndex < totalRows; currentRowIndex++)
            {
                int nextAvailablePositionFromRight = totalColumns - 1;

                for (int currentColumnIndex = totalColumns - 1; currentColumnIndex >= 0; currentColumnIndex--)
                {
                    if (boxMatrix[currentRowIndex][currentColumnIndex] == '*')
                    {
                        nextAvailablePositionFromRight = currentColumnIndex - 1;
                    }
                    else if (boxMatrix[currentRowIndex][currentColumnIndex] == '#')
                    {
                        char temporaryValue = boxMatrix[currentRowIndex][nextAvailablePositionFromRight];

                        boxMatrix[currentRowIndex][nextAvailablePositionFromRight] = '#';
                        boxMatrix[currentRowIndex][currentColumnIndex] = temporaryValue;

                        nextAvailablePositionFromRight--;
                    }
                }
            }

            char[][] rotatedMatrix = new char[totalColumns][];
            for (int newRowIndex = 0; newRowIndex < totalColumns; newRowIndex++)
            {
                rotatedMatrix[newRowIndex] = new char[totalRows];
            }

            for (int originalRowIndex = 0; originalRowIndex < totalRows; originalRowIndex++)
            {
                for (int originalColumnIndex = 0; originalColumnIndex < totalColumns; originalColumnIndex++)
                {
                    rotatedMatrix[originalColumnIndex][totalRows - 1 - originalRowIndex] = boxMatrix[originalRowIndex][originalColumnIndex];
                }
            }

            return rotatedMatrix;
        }
    }
}