namespace DailyQuestion
{
    public class MinimumAbsoluteDistanceBetweenMirrorPairs
    {
        public int FindMinimumMirrorPairDistance(int[] numbers)
        {
            var reversedValueToLastSeenIndex = new Dictionary<int, int>();

            int minimumDistanceBetweenMirrorPairs = int.MaxValue;

            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                int currentNumber = numbers[currentIndex];

                if (reversedValueToLastSeenIndex.TryGetValue(currentNumber, out int previousIndex))
                {
                    int distanceBetweenPairs = currentIndex - previousIndex;

                    minimumDistanceBetweenMirrorPairs = Math.Min( minimumDistanceBetweenMirrorPairs, distanceBetweenPairs);
                }

                int reversedNumber = ReverseDigits(currentNumber);

                reversedValueToLastSeenIndex[reversedNumber] = currentIndex;
            }

            return minimumDistanceBetweenMirrorPairs == int.MaxValue ? -1 : minimumDistanceBetweenMirrorPairs;
        }

        private int ReverseDigits(int originalNumber)
        {
            int reversedNumber = 0;

            while (originalNumber > 0)
            {
                int lastDigit = originalNumber % 10;

                reversedNumber = reversedNumber * 10 + lastDigit;

                originalNumber /= 10;
            }

            return reversedNumber;
        }
    }
}