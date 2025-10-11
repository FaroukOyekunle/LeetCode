namespace DailyQuestion
{
    public class MaximumTotalDamageWithSpellCasting
    {
        public long MaximumTotalDamage(int[] power)
        {
            var damageMap = new SortedDictionary<int, long>();

            foreach(var p in power)
            {
                if (!damageMap.ContainsKey(p))
                {
                    damageMap[p] = 0;
                }
                damageMap[p] += p;
            }

            var keys = damageMap.Keys.ToList();
            int possibleDamage = keys.Count;

            long[] damagePoint = new long[possibleDamage];
            damagePoint[0] = damageMap[keys[0]];

            for (int i = 1; i < possibleDamage; i++)
            {
                long skipSet = damagePoint[i - 1];
                long takeCount = damageMap[keys[i]];

                int j = i - 1;

                while(j >= 0 && keys[i] - keys[j] <= 2)
                {
                    j--;
                }

                if(j >= 0)
                {
                    takeCount += damagePoint[j];
                }

                damagePoint[i] = Math.Max(skipSet, takeCount);
            }

            return damagePoint[possibleDamage - 1];
        }
    }
}