namespace DailyQuestion
{
    public class StoneGame
    {
        public bool StoneGame(int[] stonePiles)
        {
            int totalNumberOfPiles = stonePiles.Length;

            int?[,] maximumStoneDifferenceMemoization = new int?[totalNumberOfPiles, totalNumberOfPiles];

            return CalculateMaximumStoneDifference(stonePiles, 0, totalNumberOfPiles - 1, maximumStoneDifferenceMemoization) > 0;
        }

        private int CalculateMaximumStoneDifference(int[] stonePiles, int leftmostAvailablePileIndex, int rightmostAvailablePileIndex, int?[,] maximumStoneDifferenceMemoization)
        {
            if (leftmostAvailablePileIndex == rightmostAvailablePileIndex)
            {
                return stonePiles[leftmostAvailablePileIndex];
            }

            if (maximumStoneDifferenceMemoization[leftmostAvailablePileIndex, rightmostAvailablePileIndex].HasValue)
            {
                return maximumStoneDifferenceMemoization[leftmostAvailablePileIndex, rightmostAvailablePileIndex].Value;
            }

            int stoneDifferenceAfterTakingLeftmostPile = stonePiles[leftmostAvailablePileIndex] -
                CalculateMaximumStoneDifference(stonePiles, leftmostAvailablePileIndex + 1, rightmostAvailablePileIndex, maximumStoneDifferenceMemoization);

            int stoneDifferenceAfterTakingRightmostPile = stonePiles[rightmostAvailablePileIndex] -
                CalculateMaximumStoneDifference(stonePiles, leftmostAvailablePileIndex, rightmostAvailablePileIndex - 1, maximumStoneDifferenceMemoization);

            int maximumAchievableStoneDifference = Math.Max(stoneDifferenceAfterTakingLeftmostPile, stoneDifferenceAfterTakingRightmostPile);

            maximumStoneDifferenceMemoization[leftmostAvailablePileIndex, rightmostAvailablePileIndex] = maximumAchievableStoneDifference;

            return maximumAchievableStoneDifference;
        }
    }
}