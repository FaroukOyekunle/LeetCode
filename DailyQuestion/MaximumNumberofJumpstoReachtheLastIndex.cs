namespace DailyQuestion
{
    public class MaximumNumberofJumpstoReachtheLastIndex
    {
        public int MaximumJumps(int[] numbers, int maximumAllowedDifference)
        {
            int totalNumbers = numbers.Length;

            int[] maximumJumpCountToEachIndex = new int[totalNumbers];

            Array.Fill(maximumJumpCountToEachIndex, -1);

            maximumJumpCountToEachIndex[0] = 0;

            for (int currentPosition = 0; currentPosition < totalNumbers; currentPosition++)
            {
                if (maximumJumpCountToEachIndex[currentPosition] == -1)
                {
                    continue;
                }

                for (int destinationPosition = currentPosition + 1; destinationPosition < totalNumbers; destinationPosition++)
                {
                    long valueDifference = (long)numbers[destinationPosition] - numbers[currentPosition];

                    bool canJumpToDestination = valueDifference >= -maximumAllowedDifference && valueDifference <= maximumAllowedDifference;

                    if (canJumpToDestination)
                    {
                        maximumJumpCountToEachIndex[destinationPosition] = Math.Max(maximumJumpCountToEachIndex[destinationPosition], maximumJumpCountToEachIndex[currentPosition] + 1);
                    }
                }
            }

            return maximumJumpCountToEachIndex[totalNumbers - 1];
        }
    }
}