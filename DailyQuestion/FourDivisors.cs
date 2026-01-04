namespace DailyQuestion
{
    public class FourDivisors
    {
        public int SumFourDivisors(int[] numbers)
        {
            int totalSum = 0;

            foreach (int currentNumber in numbers)
            {
                int divisorSum = 0;
                int divisorCount = 0;

                for (int divisor = 1; divisor * divisor <= currentNumber; divisor++)
                {
                    if (currentNumber % divisor == 0)
                    {
                        int pairedDivisor = currentNumber / divisor;

                        if (divisor == pairedDivisor)
                        {
                            divisorCount += 1;
                            divisorSum += divisor;
                        }
                        else
                        {
                            divisorCount += 2;
                            divisorSum += divisor + pairedDivisor;
                        }

                        if (divisorCount > 4)
                        {
                            break;
                        }
                    }
                }

                if (divisorCount == 4)
                {
                    totalSum += divisorSum;
                }
            }

            return totalSum;
        }

    }
}