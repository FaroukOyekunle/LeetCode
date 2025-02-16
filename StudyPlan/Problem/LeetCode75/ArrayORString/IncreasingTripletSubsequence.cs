namespace StudyPlan.Problem.LeetCode75.ArrayORString
{
    public class IncreasingTripletSubsequence
    {
        public bool IncreasingTriplet(int[] nums)
        {
            int first = int.MaxValue;
            int second = int.MaxValue;

            foreach (int number in nums)
            {
                if (number <= first)
                {
                    first = number;
                }

                else if (number <= second)
                {
                    second = number;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}