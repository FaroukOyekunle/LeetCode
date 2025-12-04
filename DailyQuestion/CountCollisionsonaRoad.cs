namespace DailyQuestion
{
    public class CountCollisionsonaRoad
    {
        public int CountCollisions(string directions)
        {
            int directionsLength = directions.Length;
            int leftBoundIndex = 0, rightBoundIndex = directionsLength - 1;

            while (leftBoundIndex < directionsLength && directions[leftBoundIndex] == 'L')
            {
                leftBoundIndex++;
            }

            while (rightBoundIndex >= 0 && directions[rightBoundIndex] == 'R')
            {
                rightBoundIndex--;
            }

            int collisionCount = 0;

            for (int index = leftBoundIndex; index <= rightBoundIndex; index++)
            {
                if (directions[index] != 'S')
                {
                    collisionCount++;
                }
            }

            return collisionCount;
        }
    }
}