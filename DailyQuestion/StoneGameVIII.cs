namespace DailyQuestion
{
    public class StoneGameVIII
    {
        public int StoneGameVIII(int[] stoneValues)
        {
            int cumulativeStoneSum = 0;

            foreach (int stoneValue in stoneValues)
            {
                cumulativeStoneSum += stoneValue;
            }

            int maximumScoreDifference = cumulativeStoneSum;

            for (int stoneIndex = stoneValues.Length - 2; stoneIndex >= 1; stoneIndex--)
            {
                cumulativeStoneSum -= stoneValues[stoneIndex + 1];

                maximumScoreDifference = Math.Max(maximumScoreDifference, cumulativeStoneSum - maximumScoreDifference);
            }

            return maximumScoreDifference;
        }
    }
}