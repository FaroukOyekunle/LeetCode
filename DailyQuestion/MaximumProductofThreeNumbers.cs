namespace DailyQuestion
{
    public class MaximumProductofThreeNumbers
    {
        public int MaximumProduct(int[] numbers)
        {
            Array.Sort(numbers);

            int totalNumberCount = numbers.Length;

            int productOfThreeLargestNumbers = numbers[totalNumberCount - 1] * numbers[totalNumberCount - 2] * numbers[totalNumberCount - 3];

            int productOfTwoSmallestNumbersAndLargestNumber = numbers[0] * numbers[1] * numbers[totalNumberCount - 1];

            return Math.Max(productOfThreeLargestNumbers, productOfTwoSmallestNumbersAndLargestNumber);
        }
    }
}