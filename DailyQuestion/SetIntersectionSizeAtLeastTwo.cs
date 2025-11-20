namespace DailyQuestion
{
    public class SetIntersectionSizeAtLeastTwo
    {
        public int IntersectionSizeTwo(int[][] intervals)
        {

            Array.Sort(intervals, (a, b) =>
            {
                if (a[1] == b[1])
                {
                    return b[0].CompareTo(a[0]);
                }

                return a[1].CompareTo(b[1]);
            });

            int result = 0;

            int firstSelected = int.MinValue / 2;
            int secondSelected = int.MinValue / 2;

            foreach(var interval in intervals)
            {
                int left = interval[0], right = interval[1];

                if(left > secondSelected)
                {
                    result += 2;
                    firstSelected = right - 1;
                    secondSelected = right;
                }

                else if(left > firstSelected)
                {
                    result += 1;
                    firstSelected = secondSelected;
                    secondSelected = right;
                }
            }

            return result;
        }
    }
}