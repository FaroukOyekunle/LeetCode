namespace DailyQuestion
{
    public class MinimumOperationsToMakeAllElementsDivisibleByThree
    {
        public int CalculateMinimumOperationsToMakeAllDivisibleByThree(int[] numbers)
        {
            int operationCount = 0;

            foreach(int value in numbers)
            {
                int remainder = value % 3;

                if(remainder == 1 || remainder == 2)
                {
                    operationCount++;
                }
            }

            return operationCount;
        }
    }
}