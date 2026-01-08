namespace DailyQuestion
{
    public class MaxDotProductofTwoSubsequences
    {
        public int MaxDotProduct(int[] sequence1, int[] sequence2)
        {
            int length1 = sequence1.Length;
            int length2 = sequence2.Length;

            int[,] maxDotProductDP = new int[length1 + 1, length2 + 1];
            int NEGATIVE_INFINITY = int.MinValue / 2;

            for(int rowIndex = 0; rowIndex <= length1; rowIndex++)
            {
                for(int columnIndex = 0; columnIndex <= length2; columnIndex++)
                {
                    maxDotProductDP[rowIndex, columnIndex] = NEGATIVE_INFINITY;
                }
            }

            for(int rowIndex = 1; rowIndex <= length1; rowIndex++)
            {
                for(int columnIndex = 1; columnIndex <= length2; columnIndex++)
                {
                    int currentProduct = sequence1[rowIndex - 1] * sequence2[columnIndex - 1];

                    maxDotProductDP[rowIndex, columnIndex] = Math.Max(
                        currentProduct,
                        Math.Max(
                            currentProduct + maxDotProductDP[rowIndex - 1, columnIndex - 1],
                            Math.Max(maxDotProductDP[rowIndex - 1, columnIndex], maxDotProductDP[rowIndex, columnIndex - 1])
                        )
                    );
                }
            }

            return maxDotProductDP[length1, length2];
        }
    }
}