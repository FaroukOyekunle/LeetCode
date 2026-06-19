namespace DailyQuestion
{
    public class FindtheHighestAltitude
    {
        public int LargestAltitude(int[] altitudeGainPerSegment)
        {
            int currentAccumulatedAltitude = 0;

            int maximumAltitudeReached = 0;

            foreach (int altitudeChangeForCurrentSegment in altitudeGainPerSegment)
            {
                currentAccumulatedAltitude += altitudeChangeForCurrentSegment;

                if (currentAccumulatedAltitude > maximumAltitudeReached)
                {
                    maximumAltitudeReached = currentAccumulatedAltitude;
                }
            }

            return maximumAltitudeReached;
        }
    }
}