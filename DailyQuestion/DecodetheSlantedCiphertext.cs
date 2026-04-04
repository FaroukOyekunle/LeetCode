namespace DailyQuestion
{
    public class DecodetheSlantedCiphertext
    {
        public string DecodeSlantedCipherText(string encodedText, int numberOfRows)
        {
            if (numberOfRows == 1)
            {
                return encodedText;
            }

            int totalCharacters = encodedText.Length;

            int numberOfColumns = totalCharacters / numberOfRows;

            char[,] characterMatrix = new char[numberOfRows, numberOfColumns];

            int currentCharacterIndex = 0;

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    characterMatrix[row, column] = encodedText[currentCharacterIndex++];
                }
            }

            var decodedTextBuilder = new System.Text.StringBuilder();

            for (int startingColumn = 0; startingColumn < numberOfColumns; startingColumn++)
            {
                int currentRow = 0;
                int currentColumn = startingColumn;

                while (currentRow < numberOfRows && currentColumn < numberOfColumns)
                {
                    decodedTextBuilder.Append(characterMatrix[currentRow, currentColumn]);

                    currentRow++;
                    currentColumn++;
                }
            }
        }
    }
}