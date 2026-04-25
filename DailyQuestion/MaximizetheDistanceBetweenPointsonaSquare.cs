namespace DailyQuestion
{
    public interface MaximizetheDistanceBetweenPointsonaSquare
    {
        public int MaxDistance(int squareSideLength, int[][] boundaryPoints, int requiredPoints)
        {
            long squarePerimeter = 4L * squareSideLength;

            int totalPoints = boundaryPoints.Length;

            var perimeterPositions = new List<long>();

            foreach (var point in boundaryPoints)
            {
                long xCoordinate = point[0];
                long yCoordinate = point[1];

                if (xCoordinate == 0)
                {
                    perimeterPositions.Add(yCoordinate);
                }
                else if (yCoordinate == squareSideLength)
                {
                    perimeterPositions.Add(squareSideLength + xCoordinate);
                }
                else if (xCoordinate == squareSideLength)
                {
                    perimeterPositions.Add(2L * squareSideLength + (squareSideLength - yCoordinate));
                }
                else
                {
                    perimeterPositions.Add(3L * squareSideLength + (squareSideLength - xCoordinate));
                }
            }
            perimeterPositions.Sort();

            long[] extendedPerimeterPositions = new long[2 * totalPoints];

            for (int index = 0; index < totalPoints; index++)
            {
                extendedPerimeterPositions[index] = perimeterPositions[index];
                extendedPerimeterPositions[index + totalPoints] = perimeterPositions[index] + squarePerimeter;
            }

            int FindFirstPositionAtLeast(long[] array, int leftIndex, int rightIndex, long targetValue)
            {
                while (leftIndex < rightIndex)
                {
                    int midIndex = (leftIndex + rightIndex) / 2;

                    if (array[midIndex] < targetValue)
                    {
                        leftIndex = midIndex + 1;
                    }
                    else
                    {
                        rightIndex = midIndex;
                    }
                }

                return leftIndex;
            }

            bool CanSelectPointsWithDistance(long minimumDistance)
            {
                for (int startIndex = 0; startIndex < totalPoints; startIndex++)
                {
                    int selectedCount = 1;
                    int currentIndex = startIndex;

                    long firstSelectedPosition = extendedPerimeterPositions[startIndex];
                    long lastSelectedPosition = firstSelectedPosition;

                    while (selectedCount < requiredPoints)
                    {
                        int nextIndex = FindFirstPositionAtLeast( extendedPerimeterPositions, currentIndex + 1, startIndex + totalPoints, lastSelectedPosition + minimumDistance);

                        if (nextIndex >= startIndex + totalPoints)
                        {
                            break;
                        }

                        if (extendedPerimeterPositions[nextIndex] - firstSelectedPosition > squarePerimeter - minimumDistance)
                        {
                            break;
                        }

                        selectedCount++;
                        currentIndex = nextIndex;
                        lastSelectedPosition = extendedPerimeterPositions[nextIndex];
                    }

                    if (selectedCount >= requiredPoints)
                    {
                        return true;
                    }
                }

                return false;
            }

            long minimumPossibleDistance = 0;
            long maximumPossibleDistance = squarePerimeter;

            while (minimumPossibleDistance < maximumPossibleDistance)
            {
                long midDistance = (minimumPossibleDistance + maximumPossibleDistance + 1) / 2;

                if (CanSelectPointsWithDistance(midDistance))
                {
                    minimumPossibleDistance = midDistance;
                }
                else
                {
                    maximumPossibleDistance = midDistance - 1;
                }
            }

            return (int)minimumPossibleDistance;
        }
    }
}