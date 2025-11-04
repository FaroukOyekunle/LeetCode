namespace DailyQuestion
{
    public class FindXSumofAllKLongSubarraysI
    {
        public int[] FindXSum(int[] nums, int k, int x)
        {
            int n = nums.Length;
            int[] answer = new int[n - k + 1];

            for(int i = 0; i <= n - k; i++)
            {
                var window = nums.Skip(i).Take(k);

                var frequencyWithKeyValue = new Dictionary<int, int>();
                foreach(var numberCount in window)
                {
                    if(!frequencyWithKeyValue.ContainsKey(numberCount))
                    {
                        frequencyWithKeyValue[numberCount] = 0;
                    }

                    frequencyWithKeyValue[numberCount]++;
                }

                var topX = frequencyWithKeyValue
                    .OrderByDescending(p => p.Value)
                    .ThenByDescending(p => p.Key)
                    .Take(x)
                    .Select(p => p.Key)
                    .ToHashSet();

                int sum = window.Where(num => topX.Contains(num)).Sum();

                answer[i] = sum;
            }

            return answer;
        }
    }
}