namespace StudyPlan.Problem.LeetCode75.Heap-PriorityQueue
{
    public class MaximumSubsequenceScore
    {
        public long MaxScore(int[] nums1, int[] nums2, int k) 
        {
            int n = nums1.Length;

            var pairs = new (int a, int b)[n];
            for(int i = 0; i < n; i++) 
            {
                pairs[i] = (nums1[i], nums2[i]);
            }

            Array.Sort(pairs, (p, q) => q.b.CompareTo(p.b));
            
            long sum = 0;
            long ans = 0;

            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            
            foreach(var (a, b) in pairs) 
            {
                minHeap.Enqueue(a, a);
                sum += a;
                
                if(minHeap.Count > k) 
                {
                    int removed = minHeap.Dequeue();
                    sum -= removed;
                }
                
                if(minHeap.Count == k) 
                {
                    long candidate = sum * b;
                    ans = Math.Max(ans, candidate);
                }
            }
            
            return ans;
        }
    }
}