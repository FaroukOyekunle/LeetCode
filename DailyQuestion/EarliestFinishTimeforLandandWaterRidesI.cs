namespace DailyQuestion
{
    public class EarliestFinishTimeforLandandWaterRidesI
    {
        public int EarliestFinishTime(int[] landTripStartTimes, int[] landTripDurations, int[] waterTripStartTimes, int[] waterTripDurations)
        {
            int numberOfLandTrips = landTripStartTimes.Length;
            int numberOfWaterTrips = waterTripStartTimes.Length;

            int earliestPossibleCompletionTime = int.MaxValue;

            for (int landTripIndex = 0; landTripIndex < numberOfLandTrips; landTripIndex++)
            {
                int landTripFinishTime = landTripStartTimes[landTripIndex] + landTripDurations[landTripIndex];

                for (int waterTripIndex = 0; waterTripIndex < numberOfWaterTrips; waterTripIndex++)
                {
                    int waterTripActualStartTime = Math.Max(waterTripStartTimes[waterTripIndex], landTripFinishTime);

                    int totalCompletionTime = waterTripActualStartTime + waterTripDurations[waterTripIndex];

                    earliestPossibleCompletionTime = Math.Min(earliestPossibleCompletionTime, totalCompletionTime);
                }
            }

            for (int waterTripIndex = 0; waterTripIndex < numberOfWaterTrips; waterTripIndex++)
            {
                int waterTripFinishTime = waterTripStartTimes[waterTripIndex] + waterTripDurations[waterTripIndex];

                for (int landTripIndex = 0; landTripIndex < numberOfLandTrips; landTripIndex++)
                {
                    int landTripActualStartTime = Math.Max(landTripStartTimes[landTripIndex], waterTripFinishTime);

                    int totalCompletionTime = landTripActualStartTime + landTripDurations[landTripIndex];

                    earliestPossibleCompletionTime =  Math.Min(earliestPossibleCompletionTime, totalCompletionTime);
                }
            }

            return earliestPossibleCompletionTime;
        }
    }
}