namespace StudyPlan.Problem.LeetCode75.Heap-PriorityQueue
{
    public class SmallestNumberinInfiniteSet
    {
        private int current;
        private SortedSet<int> addedBack;
        public SmallestInfiniteSet() 
        {
            current = 1;
            addedBack = new SortedSet<int>();
        }
        
        public int PopSmallest() 
        {
            if(addedBack.Count > 0) 
            {
                int smallest = addedBack.Min;
                addedBack.Remove(smallest);
                return smallest;
            }
            return current++;
        }
        
        public void AddBack(int num) 
        {
            if (num < current && !addedBack.Contains(num)) 
            {
                addedBack.Add(num);
            }
        }
    }

    SmallestInfiniteSet obj = new SmallestInfiniteSet();
    int param_1 = obj.PopSmallest();
    obj.AddBack(num);
}