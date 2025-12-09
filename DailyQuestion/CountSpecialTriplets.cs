namespace DailyQuestion
{
    public class CountSpecialTriplets
    {
        public int SpecialTriplets(int[] nums)
        {
            const int MOD = 1_000_000_007;

            var leftFrequency = new Dictionary<int, long>();
            var rightFrequency = new Dictionary<int, long>();

            foreach(var value in nums)
            {
                if(!rightFrequency.ContainsKey(value))
                {
                    rightFrequency[value] = 0;
                }

                rightFrequency[value]++;
            }

            long tripletCount = 0;

            foreach(var value in nums)
            {
                rightFrequency[value]--;

                int targetValue = value * 2;

                if(leftFrequency.TryGetValue(targetValue, out long leftFreq) &&
                    rightFrequency.TryGetValue(targetValue, out long rightFreq))
                {
                    tripletCount = (tripletCount + leftFreq * rightFreq) % MOD;
                }

                if(!leftFrequency.ContainsKey(value))
                {
                    leftFrequency[value] = 0;
                }
                
                leftFrequency[value]++;
            }

            return (int)tripletCount;
        }
    }
}