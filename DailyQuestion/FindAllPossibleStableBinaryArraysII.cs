namespace DailyQuestion
{
    public class FindAllPossibleStableBinaryArraysII
    {
        private const int MODULO = 1_000_000_007;

        public int CalculateNumberOfStableBinaryArrays(int totalZeroCount, int totalOneCount, int maxConsecutiveLimit)
        {
            long[,,] numberOfValidArrays = new long[totalZeroCount + 1, totalOneCount + 1, 2];

            for (int zerosUsed = 0; zerosUsed <= totalZeroCount; zerosUsed++)
            {
                numberOfValidArrays[zerosUsed, 0, 0] = (zerosUsed <= maxConsecutiveLimit) ? 1 : 0;
            }

            for (int onesUsed = 0; onesUsed <= totalOneCount; onesUsed++)
            {
                numberOfValidArrays[0, onesUsed, 1] = (onesUsed <= maxConsecutiveLimit) ? 1 : 0;
            }

            for (int zerosUsed = 1; zerosUsed <= totalZeroCount; zerosUsed++)
            {
                for (int onesUsed = 1; onesUsed <= totalOneCount; onesUsed++)
                {
                    numberOfValidArrays[zerosUsed, onesUsed, 0] = (numberOfValidArrays[zerosUsed - 1, onesUsed, 0] +
                         numberOfValidArrays[zerosUsed - 1, onesUsed, 1]) % MODULO;

                    numberOfValidArrays[zerosUsed, onesUsed, 1] = (numberOfValidArrays[zerosUsed, onesUsed - 1, 0] +
                         numberOfValidArrays[zerosUsed, onesUsed - 1, 1]) % MODULO;

                    if (zerosUsed - maxConsecutiveLimit - 1 >= 0)
                    {
                        numberOfValidArrays[zerosUsed, onesUsed, 0] = (numberOfValidArrays[zerosUsed, onesUsed, 0]
                             - numberOfValidArrays[zerosUsed - maxConsecutiveLimit - 1, onesUsed, 1] + MODULO) % MODULO;
                    }

                    if (onesUsed - maxConsecutiveLimit - 1 >= 0)
                    {
                        numberOfValidArrays[zerosUsed, onesUsed, 1] = (numberOfValidArrays[zerosUsed, onesUsed, 1]
                             - numberOfValidArrays[zerosUsed, onesUsed - maxConsecutiveLimit - 1, 0] + MODULO) % MODULO;
                    }
                }
            }

            return (int)((numberOfValidArrays[totalZeroCount, totalOneCount, 0] + numberOfValidArrays[totalZeroCount, totalOneCount, 1]) % MODULO);
        }
    }
}