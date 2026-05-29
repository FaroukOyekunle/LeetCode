namespace DailyQuestion
{
    public class MinimumElementAfterReplacementWithDigitSum
    {
        public int MinimumDigitSum(int[] numbers)
        {
            int smallestDigitSum = int.MaxValue;

            foreach (int currentValue in numbers)
            {
                int remainingValue = currentValue;

                int currentDigitSum = 0;

                while (remainingValue > 0)
                {
                    int lastDigit = remainingValue % 10;

                    currentDigitSum += lastDigit;

                    remainingValue /= 10;
                }

                smallestDigitSum = Math.Min(smallestDigitSum, currentDigitSum);
            }

            return smallestDigitSum;
        }
    }
}