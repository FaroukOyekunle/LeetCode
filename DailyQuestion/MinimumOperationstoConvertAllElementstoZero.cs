namespace DailyQuestion
{
    public class MinimumOperationsToConvertAllElementsToZero
    {
        public int CalculateMinimumOperations(int[] numbers)
        {
            var stack = new Stack<int>();
            int operationCount = 0;

            foreach(var value in numbers)
            {
                while(stack.Count > 0 && stack.Peek() > value)
                {
                    stack.Pop();
                }

                if(value == 0)
                {
                    continue;
                }

                if(stack.Count == 0 || stack.Peek() < value)
                {
                    stack.Push(value);
                    operationCount++;
                }
            }

            return operationCount;
        }
    }
}