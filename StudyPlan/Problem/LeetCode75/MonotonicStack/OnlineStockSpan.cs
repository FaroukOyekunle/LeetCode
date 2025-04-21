namespace StudyPlan.Problem.LeetCode75.MonotonicStack
{
    public class OnlineStockSpan
    {
        private readonly Stack<(int price, int span)> _stack;

        public StockSpanner() 
        {
            _stack = new Stack<(int, int)>();
        }
        
        public int Next(int price) 
        {
            int span = 1;

            while(_stack.Count > 0 && _stack.Peek().price <= price) 
            {
                span += _stack.Pop().span;
            }
            
            _stack.Push((price, span));
            return span;
        }
    }
}