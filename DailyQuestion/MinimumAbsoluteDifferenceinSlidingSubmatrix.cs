namespace DailyQuestion
{
    public class MinimumAbsoluteDifferenceinSlidingSubmatrix
    {
        public int[][] CalculateMinimumAbsoluteDifferenceForEachSubmatrix(int[][] inputMatrix, int submatrixSize)
        {
            int totalRowCount = inputMatrix.Length;
            int totalColumnCount = inputMatrix[0].Length;

            int outputRowCount = totalRowCount - submatrixSize + 1;
            int outputColumnCount = totalColumnCount - submatrixSize + 1;

            int[][] minimumDifferenceMatrix = new int[outputRowCount][];

            for (int topRowIndex = 0; topRowIndex < outputRowCount; topRowIndex++)
            {
                minimumDifferenceMatrix[topRowIndex] = new int[outputColumnCount];

                for (int leftColumnIndex = 0; leftColumnIndex < outputColumnCount; leftColumnIndex++)
                {
                    HashSet<int> uniqueValuesInSubmatrix = new HashSet<int>();

                    for (int currentRow = topRowIndex; currentRow < topRowIndex + submatrixSize; currentRow++)
                    {
                        for (int currentColumn = leftColumnIndex; currentColumn < leftColumnIndex + submatrixSize; currentColumn++)
                        {
                            uniqueValuesInSubmatrix.Add(inputMatrix[currentRow][currentColumn]);
                        }
                    }

                    if (uniqueValuesInSubmatrix.Count <= 1)
                    {
                        minimumDifferenceMatrix[topRowIndex][leftColumnIndex] = 0;
                        continue;
                    }

                    List<int> sortedUniqueValues = uniqueValuesInSubmatrix.ToList();
                    sortedUniqueValues.Sort();

                    int minimumAbsoluteDifference = int.MaxValue;

                    for (int index = 1; index < sortedUniqueValues.Count; index++)
                    {
                        int currentDifference = sortedUniqueValues[index] - sortedUniqueValues[index - 1];

                        if (currentDifference < minimumAbsoluteDifference)
                        {
                            minimumAbsoluteDifference = currentDifference;
                        }
                    }

                    minimumDifferenceMatrix[topRowIndex][leftColumnIndex] = minimumAbsoluteDifference;
                }
            }

            return minimumDifferenceMatrix;
        }
    }
}