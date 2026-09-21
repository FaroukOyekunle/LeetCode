namespace DailyQuestion
{
    public class FindXValueofArrayI
    {
        public long[] ResultArray(int[] numbers, int divisor)
        {
            long[] subsequenceCountByProductRemainder = new long[divisor];

            long[] currentResultByProductRemainder = new long[divisor];

            foreach (int currentNumber in numbers)
            {
                int currentNumberRemainder = currentNumber % divisor;

                long[] currentProductRemainderCounts = new long[divisor];

                currentProductRemainderCounts[currentNumberRemainder]++;

                for (int previousProductRemainder = 0; previousProductRemainder < divisor; previousProductRemainder++)
                {
                    if (subsequenceCountByProductRemainder[previousProductRemainder] == 0)
                    {
                        continue;
                    }

                    int updatedProductRemainder = (previousProductRemainder * currentNumberRemainder) % divisor;

                    currentProductRemainderCounts[updatedProductRemainder] += subsequenceCountByProductRemainder[previousProductRemainder];
                }

                for (int productRemainder = 0; productRemainder < divisor; productRemainder++)
                {
                    currentResultByProductRemainder[productRemainder] += currentProductRemainderCounts[productRemainder];
                }

                subsequenceCountByProductRemainder = currentProductRemainderCounts;
            }

            return currentResultByProductRemainder;
        }
    }
}