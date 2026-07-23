namespace DailyQuestion
{
    public class NumberofUniqueXORTripletsI
    {
        public int UniqueXorTriplets(int[] nums)
        {
            int totalElementCount = nums.Length;

            if (totalElementCount == 1)
            {
                return 1;
            }

            if (totalElementCount == 2)
            {
                return 2;
            }

            int requiredBitCount = 0;
            int remainingValue = totalElementCount;

            while (remainingValue > 0)
            {
                requiredBitCount++;
                remainingValue >>= 1;
            }

            int totalDistinctXorValues = 1 << requiredBitCount;

            return totalDistinctXorValues;
        }
    }
}