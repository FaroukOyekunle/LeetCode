namespace DailyQuestion
{
    public class MaximizetheMinimumPoweredCity
    {
        public long MaximizePowerDistribution(int[] powerStations, int radius, int additionalPower)
        {
            int cityCount = powerStations.Length;

            long[] prefixSum = new long[cityCount + 1];
            for (int cityIndex = 0; cityIndex < cityCount; cityIndex++)
            {
                prefixSum[cityIndex + 1] = prefixSum[cityIndex] + powerStations[cityIndex];
            }

            long[] totalCityPower = new long[cityCount];
            for (int cityIndex = 0; cityIndex < cityCount; cityIndex++)
            {
                int leftBound = Math.Max(0, cityIndex - radius);
                int rightBound = Math.Min(cityCount - 1, cityIndex + radius);
                totalCityPower[cityIndex] = prefixSum[rightBound + 1] - prefixSum[leftBound];
            }

            long minPossiblePower = 0;
            long maxPossiblePower = prefixSum[cityCount] + additionalPower;
            long maxMinPower = 0;

            while (minPossiblePower <= maxPossiblePower)
            {
                long targetPower = minPossiblePower + (maxPossiblePower - minPossiblePower) / 2;
                if (CanAchieveTargetPower(targetPower, totalCityPower, radius, additionalPower))
                {
                    maxMinPower = targetPower;
                    minPossiblePower = targetPower + 1;
                }
                else
                {
                    maxPossiblePower = targetPower - 1;
                }
            }

            return maxMinPower;
        }

        private bool CanAchieveTargetPower(long targetPower, long[] cityPowers, int radius, long remainingPower)
        {
            int cityCount = cityPowers.Length;
            long[] powerAdjustments = new long[cityCount + 1];
            long currentAddedPower = 0;

            for (int cityIndex = 0; cityIndex < cityCount; cityIndex++)
            {
                currentAddedPower += powerAdjustments[cityIndex];
                long totalPowerAtCity = cityPowers[cityIndex] + currentAddedPower;
                if (totalPowerAtCity < targetPower)
                {
                    long powerNeeded = targetPower - totalPowerAtCity;
                    if (powerNeeded > remainingPower) return false;
                    remainingPower -= powerNeeded;

                    int optimalStation = Math.Min(cityCount - 1, cityIndex + radius);
                    int affectedLeftCity = Math.Max(0, optimalStation - radius);
                    int affectedRightCity = Math.Min(cityCount - 1, optimalStation + radius);

                    powerAdjustments[affectedLeftCity] += powerNeeded;
                    powerAdjustments[affectedRightCity + 1] -= powerNeeded;
                    currentAddedPower += powerNeeded;
                }
            }
            return true;
        }
    }
}