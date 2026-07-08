namespace DailyQuestion
{
    public class ConcatenateNonZeroDigitsandMultiplybySumII
    {
        public class Solution
        {
            private const int Modulus = 1_000_000_007;

            public int[] SumAndMultiply(string digitString, int[][] queries)
            {
                List<int> nonZeroDigitPositions = new();
                List<int> nonZeroDigits = new();

                for (int characterIndex = 0; characterIndex < digitString.Length; characterIndex++)
                {
                    if (digitString[characterIndex] != '0')
                    {
                        nonZeroDigitPositions.Add(characterIndex);
                        nonZeroDigits.Add(digitString[characterIndex] - '0');
                    }
                }

                int nonZeroDigitCount = nonZeroDigits.Count;

                long[] powersOfTen = new long[nonZeroDigitCount + 1];
                long[] prefixDigitSums = new long[nonZeroDigitCount + 1];
                long[] prefixNumericValues = new long[nonZeroDigitCount + 1];

                powersOfTen[0] = 1;

                for (int digitIndex = 0; digitIndex < nonZeroDigitCount; digitIndex++)
                {
                    powersOfTen[digitIndex + 1] = (powersOfTen[digitIndex] * 10) % Modulus;

                    prefixDigitSums[digitIndex + 1] = prefixDigitSums[digitIndex] + nonZeroDigits[digitIndex];

                    prefixNumericValues[digitIndex + 1] = (prefixNumericValues[digitIndex] * 10 + nonZeroDigits[digitIndex]) % Modulus;
                }

                int[] queryResults = new int[queries.Length];

                for (int queryIndex = 0; queryIndex < queries.Length; queryIndex++)
                {
                    int leftBoundary = queries[queryIndex][0];
                    int rightBoundary = queries[queryIndex][1];

                    int firstNonZeroDigitIndex = FindFirstPositionGreaterThanOrEqualTo(nonZeroDigitPositions, leftBoundary);

                    int lastNonZeroDigitIndex = FindFirstPositionGreaterThan(nonZeroDigitPositions, rightBoundary) - 1;

                    if (firstNonZeroDigitIndex > lastNonZeroDigitIndex)
                    {
                        queryResults[queryIndex] = 0;
                        continue;
                    }

                    long digitSum = prefixDigitSums[lastNonZeroDigitIndex + 1] - prefixDigitSums[firstNonZeroDigitIndex];

                    int extractedDigitCount = lastNonZeroDigitIndex - firstNonZeroDigitIndex + 1;

                    long extractedNumber = prefixNumericValues[lastNonZeroDigitIndex + 1] - (prefixNumericValues[firstNonZeroDigitIndex] * powersOfTen[extractedDigitCount]) % Modulus;

                    if (extractedNumber < 0)
                    {
                        extractedNumber += Modulus;
                    }

                    queryResults[queryIndex] = (int)((extractedNumber * (digitSum % Modulus)) % Modulus);
                }

                return queryResults;
            }

            private int FindFirstPositionGreaterThanOrEqualTo(List<int> sortedPositions, int targetPosition)
            {
                int leftBoundary = 0;
                int rightBoundary = sortedPositions.Count;

                while (leftBoundary < rightBoundary)
                {
                    int middleIndex = leftBoundary + (rightBoundary - leftBoundary) / 2;

                    if (sortedPositions[middleIndex] < targetPosition)
                    {
                        leftBoundary = middleIndex + 1;
                    }
                    else
                    {
                        rightBoundary = middleIndex;
                    }
                }

                return leftBoundary;
            }

            private int FindFirstPositionGreaterThan(List<int> sortedPositions, int targetPosition)
            {
                int leftBoundary = 0;
                int rightBoundary = sortedPositions.Count;

                while (leftBoundary < rightBoundary)
                {
                    int middleIndex = leftBoundary + (rightBoundary - leftBoundary) / 2;

                    if (sortedPositions[middleIndex] <= targetPosition)
                    {
                        leftBoundary = middleIndex + 1;
                    }
                    else
                    {
                        rightBoundary = middleIndex;
                    }
                }

                return leftBoundary;
            }
        }
    }
}