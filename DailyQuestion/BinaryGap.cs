namespace DailyQuestion
{
    public class BinaryGap
    {
        public int CalculateMaximumBinaryGap(int inputNumber)
        {
            int maximumGapDistance = 0;
            int previousSetBitPosition = -1;
            int currentBitPosition = 0;

            while (inputNumber > 0)
            {
                if ((inputNumber & 1) == 1)
                {
                    if (previousSetBitPosition != -1)
                    {
                        int gapDistance = currentBitPosition - previousSetBitPosition;
                        maximumGapDistance = Math.Max(maximumGapDistance, gapDistance);
                    }

                    previousSetBitPosition = currentBitPosition;
                }

                inputNumber >>= 1;
                currentBitPosition++;
            }

            return maximumGapDistance;
        }
    }
}