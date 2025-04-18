namespace StudyPlan.Problem.LeetCode75.Intervals
{
    public class NonOverlappingIntervals
    {
        public int EraseOverlapIntervals(int[][] intervals) 
        {
            if (intervals == null || intervals.Length == 0)
            {
                return 0;
            }

            Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

            int count = 0;
            int prevEnd = int.MinValue;

            foreach(var interval in intervals) 
            {
                int start = interval[0], end = interval[1];

                if(start >= prevEnd) 
                {
                    prevEnd = end; 
                } 
                
                else 
                {
                    count++; 
                }
            }

            return count;
        }
    }
}