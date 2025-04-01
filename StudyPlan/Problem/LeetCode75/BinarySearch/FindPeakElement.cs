namespace StudyPlan.Problem.LeetCode75.BinarySearch
{
    public class FindPeakElement
    {
        public int FindPeakElement(int[] nums) 
        {
    
            int low = 0, high = nums.Length - 1;
            
            while(low < high) 
            {
                int mid = low + (high - low) / 2;

                if (nums[mid] > nums[mid + 1])
                {
                    high = mid;
                }
                    
                else
                {
                    low = mid + 1;
                }
                    
            }

            return low;
        }
    }
}