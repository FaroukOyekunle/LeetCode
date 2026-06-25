namespace DailyQuestion
{
    public class CountSubarraysWithMajorityElementI
    {
        public int CountMajoritySubarrays(int[] numbers, int targetValue)
        {
            int totalElementCount = numbers.Length;

            int[] prefixMajorityBalance = new int[totalElementCount + 1];

            for (int currentIndex = 0; currentIndex < totalElementCount; currentIndex++)
            {
                int currentElementContribution = numbers[currentIndex] == targetValue ? 1 : -1;

                prefixMajorityBalance[currentIndex + 1] = prefixMajorityBalance[currentIndex] + currentElementContribution;
            }

            int totalMajoritySubarrayCount = 0;

            for (int subarrayEndExclusive = 1; subarrayEndExclusive <= totalElementCount; subarrayEndExclusive++)
            {
                for (int subarrayStart = 0; subarrayStart < subarrayEndExclusive; subarrayStart++)
                {
                    bool targetIsMajorityInSubarray = prefixMajorityBalance[subarrayEndExclusive] > prefixMajorityBalance[subarrayStart];

                    if (targetIsMajorityInSubarray)
                    {
                        totalMajoritySubarrayCount++;
                    }
                }
            }

            return totalMajoritySubarrayCount;
        }
    }
}