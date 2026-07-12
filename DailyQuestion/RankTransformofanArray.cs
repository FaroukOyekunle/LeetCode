namespace DailyQuestion
{
    public class RankTransformofanArray
    {
        public int[] ArrayRankTransform(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return Array.Empty<int>();
            }

            int[] sortedNumbers = (int[])numbers.Clone();
            Array.Sort(sortedNumbers);

            Dictionary<int, int> numberToRankMap = new Dictionary<int, int>();
            int nextAvailableRank = 1;

            foreach (int currentNumber in sortedNumbers)
            {
                if (!numberToRankMap.ContainsKey(currentNumber))
                {
                    numberToRankMap[currentNumber] = nextAvailableRank;
                    nextAvailableRank++;
                }
            }

            int[] transformedRanks = new int[numbers.Length];

            for (int arrayIndex = 0; arrayIndex < numbers.Length; arrayIndex++)
            {
                transformedRanks[arrayIndex] = numberToRankMap[numbers[arrayIndex]];
            }

            return transformedRanks;
        }
    }
}