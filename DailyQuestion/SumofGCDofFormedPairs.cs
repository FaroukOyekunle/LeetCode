namespace DailyQuestion
{
    public class SumofGCDofFormedPairs
    {
        public long GcdSum(int[] numbers)
        {
            int numberCount = numbers.Length;

            int[] prefixGreatestCommonDivisors = new int[numberCount];

            int maximumValueSeenSoFar = 0;

            for (int currentIndex = 0; currentIndex < numberCount; currentIndex++)
            {
                maximumValueSeenSoFar = Math.Max(maximumValueSeenSoFar, numbers[currentIndex]);

                prefixGreatestCommonDivisors[currentIndex] = GreatestCommonDivisor(numbers[currentIndex], maximumValueSeenSoFar);
            }

            Array.Sort(prefixGreatestCommonDivisors);

            long totalGreatestCommonDivisorSum = 0;

            int leftPointer = 0;
            int rightPointer = numberCount - 1;

            while (leftPointer < rightPointer)
            {
                totalGreatestCommonDivisorSum += GreatestCommonDivisor(prefixGreatestCommonDivisors[leftPointer], prefixGreatestCommonDivisors[rightPointer]);

                leftPointer++;
                rightPointer--;
            }

            return totalGreatestCommonDivisorSum;
        }

        private int GreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                int divisionRemainder = firstNumber % secondNumber;

                firstNumber = secondNumber;
                secondNumber = divisionRemainder;
            }

            return firstNumber;
        }
    }
}