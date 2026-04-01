namespace DailyQuestion
{
    public class RobotCollisions
    {
        public IList<int> GetSurvivingRobotsHealths(int[] robotPositions, int[] robotHealths, string movementDirections)
        {
            int robotCount = robotPositions.Length;

            int[] robotIndicesSortedByPosition = Enumerable.Range(0, robotCount).ToArray();

            Array.Sort(robotIndicesSortedByPosition, (leftIndex, rightIndex) => robotPositions[leftIndex].CompareTo(robotPositions[rightIndex]));

            Stack<int> rightMovingRobotStack = new Stack<int>();

            foreach (int currentRobotIndex in robotIndicesSortedByPosition)
            {
                if (movementDirections[currentRobotIndex] == 'R')
                {
                    rightMovingRobotStack.Push(currentRobotIndex);
                    continue;
                }

                while (rightMovingRobotStack.Count > 0)
                {
                    int opposingRobotIndex = rightMovingRobotStack.Peek();

                    int currentRobotHealth = robotHealths[currentRobotIndex];
                    int opposingRobotHealth = robotHealths[opposingRobotIndex];

                    if (opposingRobotHealth == currentRobotHealth)
                    {
                        robotHealths[opposingRobotIndex] = 0;
                        robotHealths[currentRobotIndex] = 0;

                        rightMovingRobotStack.Pop();
                        break;
                    }

                    if (opposingRobotHealth > currentRobotHealth)
                    {
                        robotHealths[opposingRobotIndex]--;
                        robotHealths[currentRobotIndex] = 0;
                        break;
                    }

                    robotHealths[opposingRobotIndex] = 0;
                    rightMovingRobotStack.Pop();

                    robotHealths[currentRobotIndex]--;
                }
            }

            List<int> survivingRobotHealths = new List<int>();

            foreach (int health in robotHealths)
            {
                if (health > 0)
                {
                    survivingRobotHealths.Add(health);
                }
            }

            return survivingRobotHealths;
        }
    }
}