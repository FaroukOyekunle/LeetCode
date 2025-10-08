namespace DailyQuestion
{
    public class AvoidFloodinTheCity
    {
        public int[] AvoidFlood(int[] rains)
        {
            int n = rains.Length;
            int[] ans = new int[n];
            
            var full = new Dictionary<int, int>();   
            var dryDays = new SortedSet<int>();     

            for(int i = 0; i < n; i++)
            {
                if(rains[i] == 0)
                {
                    dryDays.Add(i);
                    ans[i] = 1;
                }
                else
                {
                    int lake = rains[i];
                    ans[i] = -1;

                    if(full.TryGetValue(lake, out int lastRainDay))
                    {
                        var view = dryDays.GetViewBetween(lastRainDay + 1, int.MaxValue);
                        var en = view.GetEnumerator();
                        if(!en.MoveNext())
                        {
                            return new int[0];
                        }

                        int dryDay = en.Current;
                        ans[dryDay] = lake;    
                        dryDays.Remove(dryDay);
                    }

                    full[lake] = i;
                }
            }

            return ans;
        }
    }
}