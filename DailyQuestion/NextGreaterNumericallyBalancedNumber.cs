namespace DailyQuestion
{
    public class NextGreaterNumericallyBalancedNumber
    {
        public int NextBeautifulNumber(int n)
        {
            const int maximumLength = 7;
            HashSet<int> set = new HashSet<int>();

            int maximumMask = 1 << 9;
            for(int mask = 1; mask < maximumMask; mask++)
            {
                int totalCountLength = 0;
                int[] counts = new int[10];

                for(int d = 1; d <= 9; d++)
                {
                    if(((mask >> (d - 1)) & 1) == 1)
                    {
                        totalCountLength += d;

                        if(totalCountLength > maximumLength)
                        {
                            break;
                        }
                        counts[d] = d;
                    }
                }

                if(totalCountLength == 0 || totalCountLength > maximumLength)
                {
                    continue;
                }

                StringBuilder sb = new StringBuilder(totalCountLength);
                
                PermuteDigits(counts, totalCountLength, sb, set);
            }

            foreach(var num in set.OrderBy(x => x))
            {
                if(num > n)
                {
                    return num;
                }
            }

            return -1;
        }

        private void PermuteDigits(int[] counts, int targetLength, StringBuilder stringBuilder, HashSet<int> set)
        {
            if(stringBuilder.Length == targetLength)
            {
                set.Add(int.Parse(stringBuilder.ToString()));
                return;
            }

            for(int d = 1; d <= 9; d++)
            {
                if(counts[d] == 0)
                {
                    continue;
                }

                counts[d]--;
                stringBuilder.Append((char)('0' + d));

                PermuteDigits(counts, targetLength, stringBuilder, set);

                stringBuilder.Length--;
                counts[d]++;
            }
        }
    }
}