namespace DailyQuestion
{
    public class MaximumFrequencyofanElementAfterPerformingOperationsI
    {
        public int MaxFrequency(int[] nums, int k, int numOperations)
        {
            if(nums == null || nums.Length == 0)
            {
                return 0;
            }
            
            int n = nums.Length;

            var equals = new Dictionary<long, int>();

            foreach(var v in nums)
            {
                long lv = v;

                if(!equals.ContainsKey(lv))
                {
                    equals[lv] = 0;
                }
                equals[lv]++;
            }

            var events = new Dictionary<long, int>();

            var candidates = new HashSet<long>();

            foreach(var v in nums)
            {
                long L = (long)v - k;
                long R = (long)v + k;

                if(!events.ContainsKey(L))
                {
                    events[L] = 0;
                }

                events[L] += 1;

                long afterReversal = R + 1;

                if(!events.ContainsKey(afterReversal))
                {
                    events[afterReversal] = 0;
                }

                events[afterReversal] -= 1;

                candidates.Add(L);
                candidates.Add(R);
                candidates.Add(v);
            }

            var allPositions = new List<long>();

            foreach(var kv in events)
            {
                allPositions.Add(kv.Key);
            }

            foreach(var c in candidates)
            {
                if(!events.ContainsKey(c))
                {
                    allPositions.Add(c);
                }
            }

            allPositions.Sort();

            int maxFreq = 0;
            long cover = 0;

            foreach(var pos in allPositions)
            {
                if(events.TryGetValue(pos, out int delta))
                {
                    cover += delta;
                }

                if(candidates.Contains(pos))
                {
                    int eq = equals.TryGetValue(pos, out int val) ? val : 0;

                    int coverInt = (int)cover;
                    int possible = Math.Min(coverInt, eq + numOperations);

                    if(possible > maxFreq)
                    {
                        maxFreq = possible;
                    }
                }
            }

            return maxFreq;
        }
    }
}