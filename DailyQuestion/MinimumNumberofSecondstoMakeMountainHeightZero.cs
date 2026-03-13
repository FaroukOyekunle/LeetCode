namespace DailyQuestion
{
    public class MinimumNumberofSecondstoMakeMountainHeightZero
    {
        public long FindMinimumSecondsToReduceMountain(int initialMountainHeight, int[] workerDurations)
        {
            long minimumPossibleTime = 1;
            long maximumPossibleTime = (long)1e18;

            long bestMinimumTime = maximumPossibleTime;

            while (minimumPossibleTime <= maximumPossibleTime)
            {
                long candidateTime = minimumPossibleTime + (maximumPossibleTime - minimumPossibleTime) / 2;

                if (CanWorkersReduceMountainWithinTime(initialMountainHeight, workerDurations, candidateTime))
                {
                    bestMinimumTime = candidateTime;
                    maximumPossibleTime = candidateTime - 1;
                }
                else
                {
                    minimumPossibleTime = candidateTime + 1;
                }
            }

            return bestMinimumTime;
        }

        private bool CanWorkersReduceMountainWithinTime(int targetMountainHeight, int[] workerDurations, long allowedTime)
        {
            long totalHeightReducedByWorkers = 0;

            foreach (int secondsPerUnitWork in workerDurations)
            {
                long maximumHeightUnitsThisWorkerCanReduce = (long)((Math.Sqrt(1 + (8.0 * allowedTime / secondsPerUnitWork)) - 1) / 2);

                totalHeightReducedByWorkers += maximumHeightUnitsThisWorkerCanReduce;

                if (totalHeightReducedByWorkers >= targetMountainHeight)
                {
                    return true;
                }
            }

            return totalHeightReducedByWorkers >= targetMountainHeight;
        }

    }
}