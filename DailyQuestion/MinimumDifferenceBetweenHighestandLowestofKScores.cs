namespace DailyQuestion
{
    public class MinimumDifferenceBetweenHighestandLowestofKScores
    {
        public int CalculateMinimumDifference(int[] scores, int groupSize)
        {
            if (groupSize == 1)
            {
                return 0;
            }

            Array.Sort(scores);

            int minimumDifference = int.MaxValue;

            for (int startIndex = 0; startIndex <= scores.Length - groupSize; startIndex++)
            {
                int currentDifference = scores[startIndex + groupSize - 1] - scores[startIndex];
                minimumDifference = Math.Min(minimumDifference, currentDifference);
            }

            return minimumDifference;
        }
    }
}