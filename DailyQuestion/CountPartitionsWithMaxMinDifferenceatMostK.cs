namespace DailyQuestion
{
    public class CountPartitionsWithMaxMinDifferenceatMostK
    {
        public int CountPartitions(int[] nums, int k)
        {
            const int MOD = 1_000_000_007;
            int length = nums.Length;

            long[] dpWays = new long[length + 1];
            long[] prefixWays = new long[length + 1];

            dpWays[0] = 1;
            prefixWays[0] = 1;

            LinkedList<int> minIndexDeque = new LinkedList<int>();
            LinkedList<int> maxIndexDeque = new LinkedList<int>();

            int windowLeft = 0;

            for(int windowRight = 0; windowRight < length; windowRight++)
            {
                while(minIndexDeque.Count > 0 && nums[minIndexDeque.Last.Value] > nums[windowRight])
                {
                    minIndexDeque.RemoveLast();
                }

                while(maxIndexDeque.Count > 0 && nums[maxIndexDeque.Last.Value] < nums[windowRight])
                {
                    maxIndexDeque.RemoveLast();
                }

                minIndexDeque.AddLast(windowRight);
                maxIndexDeque.AddLast(windowRight);

                while(nums[maxIndexDeque.First.Value] - nums[minIndexDeque.First.Value] > k)
                {
                    if(minIndexDeque.First.Value == windowLeft)
                    {
                        minIndexDeque.RemoveFirst();
                    }
                    if(maxIndexDeque.First.Value == windowLeft)
                    {
                        maxIndexDeque.RemoveFirst();
                    }
                    windowLeft++;
                }

                long rangeWays = prefixWays[windowRight];

                if(windowLeft > 0)
                {
                    rangeWays = (rangeWays - prefixWays[windowLeft - 1] + MOD) % MOD;
                }

                dpWays[windowRight + 1] = rangeWays;
                prefixWays[windowRight + 1] = (prefixWays[windowRight] + dpWays[windowRight + 1]) % MOD;
            }

            return (int)dpWays[length];
        }
    }
}