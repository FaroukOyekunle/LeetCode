namespace DailyQuestion
{
    public class WalkingRobotSimulation
    {
        public int GetMaximumDistanceSquaredFromOrigin(int[] movementCommands, int[][] obstacleCoordinates)
        {
            var obstaclePositionSet = new HashSet<string>();

            foreach (var obstacle in obstacleCoordinates)
            {
                obstaclePositionSet.Add($"{obstacle[0]},{obstacle[1]}");
            }

            int[][] directionVectors = new int[][]
            {
                new int[] { 0, 1 },   
                new int[] { 1, 0 },   
                new int[] { 0, -1 },  
                new int[] { -1, 0 }
            };

            int currentDirectionIndex = 0;

            int currentXPosition = 0;
            int currentYPosition = 0;

            int maximumDistanceSquared = 0;

            foreach (var command in movementCommands)
            {
                if (command == -1)
                {
                    currentDirectionIndex = (currentDirectionIndex + 1) % 4;
                }

                else if (command == -2)
                {
                    currentDirectionIndex = (currentDirectionIndex + 3) % 4;
                }

                else
                {
                    for (int step = 0; step < command; step++)
                    {
                        int nextXPosition = currentXPosition + directionVectors[currentDirectionIndex][0];

                        int nextYPosition = currentYPosition + directionVectors[currentDirectionIndex][1];

                        if (obstaclePositionSet.Contains($"{nextXPosition},{nextYPosition}"))
                        {
                            break;
                        }

                        currentXPosition = nextXPosition;
                        currentYPosition = nextYPosition;

                        int distanceSquared = currentXPosition * currentXPosition + currentYPosition * currentYPosition;

                        maximumDistanceSquared = Math.Max(maximumDistanceSquared, distanceSquared);
                    }
                }
            }

            return maximumDistanceSquared;
        }
    }
}