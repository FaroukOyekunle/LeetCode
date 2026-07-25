namespace DailyQuestion
{
    public class MaximumProductofTwoDigits
    {
        public int MaxProduct(int number)
        {
            int largestDigit = 0;
            int secondLargestDigit = 0;

            while (number > 0)
            {
                int currentDigit = number % 10;

                if (currentDigit >= largestDigit)
                {
                    secondLargestDigit = largestDigit;
                    largestDigit = currentDigit;
                }
                else if (currentDigit > secondLargestDigit)
                {
                    secondLargestDigit = currentDigit;
                }

                number /= 10;
            }

            return largestDigit * secondLargestDigit;
        }
    }
}