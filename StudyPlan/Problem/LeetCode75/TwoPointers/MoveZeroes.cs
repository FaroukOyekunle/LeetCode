namespace StudyPlan.Problem.LeetCode75.TwoPointers
{
    public class MoveZeroes
    {
        public void MoveZeroes(int[] nums)
        {
            int insertPos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    if (i != insertPos)
                    {
                        nums[insertPos] = nums[i];
                        nums[i] = 0;
                    }
                    insertPos++;
                }
            }
        }
    }