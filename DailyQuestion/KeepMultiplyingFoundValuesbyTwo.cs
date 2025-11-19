namespace DailyQuestion
{
    public class KeepMultiplyingFoundValuesbyTwo
    {
        public int GetFinalValueAfterDoubling(int[] numbers, int initialValue)
        {
            var numbersSet = new HashSet<int>(numbers);
            int currentValue = initialValue;

            while (numbersSet.Contains(currentValue))
            {
                currentValue *= 2;
            }

            return currentValue;
        }
    }
}