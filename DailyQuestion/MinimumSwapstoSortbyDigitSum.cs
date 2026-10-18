namespace DailyQuestion
{
    public class MinimumSwapstoSortbyDigitSum
    {
        public int MinSwaps(int[] numbers)
        {
            int totalNumberOfElements = numbers.Length;

            (int Value, int OriginalIndex)[] numbersWithOriginalIndices = new (int Value, int OriginalIndex)[totalNumberOfElements];

            for (int originalPositionIndex = 0; originalPositionIndex < totalNumberOfElements; originalPositionIndex++)
            {
                numbersWithOriginalIndices[originalPositionIndex] = (numbers[originalPositionIndex], originalPositionIndex);
            }

            Array.Sort(numbersWithOriginalIndices, (firstNumber, secondNumber) =>
            {
                int firstNumberDigitSum = GetDigitSum(firstNumber.Value);
                int secondNumberDigitSum = GetDigitSum(secondNumber.Value);

                int digitSumComparisonResult =
                    firstNumberDigitSum.CompareTo(secondNumberDigitSum);

                if (digitSumComparisonResult != 0)
                {
                    return digitSumComparisonResult;
                }

                return firstNumber.Value.CompareTo(secondNumber.Value);
            });

            bool[] visitedSortedPositions = new bool[totalNumberOfElements];
            int minimumRequiredSwaps = 0;

            for (int targetSortedPositionIndex = 0; targetSortedPositionIndex < totalNumberOfElements; targetSortedPositionIndex++)
            {
                if (visitedSortedPositions[targetSortedPositionIndex] || numbersWithOriginalIndices[targetSortedPositionIndex].OriginalIndex  == targetSortedPositionIndex)
                {
                    continue;
                }

                int currentCyclePositionIndex = targetSortedPositionIndex;
                int currentPermutationCycleLength = 0;

                while (!visitedSortedPositions[currentCyclePositionIndex])
                {
                    visitedSortedPositions[currentCyclePositionIndex] = true;

                    currentCyclePositionIndex = numbersWithOriginalIndices[currentCyclePositionIndex].OriginalIndex;

                    currentPermutationCycleLength++;
                }

                minimumRequiredSwaps += currentPermutationCycleLength - 1;
            }

            return minimumRequiredSwaps;
        }

        private int GetDigitSum(int number)
        {
            int sumOfDigits = 0;

            while (number > 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }

            return sumOfDigits;
        }
    }
}