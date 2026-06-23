namespace DailyQuestion
{
    public class NumberofZigZagArraysI
    {
        private const int MODULO = 1_000_000_007;

        public int ZigZagArrays(int targetArrayLength, int minimumValue, int maximumValue)
            
        {
            int availableValueCount = maximumValue - minimumValue + 1;

            long[] zigZagEndingWithIncrease = new long[availableValueCount];

            long[] zigZagEndingWithDecrease = new long[availableValueCount];

            for (int endingValueIndex = 0; endingValueIndex < availableValueCount; endingValueIndex++)
            {
                zigZagEndingWithIncrease[endingValueIndex] = endingValueIndex;

                zigZagEndingWithDecrease[endingValueIndex] = availableValueCount - endingValueIndex - 1;
            }

            for (int currentArrayLength = 3; currentArrayLength <= targetArrayLength; currentArrayLength++)
            {
                long[] nextIncreaseState = new long[availableValueCount];

                long[] nextDecreaseState = new long[availableValueCount];

                long[] prefixDecreaseCount = new long[availableValueCount + 1];

                for (int valueIndex = 0; valueIndex < availableValueCount; valueIndex++)
                {
                    prefixDecreaseCount[valueIndex + 1] = (prefixDecreaseCount[valueIndex] + zigZagEndingWithDecrease[valueIndex]) % MODULO;
                }

                long[] suffixIncreaseCount = new long[availableValueCount + 1];

                for (int valueIndex = availableValueCount - 1; valueIndex >= 0; valueIndex--)
                {
                    suffixIncreaseCount[valueIndex] = (suffixIncreaseCount[valueIndex + 1] + zigZagEndingWithIncrease[valueIndex]) % MODULO;
                }

                for (int candidateEndingValue = 0; candidateEndingValue < availableValueCount; candidateEndingValue++)
                {
                    nextIncreaseState[candidateEndingValue] = prefixDecreaseCount[candidateEndingValue];

                    nextDecreaseState[candidateEndingValue] = suffixIncreaseCount[candidateEndingValue + 1];
                }

                zigZagEndingWithIncrease = nextIncreaseState;

                zigZagEndingWithDecrease = nextDecreaseState;
            }

            long totalZigZagArrayCount = 0;

            for (int valueIndex = 0; valueIndex < availableValueCount; valueIndex++)
            {
                totalZigZagArrayCount = (totalZigZagArrayCount + zigZagEndingWithIncrease[valueIndex] + zigZagEndingWithDecrease[valueIndex])  % MODULO;
            }

            return (int)totalZigZagArrayCount;
        }
    }
}