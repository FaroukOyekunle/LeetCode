namespace StudyPlan.Problem.LeetCode75.PrefixSum
{
    public class FindtheHighestAltitude
    {
        public int LargestAltitude(int[] gain)
        {
            int altitude = 0;
            int maxAltitude = 0;

            foreach(int delta in gain)
            {
                altitude += delta;
                maxAltitude = Math.Max(maxAltitude, altitude);
            }

            return maxAltitude;
        }
    }
}