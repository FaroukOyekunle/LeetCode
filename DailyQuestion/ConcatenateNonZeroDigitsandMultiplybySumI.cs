namespace DailyQuestion
{
    public class ConcatenateNonZeroDigitsandMultiplybySumI
    {
        public long SumAndMultiply(int number)
        {
            long reversedNumberWithoutZeros = 0;

            int sumOfNonZeroDigits = 0;

            while (number > 0)
            {
                int currentDigit = number % 10;

                if (currentDigit != 0)
                {
                    reversedNumberWithoutZeros = (reversedNumberWithoutZeros * 10) + currentDigit;

                    sumOfNonZeroDigits += currentDigit;
                }

                number /= 10;
            }

            long reconstructedNumberWithoutZeros = 0;

            while (reversedNumberWithoutZeros > 0)
            {
                int currentDigit = (int)(reversedNumberWithoutZeros % 10);

                reconstructedNumberWithoutZeros = (reconstructedNumberWithoutZeros * 10) + currentDigit;

                reversedNumberWithoutZeros /= 10;
            }

            return reconstructedNumberWithoutZeros * sumOfNonZeroDigits;
        }
    }
}