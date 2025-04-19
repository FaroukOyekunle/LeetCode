namespace StudyPlan.Problem.LeetCode75.Intervals
{
    public class MinimumNumberofArrowstoBurstBalloons
    {
        public int FindMinArrowShots(int[][] points) 
        {
            if (points == null || points.Length == 0)
            {
                return 0;
            } 

            Array.Sort(points, (a, b) => 
            {
                long diff = (long)a[1] - b[1];
                return diff < 0 ? -1 : diff > 0 ? 1 : 0;
            });
            
            int arrows = 1;
            long currentEnd = points[0][1];
            
            for(int i = 1; i < points.Length; i++) 
            {
                if(points[i][0] > currentEnd) 
                {
                    arrows++;
                    currentEnd = points[i][1];
                }
            }
            
            return arrows;
        }
    }
}