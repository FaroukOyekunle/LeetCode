namespace DailyQuestion
{
    public class StoneGameIII
    {
        public string StoneGameIII(int[] stoneValues)
        {
            int totalStoneCount = stoneValues.Length;

            int[] maximumScoreDifferenceStartingAt = new int[totalStoneCount + 1];

            for (int startingStoneIndex = totalStoneCount - 1; startingStoneIndex >= 0; startingStoneIndex--)
            {
                maximumScoreDifferenceStartingAt[startingStoneIndex] = int.MinValue;

                int totalValueOfTakenStones = 0;

                for (int numberOfStonesTaken = 1; numberOfStonesTaken <= 3 && startingStoneIndex + numberOfStonesTaken <= totalStoneCount; numberOfStonesTaken++)
                {
                    totalValueOfTakenStones += stoneValues[startingStoneIndex + numberOfStonesTaken - 1];

                    int scoreDifferenceAfterCurrentMove = totalValueOfTakenStones - maximumScoreDifferenceStartingAt[startingStoneIndex + numberOfStonesTaken];

                    maximumScoreDifferenceStartingAt[startingStoneIndex] = Math.Max(maximumScoreDifferenceStartingAt[startingStoneIndex], scoreDifferenceAfterCurrentMove);
                }
            }

            int finalScoreDifference = maximumScoreDifferenceStartingAt[0];

            if (finalScoreDifference > 0)
            {
                return "Alice";
            }

            if (finalScoreDifference < 0)
            {
                return "Bob";
            }

            return "Tie";
        }
    }
}