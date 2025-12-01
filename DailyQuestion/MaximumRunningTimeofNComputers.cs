namespace DailyQuestion
{
    public class MaximumRunningTimeofNComputers
    {
        public long CalculateMaxRunTime(int computerCount, int[] batteryCapacities)
        {
            long totalBatteryCapacity = 0;
            foreach(var batteryCapacity in batteryCapacities)
            {
                totalBatteryCapacity += batteryCapacity;
            }

            long minRunTime = 0, maxRunTime = totalBatteryCapacity / computerCount;

            while(minRunTime < maxRunTime)
            {
                long candidateRunTime = (minRunTime + maxRunTime + 1) / 2;

                long totalAvailablePower = 0;
                foreach(var batteryCapacity in batteryCapacities)
                {
                    totalAvailablePower += Math.Min(batteryCapacity, candidateRunTime);
                }

                if(totalAvailablePower >= candidateRunTime * computerCount)
                {
                    minRunTime = candidateRunTime;
                }
                
                else
                {
                    maxRunTime = candidateRunTime - 1;
                }
            }

            return minRunTime;
        }
    }
}