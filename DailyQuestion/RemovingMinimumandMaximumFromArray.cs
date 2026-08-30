namespace DailyQuestion
{
    public class RemovingMinimumandMaximumFromArray
    {
        public int MinimumDeletions(int[] numbers)
        {
            int numberCount = numbers.Length;

            int minimumElementIndex = 0;
            int maximumElementIndex = 0;

            for (int currentIndex = 1; currentIndex < numberCount; currentIndex++)
            {
                if (numbers[currentIndex] < numbers[minimumElementIndex])
                {
                    minimumElementIndex = currentIndex;
                }

                if (numbers[currentIndex] > numbers[maximumElementIndex])
                {
                    maximumElementIndex = currentIndex;
                }
            }

            int leftmostTargetIndex = Math.Min(minimumElementIndex, maximumElementIndex);

            int rightmostTargetIndex = Math.Max(minimumElementIndex, maximumElementIndex);

            int deletionsFromFront = rightmostTargetIndex + 1;

            int deletionsFromBack = numberCount - leftmostTargetIndex;

            int deletionsFromBothEnds = (leftmostTargetIndex + 1) + (numberCount - rightmostTargetIndex);

            return Math.Min(Math.Min(deletionsFromFront, deletionsFromBack), deletionsFromBothEnds);
        }
    }
}