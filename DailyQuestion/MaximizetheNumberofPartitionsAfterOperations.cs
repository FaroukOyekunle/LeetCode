namespace DailyQuestion
{
    public class MaximizetheNumberofPartitionsAfterOperations
    {
        public int MaxPartitionsAfterOperations(string s, int k)
        {
            int n = s.Length;
            if (n == 0)
            {
                return 0;
            }
            if (k >= 26)
            {
                return 1;
            }

            int baseline = CountPartitions(s, k);
            int result = baseline;

            int[] bit = new int[26];
            for (int i = 0; i < 26; i++)
            {
                bit[i] = 1 << i;
            }

            for (int x = 0; x < 26; x++)
            {
                char target = (char)('a' + x);

                var dpNoChange = new Dictionary<int, int>();
                var dpUsed = new Dictionary<int, int>();

                dpNoChange[0] = 0;

                for (int i = 0; i < n; i++)
                {
                    int cIdx = s[i] - 'a';
                    int cBit = bit[cIdx];

                    var newNo = new Dictionary<int, int>();
                    var newUsed = new Dictionary<int, int>();

                    foreach (var kv in dpNoChange)
                    {
                        int mask = kv.Key;
                        int resets = kv.Value;

                        if ((mask & cBit) != 0 || CountBits(mask) < k)
                        {
                            int nm = mask | cBit;
                            UpdateMap(newNo, nm, resets);
                        }
                        else
                        {
                            UpdateMap(newNo, cBit, resets + 1);
                        }

                        if (cIdx != x)
                        {
                            int tBit = bit[x];
                            if ((mask & tBit) != 0 || CountBits(mask) < k)
                            {
                                int nm = mask | tBit;
                                UpdateMap(newUsed, nm, resets);
                            }
                            else
                            {
                                UpdateMap(newUsed, tBit, resets + 1);
                            }
                        }
                    }

                    foreach (var kv in dpUsed)
                    {
                        int mask = kv.Key;
                        int resets = kv.Value;

                        if ((mask & cBit) != 0 || CountBits(mask) < k)
                        {
                            int nm = mask | cBit;
                            UpdateMap(newUsed, nm, resets);
                        }
                        else
                        {
                            UpdateMap(newUsed, cBit, resets + 1);
                        }
                    }

                    dpNoChange = newNo;
                    dpUsed = newUsed;
                }

                int bestForTarget = baseline;

                foreach (var kv in dpNoChange) bestForTarget = Math.Max(bestForTarget, kv.Value + 1);
                foreach (var kv in dpUsed) bestForTarget = Math.Max(bestForTarget, kv.Value + 1);

                result = Math.Max(result, bestForTarget);
            }

            return Math.Min(result, n);
        }

        private static void UpdateMap(Dictionary<int, int> map, int mask, int resets)
        {
            if (map.TryGetValue(mask, out int old))
            {
                if (resets > old)
                {
                    map[mask] = resets;
                }
            }
            else map[mask] = resets;
        }

        private static Dictionary<int, int> TrimMap(Dictionary<int, int> map, int keep)
        {
            return map.OrderByDescending(kv => kv.Value)
                      .Take(keep)
                      .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private static int CountBits(int x)
        {
            int cnt = 0;
            while (x != 0)
            {
                x &= (x - 1);
                cnt++;
            }
            return cnt;
        }

        private int CountPartitions(string s, int k)
        {
            int partitions = 0;
            var freq = new int[26];
            int distinct = 0;

            foreach (char ch in s)
            {
                int idx = ch - 'a';
                if (freq[idx] == 0)
                {
                    distinct++;
                }

                freq[idx]++;

                if (distinct > k)
                {
                    partitions++;
                    Array.Clear(freq, 0, freq.Length);
                    distinct = 0;
                    freq[idx] = 1;
                    distinct = 1;
                }
            }
            return partitions + 1;
        }
    }
}