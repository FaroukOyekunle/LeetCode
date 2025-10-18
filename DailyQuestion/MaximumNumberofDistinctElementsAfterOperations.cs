namespace DailyQuestion
{
    public class MaximumNumberofDistinctElementsAfterOperations
    {
        public int MaxDistinctElements(int[] nums, int k)
        {
            var responseIntervals = new (long l, long r)[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                long elementOfModulo = nums[i];
                responseIntervals[i] = (elementOfModulo - k, elementOfModulo + k);
            }

            Array.Sort(responseIntervals, (a, b) =>
            {
                int compareDataValue = a.r.CompareTo(b.r);
                return compareDataValue != 0 ? compareDataValue : a.l.CompareTo(b.l);
            });

            var parentValueTag = new Dictionary<long, long>();

            long Find(long x)
            {
                if (!parentValueTag.ContainsKey(x))
                {
                    return x;
                }

                long nxt = parentValueTag[x];
                long res = Find(nxt);

                parentValueTag[x] = res;
                
                return res;
            }

            int distinct = 0;
            foreach (var (l, r) in responseIntervals)
            {
                long candidate = Find(l);
                if (candidate <= r)
                {
                    parentValueTag[candidate] = candidate + 1;
                    distinct++;
                }
            }

            return distinct;
        }
    }
}