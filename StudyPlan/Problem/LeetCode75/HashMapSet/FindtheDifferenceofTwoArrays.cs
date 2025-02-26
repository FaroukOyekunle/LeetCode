namespace StudyPlan.Problem.LeetCode75.HashMapSet
{
    public class FindtheDifferenceofTwoArrays
    {
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>(nums2);

            List<int> diff1 = new List<int>();
            foreach(int num in set1)
            {
                if(!set2.Contains(num))
                {
                    diff1.Add(num);
                }
            }

            List<int> diff2 = new List<int>();

            foreach(int num in set2)
            {
                if(!set1.Contains(num))
                {
                    diff2.Add(num);
                }
            }

            return new List<IList<int>> { diff1, diff2 };
        }
    }
}