namespace DailyQuestion
{
    public class MaximumProductofTwoElementsinanArray
    {
        public int MaxProduct(int[] numbers)
        {
            int largestValue = 0;
            int secondLargestValue = 0;

            foreach (int currentValue in numbers)
            {
                if (currentValue > largestValue)
                {
                    secondLargestValue = largestValue;
                    largestValue = currentValue;
                }
                else if (currentValue > secondLargestValue)
                {
                    secondLargestValue = currentValue;
                }
            }

            return (largestValue - 1) * (secondLargestValue - 1);
        }
    }
}