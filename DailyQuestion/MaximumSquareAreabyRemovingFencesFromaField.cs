namespace DailyQuestion
{
    public class MaximumSquareAreabyRemovingFencesFromaField
    {
        public int MaximizeSquareArea(int fieldHeight, int fieldWidth, int[] horizontalFences, int[] verticalFences)
        {
            const long Modulo = 1_000_000_007;

            var horizontalFencePositions = new List<int>(horizontalFences) { 1, fieldHeight };
            var verticalFencePositions = new List<int>(verticalFences) { 1, fieldWidth };

            horizontalFencePositions.Sort();
            verticalFencePositions.Sort();

            var uniqueHorizontalDistances = new HashSet<int>();
            for (int startIndex = 0; startIndex < horizontalFencePositions.Count; startIndex++)
            {
                for (int endIndex = startIndex + 1; endIndex < horizontalFencePositions.Count; endIndex++)
                {
                    uniqueHorizontalDistances.Add(horizontalFencePositions[endIndex] - horizontalFencePositions[startIndex]);
                }
            }

            long maximumSquareSideLength = -1;

            for (int startIndex = 0; startIndex < verticalFencePositions.Count; startIndex++)
            {
                for (int endIndex = startIndex + 1; endIndex < verticalFencePositions.Count; endIndex++)
                {
                    int verticalDistance = verticalFencePositions[endIndex] - verticalFencePositions[startIndex];
                    if (uniqueHorizontalDistances.Contains(verticalDistance))
                    {
                        maximumSquareSideLength = Math.Max(maximumSquareSideLength, verticalDistance);
                    }
                }
            }

            if (maximumSquareSideLength == -1)
            {
                return -1;
            }

            return (int)((maximumSquareSideLength * maximumSquareSideLength) % Modulo);
        }
    }
}