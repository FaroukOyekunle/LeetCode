namespace DailyQuestion
{
    public class MakeSumDivisiblebyP
    {
        public int FindMinSubarrayToMakeSumDivisible(int[] numbers, int divisor)
        {
            long totalSum = 0;
            foreach(int value in numbers)
            {
                totalSum += value;
            }

            long remainderNeeded = totalSum % divisor;
            if(remainderNeeded == 0)
            {
                return 0;
            }

            Dictionary<long, int> prefixModToIndex = new Dictionary<long, int>();
            prefixModToIndex[0] = -1;

            long currentPrefixMod = 0;
            int minLength = numbers.Length;

            for(int index = 0; index < numbers.Length; index++)
            {
                currentPrefixMod = (currentPrefixMod + numbers[index]) % divisor;

                long targetMod = (currentPrefixMod - remainderNeeded + divisor) % divisor;

                if(prefixModToIndex.ContainsKey(targetMod))
                {
                    minLength = Math.Min(minLength, index - prefixModToIndex[targetMod]);
                }

                prefixModToIndex[currentPrefixMod] = index;
            }

            return minLength == numbers.Length ? -1 : minLength;
        }
    }
}