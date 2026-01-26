namespace DailyQuestion
{
    public class MinimumAbsoluteDifference
    {
        public IList<IList<int>> FindMinimumAbsoluteDifferencePairs(int[] inputArray)
        {
            Array.Sort(inputArray);

            int minimumDifference = int.MaxValue;
            var minimumDifferencePairs = new List<IList<int>>();

            for (int currentIndex = 1; currentIndex < inputArray.Length; currentIndex++)
            {
                int currentDifference = inputArray[currentIndex] - inputArray[currentIndex - 1];
                if (currentDifference < minimumDifference)
                {
                    minimumDifference = currentDifference;
                }
            }

            for (int currentIndex = 1; currentIndex < inputArray.Length; currentIndex++)
            {
                if (inputArray[currentIndex] - inputArray[currentIndex - 1] == minimumDifference)
                {
                    minimumDifferencePairs.Add(new List<int> { inputArray[currentIndex - 1], inputArray[currentIndex] });
                }
            }

            return minimumDifferencePairs;
        }
    }
}