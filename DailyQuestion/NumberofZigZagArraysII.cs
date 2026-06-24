namespace DailyQuestion
{
    public class NumberofZigZagArraysII
    {
        private const long MODULO = 1_000_000_007;

        public int ZigZagArrays(int targetArrayLength, int minimumAllowedValue, int maximumAllowedValue)
        {
            int availableValueCount = maximumAllowedValue - minimumAllowedValue + 1;

            if (targetArrayLength == 1)
            {
                return availableValueCount;
            }

            int totalStateCount = availableValueCount * 2;

            long[] initialLengthTwoState = BuildInitialLengthTwoState(availableValueCount);

            if (targetArrayLength == 2)
            {
                long totalZigZagArrays = 0;

                foreach (long stateCount in initialLengthTwoState)
                {
                    totalZigZagArrays = (totalZigZagArrays + stateCount) % MODULO;
                }

                return (int)totalZigZagArrays;
            }

            long[,] stateTransitionMatrix = BuildStateTransitionMatrix( availableValueCount);

            long[,] transitionMatrixPower = RaiseMatrixToPower(stateTransitionMatrix, targetArrayLength - 2);

            long[] finalStateCounts = MultiplyMatrixByVector(transitionMatrixPower, initialLengthTwoState);

            long totalZigZagArrayCount = 0;

            foreach (long stateCount in finalStateCounts)
            {
                totalZigZagArrayCount = (totalZigZagArrayCount + stateCount) % MODULO;
            }

            return (int)totalZigZagArrayCount;
        }

        private long[] BuildInitialLengthTwoState(int availableValueCount)
        {
            int totalStateCount = availableValueCount * 2;

            long[] initialStateCounts = new long[totalStateCount];

            for (int endingValueIndex = 0; endingValueIndex < availableValueCount; endingValueIndex++)
            {
                initialStateCounts[endingValueIndex] = endingValueIndex;

                initialStateCounts[availableValueCount + endingValueIndex] = availableValueCount - endingValueIndex - 1;
            }

            return initialStateCounts;
        }

        private long[,] BuildStateTransitionMatrix(int availableValueCount)
        {
            int totalStateCount = availableValueCount * 2;

            long[,] transitionMatrix = new long[totalStateCount, totalStateCount];

            for (int nextEndingValue = 0; nextEndingValue < availableValueCount; nextEndingValue++)
            {
                for (int previousEndingValue = 0; previousEndingValue < nextEndingValue; previousEndingValue++)
                {
                    transitionMatrix[nextEndingValue, availableValueCount + previousEndingValue] = 1;
                }

                for (int previousEndingValue = nextEndingValue + 1; previousEndingValue < availableValueCount; previousEndingValue++)
                {
                    transitionMatrix[availableValueCount + nextEndingValue, previousEndingValue] = 1;
                }
            }

            return transitionMatrix;
        }

        private long[,] RaiseMatrixToPower(long[,] matrixToExponentiate, long exponent)
        {
            int matrixDimension = matrixToExponentiate.GetLength(0);

            long[,] accumulatedResult = BuildIdentityMatrix(matrixDimension);

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                {
                    accumulatedResult = MultiplyMatrices(accumulatedResult, matrixToExponentiate);
                }

                matrixToExponentiate = MultiplyMatrices(matrixToExponentiate, matrixToExponentiate);

                exponent >>= 1;
            }

            return accumulatedResult;
        }

        private long[,] MultiplyMatrices(long[,] leftMatrix, long[,] rightMatrix)
        {
            int matrixDimension = leftMatrix.GetLength(0);

            long[,] multiplicationResult = new long[matrixDimension, matrixDimension];

            for (int rowIndex = 0; rowIndex < matrixDimension; rowIndex++)
            {
                for (int sharedDimensionIndex = 0; sharedDimensionIndex < matrixDimension; sharedDimensionIndex++)
                {
                    if (leftMatrix[rowIndex, sharedDimensionIndex] == 0)
                    {
                        continue;
                    }

                    for (int columnIndex = 0; columnIndex < matrixDimension; columnIndex++)
                    {
                        if (rightMatrix[sharedDimensionIndex, columnIndex] == 0)
                        {
                            continue;
                        }

                        multiplicationResult[rowIndex, columnIndex] = (multiplicationResult[rowIndex, columnIndex] + (leftMatrix[rowIndex, sharedDimensionIndex] * rightMatrix[sharedDimensionIndex, columnIndex]))  % MODULO;
                    }
                }
            }

            return multiplicationResult;
        }

        private long[] MultiplyMatrixByVector(long[,] matrix, long[] vector)
        {
            int vectorLength = vector.Length;

            long[] multiplicationResult = new long[vectorLength];

            for (int rowIndex = 0; rowIndex < vectorLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < vectorLength; columnIndex++)
                {
                    if (matrix[rowIndex, columnIndex] == 0)
                    {
                        continue;
                    }

                    multiplicationResult[rowIndex] = (multiplicationResult[rowIndex] + (matrix[rowIndex, columnIndex] * vector[columnIndex])) % MODULO;
                }
            }

            return multiplicationResult;
        }

        private long[,] BuildIdentityMatrix(int matrixDimension)
        {
            long[,] identityMatrix = new long[matrixDimension, matrixDimension];

            for (int diagonalIndex = 0; diagonalIndex < matrixDimension; diagonalIndex++)
            {
                identityMatrix[diagonalIndex, diagonalIndex] = 1;
            }

            return identityMatrix;
        }
    }
}