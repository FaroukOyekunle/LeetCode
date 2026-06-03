namespace DailyQuestion
{
    public class EarliestFinishTimeforLandandWaterRidesII
    {
        public int EarliestFinishTime(int[] landRideStartTimes, int[] landRideDurations, int[] waterRideStartTimes, int[] waterRideDurations)
        {
            long earliestOverallFinishTime = long.MaxValue;

            earliestOverallFinishTime = Math.Min(earliestOverallFinishTime, CalculateEarliestTwoRideFinishTime(landRideStartTimes, landRideDurations, waterRideStartTimes, waterRideDurations));

            earliestOverallFinishTime = Math.Min(earliestOverallFinishTime, CalculateEarliestTwoRideFinishTime(waterRideStartTimes, waterRideDurations, landRideStartTimes, landRideDurations));

            return (int)earliestOverallFinishTime;
        }

        private long CalculateEarliestTwoRideFinishTime(int[] firstRideStartTimes, int[] firstRideDurations, int[] secondRideStartTimes, int[] secondRideDurations)
        {
            int totalSecondRides = secondRideStartTimes.Length;

            var sortedSecondRideDetails = new (int StartTime, int Duration)[totalSecondRides];

            for (int secondRideIndex = 0; secondRideIndex < totalSecondRides; secondRideIndex++)
            {
                sortedSecondRideDetails[secondRideIndex] =
                (
                    secondRideStartTimes[secondRideIndex],
                    secondRideDurations[secondRideIndex]
                );
            }

            Array.Sort(sortedSecondRideDetails, (leftRide, rightRide) => leftRide.StartTime.CompareTo(rightRide.StartTime));

            int[] sortedSecondRideStartTimes = new int[totalSecondRides];

            long[] minimumDurationUpToIndex = new long[totalSecondRides];

            long[] minimumStartPlusDurationFromIndex = new long[totalSecondRides];

            for (int secondRideIndex = 0; secondRideIndex < totalSecondRides; secondRideIndex++)
            {
                sortedSecondRideStartTimes[secondRideIndex] = sortedSecondRideDetails[secondRideIndex].StartTime;
            }

            minimumDurationUpToIndex[0] = sortedSecondRideDetails[0].Duration;

            for (int secondRideIndex = 1; secondRideIndex < totalSecondRides; secondRideIndex++)
            {
                minimumDurationUpToIndex[secondRideIndex] = Math.Min(minimumDurationUpToIndex[secondRideIndex - 1], sortedSecondRideDetails[secondRideIndex].Duration);
            }

            minimumStartPlusDurationFromIndex[totalSecondRides - 1] = sortedSecondRideDetails[totalSecondRides - 1].StartTime + sortedSecondRideDetails[totalSecondRides - 1].Duration;

            for (int secondRideIndex = totalSecondRides - 2; secondRideIndex >= 0; secondRideIndex--)
            {
                minimumStartPlusDurationFromIndex[secondRideIndex] = Math.Min(minimumStartPlusDurationFromIndex[secondRideIndex + 1], sortedSecondRideDetails[secondRideIndex].StartTime +
                    sortedSecondRideDetails[secondRideIndex].Duration);
            }

            long earliestFinishTimeForRideOrder = long.MaxValue;

            for (int firstRideIndex = 0; firstRideIndex < firstRideStartTimes.Length; firstRideIndex++)
            {
                long firstRideCompletionTime = (long)firstRideStartTimes[firstRideIndex] + firstRideDurations[firstRideIndex];

                int firstEligibleSecondRideIndex = FindFirstStartTimeGreaterThanOrEqual(sortedSecondRideStartTimes, (int)firstRideCompletionTime);

                if (firstEligibleSecondRideIndex > 0)
                {
                    earliestFinishTimeForRideOrder = Math.Min(earliestFinishTimeForRideOrder, firstRideCompletionTime + minimumDurationUpToIndex[firstEligibleSecondRideIndex - 1]);
                }

                if (firstEligibleSecondRideIndex < totalSecondRides)
                {
                    earliestFinishTimeForRideOrder = Math.Min(earliestFinishTimeForRideOrder, minimumStartPlusDurationFromIndex[firstEligibleSecondRideIndex]);
                }
            }

            return earliestFinishTimeForRideOrder;
        }

        private int FindFirstStartTimeGreaterThanOrEqual(int[] sortedRideStartTimes, int targetStartTime)
        {
            int searchStartIndex = 0;
            int searchEndIndex = sortedRideStartTimes.Length;

            while (searchStartIndex < searchEndIndex)
            {
                int middleIndex = searchStartIndex + (searchEndIndex - searchStartIndex) / 2;

                if (sortedRideStartTimes[middleIndex] < targetStartTime)
                {
                    searchStartIndex = middleIndex + 1;
                }
                else
                {
                    searchEndIndex = middleIndex;
                }
            }

            return searchStartIndex;
        }
    }
}