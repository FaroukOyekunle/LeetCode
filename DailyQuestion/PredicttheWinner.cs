namespace DailyQuestion
{
    public class PredicttheWinner
    {
        public bool PredictTheWinner(int[] playerScores)
        {
            int totalNumbers = playerScores.Length;

            int?[,] maximumScoreDifferenceMemoization = new int?[totalNumbers, totalNumbers];

            return GetMaximumScoreDifference(playerScores, 0, totalNumbers - 1, maximumScoreDifferenceMemoization) >= 0;
        }

        private int GetMaximumScoreDifference(int[] playerScores, int leftmostAvailableIndex, int rightmostAvailableIndex, int?[,] maximumScoreDifferenceMemoization)
        {
            if (leftmostAvailableIndex == rightmostAvailableIndex)
            {
                return playerScores[leftmostAvailableIndex];
            }

            if (maximumScoreDifferenceMemoization[leftmostAvailableIndex, rightmostAvailableIndex].HasValue)
            {
                return maximumScoreDifferenceMemoization[leftmostAvailableIndex, rightmostAvailableIndex].Value;
            }

            int scoreDifferenceAfterChoosingLeftNumber = playerScores[leftmostAvailableIndex] - GetMaximumScoreDifference(playerScores, leftmostAvailableIndex + 1, rightmostAvailableIndex, maximumScoreDifferenceMemoization);

            int scoreDifferenceAfterChoosingRightNumber = playerScores[rightmostAvailableIndex] - GetMaximumScoreDifference(playerScores, leftmostAvailableIndex, rightmostAvailableIndex - 1, maximumScoreDifferenceMemoization);

            maximumScoreDifferenceMemoization[leftmostAvailableIndex, rightmostAvailableIndex] = Math.Max(scoreDifferenceAfterChoosingLeftNumber, scoreDifferenceAfterChoosingRightNumber);

            return maximumScoreDifferenceMemoization[leftmostAvailableIndex, rightmostAvailableIndex].Value;
        }
    }
}