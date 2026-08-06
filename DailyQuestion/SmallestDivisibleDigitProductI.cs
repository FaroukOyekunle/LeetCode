namespace DailyQuestion
{
    public class SmallestDivisibleDigitProductI
    {
        public int SmallestNumber(int startingNumber, int requiredDivisor)
        {
            int candidateNumber = startingNumber;

            while (true)
            {
                int candidateDigitProduct = CalculateDigitProduct(candidateNumber);

                if (candidateDigitProduct % requiredDivisor == 0)
                {
                    return candidateNumber;
                }

                candidateNumber++;
            }
        }

        private int CalculateDigitProduct(int inputNumber)
        {
            int productOfDigits = 1;

            while (inputNumber > 0)
            {
                int currentDigit = inputNumber % 10;

                productOfDigits *= currentDigit;

                inputNumber /= 10;
            }

            return productOfDigits;
        }
    }
}