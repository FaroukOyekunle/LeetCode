namespace DailyQuestion
{
    public class TwoFurthestHousesWithDifferentColors
    {
        public int FindMaximumDistanceBetweenDifferentColors(int[] colorArray)
        {
            int totalElements = colorArray.Length;

            int maximumDistanceFound = 0;

            int firstColor = colorArray[0];
            int lastColor = colorArray[totalElements - 1];

            for (int indexFromEnd = totalElements - 1; indexFromEnd >= 0; indexFromEnd--)
            {
                int currentColor = colorArray[indexFromEnd];

                if (currentColor != firstColor)
                {
                    int distanceFromStart = indexFromEnd;

                    maximumDistanceFound = Math.Max(
                        maximumDistanceFound,
                        distanceFromStart);

                    break;
                }
            }

            for (int indexFromStart = 0; indexFromStart < totalElements; indexFromStart++)
            {
                int currentColor = colorArray[indexFromStart];

                if (currentColor != lastColor)
                {
                    int distanceFromEnd = (totalElements - 1) - indexFromStart;

                    maximumDistanceFound = Math.Max(
                        maximumDistanceFound,
                        distanceFromEnd);

                    break;
                }
            }

            return maximumDistanceFound;
        }
    }
}