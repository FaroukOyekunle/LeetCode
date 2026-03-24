namespace DailyQuestion
{
    public class ConstructProductMatrix
    {
        public int[][] ConstructProductMatrixExcludingCurrentCell(int[][] inputMatrix)
{
    int totalRowCount = inputMatrix.Length;
    int totalColumnCount = inputMatrix[0].Length;

    int totalElementCount = totalRowCount * totalColumnCount;

    const int modulo = 12345;

    int[] flattenedValues = new int[totalElementCount];

    int flattenedIndex = 0;

    for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
    {
        for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
        {
            flattenedValues[flattenedIndex++] =
                inputMatrix[rowIndex][columnIndex] % modulo;
        }
    }

    int[] prefixProductExcludingCurrent = new int[totalElementCount];

    prefixProductExcludingCurrent[0] = 1;

    for (int index = 1; index < totalElementCount; index++)
    {
        prefixProductExcludingCurrent[index] =
            (int)(
                (long)prefixProductExcludingCurrent[index - 1] *
                flattenedValues[index - 1] % modulo
            );
    }

    int[] suffixProductExcludingCurrent = new int[totalElementCount];

    suffixProductExcludingCurrent[totalElementCount - 1] = 1;

    for (int index = totalElementCount - 2; index >= 0; index--)
    {
        suffixProductExcludingCurrent[index] =
            (int)(
                (long)suffixProductExcludingCurrent[index + 1] *
                flattenedValues[index + 1] % modulo
            );
    }

    int[][] productMatrix = new int[totalRowCount][];

    for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
    {
        productMatrix[rowIndex] = new int[totalColumnCount];
    }

    flattenedIndex = 0;

    for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
    {
        for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
        {
            productMatrix[rowIndex][columnIndex] =
                (int)(
                    (long)prefixProductExcludingCurrent[flattenedIndex] *
                    suffixProductExcludingCurrent[flattenedIndex] % modulo
                );

            flattenedIndex++;
        }
    }

    return productMatrix;
}
    }
}