namespace DailyQuestion
{
    public class MakeArrayElementsEqualtoZero
    {
        public int CountValidSelections(int[] nums)
        {
            int inputLength = nums.Length;
            int count = 0;

            for(int start = 0; start < inputLength; start++)
            {
                if(nums[start] != 0)
                {
                    continue;
                }

                if(Simulate((int[])nums.Clone(), start, 1))
                {
                    count++;
                }
                
                if(Simulate((int[])nums.Clone(), start, -1))
                {
                    count++;
                }
            }

            return count;
        }

        private bool Simulate(int[] nums, int currentSequence, int direction)
        {
            int inputLength = nums.Length;

            while(currentSequence >= 0 && currentSequence < inputLength)
            {
                if(nums[currentSequence] == 0)
                {
                    currentSequence += direction;
                }

                else
                {
                    nums[currentSequence]--;
                    direction = -direction;
                    currentSequence += direction;
                }
            }

            foreach(var value in nums)
            {
                if(value != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}