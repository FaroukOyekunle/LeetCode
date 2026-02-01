namespace DailyQuestion
{
    public class DivideanArrayIntoSubarraysWithMinimumCostI
    {
        public int CalculateMinimumCost(int[] inputNumbers)
        {
            int arrayLength = inputNumbers.Length;
            int minimumCost = int.MaxValue;

            for (int firstIndex = 1; firstIndex <= arrayLength - 2; firstIndex++)
            {
                for (int secondIndex = firstIndex + 1; secondIndex <= arrayLength - 1; secondIndex++)
                {
                    int currentCost = inputNumbers[0] + inputNumbers[firstIndex] + inputNumbers[secondIndex];
                    minimumCost = Math.Min(minimumCost, currentCost);
                }
            }

            return minimumCost;
        }
    }
}