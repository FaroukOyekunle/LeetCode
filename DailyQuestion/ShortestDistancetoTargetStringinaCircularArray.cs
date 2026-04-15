namespace DailyQuestion
{
    public class ShortestDistancetoTargetStringinaCircularArray
    {
        public int ClosestTarget(string[] wordsList, string targetWord, int startingIndex)
        {
            int totalWords = wordsList.Length;
            int minimumDistanceFound = int.MaxValue;

            for (int currentIndex = 0; currentIndex < totalWords; currentIndex++)
            {
                if (wordsList[currentIndex] == targetWord)
                {
                    int directDistance = Math.Abs(currentIndex - startingIndex);

                    int wrapAroundDistance = totalWords - directDistance;

                    int shortestDistanceToTarget = Math.Min(directDistance, wrapAroundDistance);

                    minimumDistanceFound = Math.Min(minimumDistanceFound, shortestDistanceToTarget);
                }
            }

            return minimumDistanceFound == int.MaxValue ? -1 : minimumDistanceFound;
        }
    }
}