namespace DailyQuestion
{
    public class SmallestIndexWithDigitSumEqualToIndex
    {
        public int SmallestIndex(int[] numbers)
        {
            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                int currentNumber = numbers[currentIndex];
                int currentNumberDigitSum = 0;

                while (currentNumber > 0)
                {
                    int currentDigit = currentNumber % 10;

                    currentNumberDigitSum += currentDigit;
                    currentNumber /= 10;
                }

                if (currentNumberDigitSum == currentIndex)
                {
                    return currentIndex;
                }
            }

            return -1;
        }
    }
}