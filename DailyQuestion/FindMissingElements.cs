namespace DailyQuestion
{
    public class FindMissingElements
    {
        public IList<int> FindMissingElements(int[] inputNumbers)
        {
            int smallestValueInRange = inputNumbers.Min();
            int largestValueInRange = inputNumbers.Max();

            HashSet<int> numbersPresentInArray = new HashSet<int>(inputNumbers);

            List<int> missingNumbers = new List<int>();

            for (int currentValueInRange = smallestValueInRange; currentValueInRange <= largestValueInRange; currentValueInRange++)
            {
                if (!numbersPresentInArray.Contains(currentValueInRange))
                {
                    missingNumbers.Add(currentValueInRange);
                }
            }

            return missingNumbers;
        }
    }
}