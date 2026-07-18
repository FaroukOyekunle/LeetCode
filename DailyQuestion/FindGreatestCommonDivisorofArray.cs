namespace DailyQuestion
{
    public class FindGreatestCommonDivisorofArray
    {
        public int FindGCD(int[] numbers)
        {
            int minimumNumber = numbers[0];
            int maximumNumber = numbers[0];

            foreach (int currentNumber in numbers)
            {
                if (currentNumber < minimumNumber)
                {
                    minimumNumber = currentNumber;
                }

                if (currentNumber > maximumNumber)
                {
                    maximumNumber = currentNumber;
                }
            }

            while (maximumNumber != 0)
            {
                int divisionRemainder = minimumNumber % maximumNumber;

                minimumNumber = maximumNumber;
                maximumNumber = divisionRemainder;
            }

            return minimumNumber;
        }
    }
}