namespace DailyQuestion
{
    public class MinimumTimeVisitingAllPoints
    {
        public int MinTimeToVisitAllPoints(int[][] pointCoordinates)
        {
            int totalTravelTime = 0;

            for(int pointIndex = 1; pointIndex < pointCoordinates.Length; pointIndex++)
            {
                int xDifference = Math.Abs(pointCoordinates[pointIndex][0] - pointCoordinates[pointIndex - 1][0]);
                int yDifference = Math.Abs(pointCoordinates[pointIndex][1] - pointCoordinates[pointIndex - 1][1]);

                totalTravelTime += Math.Max(xDifference, yDifference);
            }

            return totalTravelTime;
        }
    }
}