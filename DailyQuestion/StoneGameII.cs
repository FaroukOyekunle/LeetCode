namespace DailyQuestion
{
    public class StoneGameII
    {
        public int StoneGameII(int[] piles)
        {
            int totalPileCount = piles.Length;

            int[] suffixStoneTotals = new int[totalPileCount + 1];

            for (int currentPileIndex = totalPileCount - 1; currentPileIndex >= 0; currentPileIndex--)
            {
                suffixStoneTotals[currentPileIndex] = suffixStoneTotals[currentPileIndex + 1] + piles[currentPileIndex];
            }

            int[,] maximumStonesCurrentPlayerCanCollect = new int[totalPileCount, totalPileCount + 1];

            for (int currentPileIndex = totalPileCount - 1; currentPileIndex >= 0; currentPileIndex--)
            {
                for (int maximumPilesAllowedToTake = 1; maximumPilesAllowedToTake <= totalPileCount; maximumPilesAllowedToTake++)
                {
                    if (currentPileIndex + (2 * maximumPilesAllowedToTake) >= totalPileCount)
                    {
                        maximumStonesCurrentPlayerCanCollect[currentPileIndex, maximumPilesAllowedToTake] = suffixStoneTotals[currentPileIndex];

                        continue;
                    }

                    int maximumStonesForCurrentPlayer = 0;

                    for (int pilesTakenThisTurn = 1; pilesTakenThisTurn <= 2 * maximumPilesAllowedToTake && currentPileIndex + pilesTakenThisTurn <= totalPileCount; pilesTakenThisTurn++)
                    {
                        int stonesCollectedThisTurn = suffixStoneTotals[currentPileIndex] - suffixStoneTotals[currentPileIndex + pilesTakenThisTurn];

                        int maximumPilesOpponentCanTakeNext = Math.Max(maximumPilesAllowedToTake, pilesTakenThisTurn);

                        int stonesOpponentCanCollect = maximumStonesCurrentPlayerCanCollect[currentPileIndex + pilesTakenThisTurn, maximumPilesOpponentCanTakeNext];

                        int stonesRemainingAfterCurrentTurn = suffixStoneTotals[currentPileIndex] - stonesCollectedThisTurn;

                        int stonesCurrentPlayerCanEventuallyCollect = stonesCollectedThisTurn + (stonesRemainingAfterCurrentTurn - stonesOpponentCanCollect);

                        maximumStonesForCurrentPlayer = Math.Max(maximumStonesForCurrentPlayer, stonesCurrentPlayerCanEventuallyCollect);
                    }

                    maximumStonesCurrentPlayerCanCollect[currentPileIndex, maximumPilesAllowedToTake] = maximumStonesForCurrentPlayer;
                }
            }

            return maximumStonesCurrentPlayerCanCollect[0, 1];
        }
    }
}