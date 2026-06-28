namespace DailyQuestion
{
    public class MaximumElementAfterDecreasingandRearranging
    {
        public int MaximumElementAfterDecrementingAndRearranging(int[] numbers)
        {
            Array.Sort(numbers);

            numbers[0] = 1;

            for (int currentPosition = 1; currentPosition < numbers.Length; currentPosition++)
            {
                int previousAdjustedElement = numbers[currentPosition - 1];

                int maximumAllowedCurrentValue = previousAdjustedElement + 1;

                numbers[currentPosition] = Math.Min(numbers[currentPosition], maximumAllowedCurrentValue);
            }

            int largestAchievableElement = numbers[numbers.Length - 1];

            return largestAchievableElement;
        }
    }
}