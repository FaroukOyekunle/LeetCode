namespace StudyPlan.Problem.LeetCode75
{
    public class KidsWiththeGreatestNumberofCandies
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int maxCandy = 0;
            int n = candies.Length;

            List<bool> result = new List<bool>(n);

            foreach(int candy in candies)
            {
                if (candy > maxCandy)
                {
                    maxCandy = candy;
                }
            }

            foreach(int candy in candies)
            {
                result.Add(candy + extraCandies >= maxCandy);
            }

            return result;
        }
    }
}