namespace DailyQuestion
{
    public class MinimumMovestoMakeArrayComplementary
    {
        public int MinMoves(int[] numbers, int maximumValue)
        {
            int totalNumbers = numbers.Length;

            int[] moveDifferenceArray = new int[(2 * maximumValue) + 2];

            for (int pairIndex = 0; pairIndex < totalNumbers / 2; pairIndex++)
            {
                int leftPairValue = numbers[pairIndex];

                int rightPairValue = numbers[totalNumbers - 1 - pairIndex];

                int smallerPairValue = Math.Min(leftPairValue, rightPairValue);

                int largerPairValue = Math.Max(leftPairValue, rightPairValue);

                int currentPairSum = leftPairValue + rightPairValue;

                int oneMovePossibleRangeStart = smallerPairValue + 1;

                int oneMovePossibleRangeEnd = largerPairValue + maximumValue;

                moveDifferenceArray[2] += 2;

                moveDifferenceArray[oneMovePossibleRangeStart] -= 1;

                moveDifferenceArray[oneMovePossibleRangeEnd + 1] += 1;

                moveDifferenceArray[currentPairSum] -= 1;

                moveDifferenceArray[currentPairSum + 1] += 1;
            }

            int minimumMovesRequired = int.MaxValue;

            int currentMovesRequired = 0;

            for (int targetPairSum = 2; targetPairSum <= 2 * maximumValue; targetPairSum++)
            {
                currentMovesRequired += moveDifferenceArray[targetPairSum];

                minimumMovesRequired = Math.Min( minimumMovesRequired, currentMovesRequired);
            }

            return minimumMovesRequired;
        }
    }
}