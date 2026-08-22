namespace DailyQuestion
{
    public class CheckDivisibilitybyDigitSumandProduct
    {
        public bool CheckDivisibility(int number)
        {
            int originalNumber = number;
            int sumOfDigits = 0;
            int productOfDigits = 1;

            while (number > 0)
            {
                int currentDigit = number % 10;

                sumOfDigits += currentDigit;
                productOfDigits *= currentDigit;

                number /= 10;
            }

            int divisibilityFactor = sumOfDigits + productOfDigits;

            return originalNumber % divisibilityFactor == 0;
        }
    }
}