namespace StudyPlan.Problem.LeetCode75.Heap-PriorityQueue
{
    public class KthLargestElementinanArray
    {
        public int FindKthLargest(int[] nums, int k) 
        {
            int n = nums.Length;
            return QuickSelect(nums, 0, n - 1, n - k);
        }

        private int QuickSelect(int[] nums, int left, int right, int k_smallest) 
        {
            if(left == right)
            {
                return nums[left];
            }

            Random rand = new Random();
            int pivot_index = left + rand.Next(right - left + 1);

            pivot_index = Partition(nums, left, right, pivot_index);

            if(k_smallest == pivot_index)
            {
                return nums[k_smallest];
            }
                
            else if(k_smallest < pivot_index)
            {
                return QuickSelect(nums, left, pivot_index - 1, k_smallest);
            }
                
            else
            {
                return QuickSelect(nums, pivot_index + 1, right, k_smallest);
            }
        }

        private int Partition(int[] nums, int left, int right, int pivot_index) 
        {
            int pivot = nums[pivot_index];

            Swap(nums, pivot_index, right);
            int store_index = left;

            for(int i = left; i < right; i++) 
            {
                if(nums[i] < pivot) 
                {
                    Swap(nums, store_index, i);
                    store_index++;
                }
            }

            Swap(nums, store_index, right);
            return store_index;
        }

        private void Swap(int[] nums, int i, int j) 
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}