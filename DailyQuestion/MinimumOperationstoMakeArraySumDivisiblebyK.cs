namespace DailyQuestion
{
    public class MinimumOperationstoMakeArraySumDivisiblebyK
    {
        public int CalculateMinOperationsToMakeSumDivisibleByK(int[] numbers, int divisor)
        {
            int totalSum = numbers.Sum();
            int remainder = totalSum % divisor;

            if(remainder == 0)
            {
                return 0;
            }

            return remainder;
        }
    }
}