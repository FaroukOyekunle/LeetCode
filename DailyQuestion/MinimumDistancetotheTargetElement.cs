namespace DailyQuestion
{
    public class MinimumDistancetotheTargetElement
    {
        public int GetMinimumDistanceToTarget(int[] numbers, int targetValue, int startIndex)
        {
            int minimumDistanceFound = int.MaxValue;

            for (int currentIndex = 0; currentIndex < numbers.Length; currentIndex++)
            {
                if (numbers[currentIndex] == targetValue)
                {
                    int distanceFromStartIndex = Math.Abs(currentIndex - startIndex);

                    minimumDistanceFound = Math.Min(minimumDistanceFound, distanceFromStartIndex);
                }
            }

            return minimumDistanceFound;
        }
    }
}