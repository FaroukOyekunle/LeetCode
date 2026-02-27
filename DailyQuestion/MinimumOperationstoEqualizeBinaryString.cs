namespace DailyQuestion
{
    public class MinimumOperationstoEqualizeBinaryString
    {
        public int CalculateMinimumOperationsToEqualizeBinaryString(string binaryString, int targetLength)
        {
            int binaryStringLength = binaryString.Length;

            int zeroCount = 0;
            foreach (char character in binaryString)
            {
                if (character == '0')
                {
                    zeroCount++;
                }
            }

            int CalculateCeilingDivision(int numerator, int denominator)
            {
                return (numerator + denominator - 1) / denominator;
            }

            if (binaryStringLength == targetLength)
            {
                if (zeroCount == 0)
                {
                    return 0;
                }
                else if (zeroCount == binaryStringLength)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            int minimumOperations = int.MaxValue;

            if ((targetLength & 1) == (zeroCount & 1))
            {
                int operations = Math.Max(
                    CalculateCeilingDivision(zeroCount, targetLength),
                    CalculateCeilingDivision(binaryStringLength - zeroCount, binaryStringLength - targetLength)
                );

                if ((operations & 1) == 0) 
                {
                    operations++;
                }

                minimumOperations = Math.Min(minimumOperations, operations);
            }

            if ((zeroCount & 1) == 0)
            {
                int operations = Math.Max(
                    CalculateCeilingDivision(zeroCount, targetLength),
                    CalculateCeilingDivision(zeroCount, binaryStringLength - targetLength)
                );

                if ((operations & 1) == 1) 
                {
                    operations++;
                }

                minimumOperations = Math.Min(minimumOperations, operations);
            }

            return minimumOperations == int.MaxValue ? -1 : minimumOperations;
        }
    }
}