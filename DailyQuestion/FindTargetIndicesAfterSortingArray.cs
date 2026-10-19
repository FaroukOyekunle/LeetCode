namespace DailyQuestion
{
    public class FindingTargetIndicesAfterSortingArray
    {
        public IList<int> TargetIndices(int[] numbers, int targetValue)
        {
            int countOfElementsSmallerThanTarget = 0;
            int countOfTargetValueOccurrences = 0;

            foreach (int currentNumber in numbers)
            {
                if (currentNumber < targetValue)
                {
                    countOfElementsSmallerThanTarget++;
                }
                else if (currentNumber == targetValue)
                {
                    countOfTargetValueOccurrences++;
                }
            }

            IList<int> sortedTargetIndices = new List<int>();

            for (int targetOccurrenceOffset = 0; targetOccurrenceOffset < countOfTargetValueOccurrences; targetOccurrenceOffset++)
            {
                sortedTargetIndices.Add(countOfElementsSmallerThanTarget + targetOccurrenceOffset);
            }

            return sortedTargetIndices;
        }
    }
}