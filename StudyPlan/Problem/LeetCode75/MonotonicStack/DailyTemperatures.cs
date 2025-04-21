namespace StudyPlan.Problem.LeetCode75.MonotonicStack
{
    public class DailyTemperatures
    {
        public int[] DailyTemperatures(int[] temperatures) 
        {
            int n = temperatures.Length;
            int[] ans = new int[n];

            var stack = new Stack<int>();
            
            for(int i = 0; i < n; i++) 
            {
                while(stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()]) 
                {
                    int prevDay = stack.Pop();
                    ans[prevDay] = i - prevDay;
                }

                stack.Push(i);
            }
            
            return ans;
        }
    }
}